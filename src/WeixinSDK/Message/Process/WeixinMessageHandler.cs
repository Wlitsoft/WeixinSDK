/**********************************************************************************************************************
 * 描述：
 *      微信消息处理者。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月04日	 新建
 * 
 *********************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.WeixinSDK.Core;
using Wlitsoft.Framework.WeixinSDK.Message.Request;
using Wlitsoft.Framework.WeixinSDK.Message.Security;
using Wlitsoft.Framework.WeixinSDK.Message.Security.Crypto;

namespace Wlitsoft.Framework.WeixinSDK.Message.Process
{
    /// <summary>
    /// 微信消息处理者。
    /// </summary>
    public class WeixinMessageHandler
    {
        #region 私有属性

        /// <summary>
        /// 消息标识列表。
        /// </summary>
        private static readonly IList<KeyValuePair<string, DateTime>> _messageIdentitys = new List<KeyValuePair<string, DateTime>>();

        /// <summary>
        /// 接收请求消息。
        /// </summary>
        private IRequestMessage _requestMessage;

        /// <summary>
        /// Http 请求参数。
        /// </summary>
        private HttpRequestParams _requestParams;

        /// <summary>
        /// Http 请求内容。
        /// </summary>
        private string _requestContent;

        /// <summary>
        /// Http 响应内容。
        /// </summary>
        private string _responeContent;

        /// <summary>
        /// 微信消息加密解密。
        /// </summary>
        private WeixinMsgCrypto _msgCrypto;

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取 微信消息上下文。
        /// </summary>
        private WeixinMessageContext MessageContext { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 根据微信消息上下文对象初始化 <see cref="WeixinMessageHandler"/> 类的新实例。
        /// </summary>
        /// <param name="messageContext">微信消息上下文。</param>
        public WeixinMessageHandler(WeixinMessageContext messageContext)
        {
            this.MessageContext = messageContext;
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 执行处理并返回 HTTP 响应消息。
        /// </summary>
        /// <returns>HTTP 响应内容。</returns>
        public string Execute()
        {
            this.ExecMessageHandler();

            #region 记录调试跟踪日志

            object content = new
            {
                RequestContent = this._requestContent,
                ResponeContent = this._responeContent
            };

            WeixinApp.Logger.Debug($"[WeixinMessageHandlerExecuteInfo]\r\n{content.ToJsonString()}");

            #endregion

            //返回http响应内容给微信服务器。
            return this._responeContent;
        }

        #endregion

        #region 私有方法

        #region 执行消息处理

        /// <summary>
        /// 执行消息处理。
        /// </summary>
        private void ExecMessageHandler()
        {

            #region 参数校验

            if (string.IsNullOrEmpty(this.MessageContext.HttpRequestContent))
                throw new StringNullOrEmptyException("HttpRequestContent");

            if (this.MessageContext.HttpRequestParams == null)
                throw new StringNullOrEmptyException("HttpRequestParams");

            #endregion

            #region 初始化参数

            this._requestParams = this.MessageContext.HttpRequestParams;
            this._requestContent = this.MessageContext.HttpRequestContent;

            #endregion

            #region 校验签名

            CheckSignature.Execute(this._requestParams.Signature, this._requestParams.Timestamp, this._requestParams.Nonce, string.Empty);

            #endregion

            #region 消息解密

            if (this._requestParams.IsEncrypt)
            {
                this._msgCrypto = new WeixinMsgCrypto();
                int decryptMsgResult = this._msgCrypto.DecryptMsg(this._requestParams.Msg_Signature, this._requestParams.Timestamp, this._requestParams.Nonce, this._requestContent, ref this._requestContent);
                if (decryptMsgResult != Convert.ToInt32(WeixinMsgCryptoErrorCode.OK))
                    throw new Exception("消息解密失败！");
            }

            #endregion

            //消息解析。
            this._requestMessage = RequestMessageProcess.Parse(this._requestContent);

            if (this._requestMessage == null)
            {
                this._responeContent = string.Empty;
                //记录日志。
                WeixinApp.Logger.Info($"消息未处理，requestContent:{this._requestContent}");
                return;
            }

            #region 会话支持

            //todo: 后期实现。

            #endregion

            #region 消息去重

            #region 删除无效的消息标识

            for (int i = 0; i < _messageIdentitys.Count; i++)
            {
                KeyValuePair<string, DateTime> item = _messageIdentitys[i];

                //如果消息处理时间大于 30 秒则删除该条标识。
                if (item.Value.AddSeconds(30) < DateTime.Now)
                {
                    _messageIdentitys.Remove(item);
                }
            }

            #endregion

            string msgIdentity = this.GetMessageIdentity(this._requestMessage);

            //如果消息已经被标识为处理则返回空字符串，
            if (_messageIdentitys.Any(i => i.Key == msgIdentity))
            {
                this._responeContent = string.Empty;

                //记录日志。
                WeixinApp.Logger.Info($"消息重复，已经响应空字符串消息,消息标识：[{msgIdentity}]\r\n请求内容：{_requestContent}");
                return;
            }

            //将当前消息标识添加到标识列表中，
            _messageIdentitys.Add(new KeyValuePair<string, DateTime>(msgIdentity, DateTime.Now));

            #endregion

            //消息处理。
            this._responeContent = RequestMessageProcess.ProcessByConfig(this._requestContent);

            #region 消息加密

            if (this._requestParams.IsEncrypt)
            {
                int encryptMsgResult = this._msgCrypto.EncryptMsg(this._responeContent, this._requestParams.Timestamp, this._requestParams.Nonce, ref this._responeContent);
                if (encryptMsgResult != Convert.ToInt32(WeixinMsgCryptoErrorCode.OK))
                    throw new Exception("消息加密失败！");
            }

            #endregion
        }

        #endregion

        #region 获取消息标识

        /// <summary>
        /// 获取消息标识。
        /// </summary>
        /// <param name="requestMessage">接收请求消息对象。</param>
        /// <returns>消息唯一标识。</returns>
        private string GetMessageIdentity(IRequestMessage requestMessage)
        {
            //如果是事件消息则唯一标识规则为发送方账号 + 消息创建时间，如果是普通消息则唯一标识规则为消息ID。
            if (requestMessage.MsgType == RequestMsgType.Event)
                return requestMessage.FromUserName + requestMessage.CreateTime;
            return ((RequestMessageBase)requestMessage).MsgId.ToString(CultureInfo.InvariantCulture);
        }

        #endregion

        #endregion

    }
}
