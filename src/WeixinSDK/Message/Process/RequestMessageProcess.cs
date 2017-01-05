/**********************************************************************************************************************
 * 描述：
 *      接收请求消息处理。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月04日	 新建
 * 
 *********************************************************************************************************************/
using System;
using System.Collections.Concurrent;
using System.Linq;
using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.Common.Serialize.Dynamic;
using Wlitsoft.Framework.WeixinSDK.Configuration;
using Wlitsoft.Framework.WeixinSDK.Core;
using Wlitsoft.Framework.WeixinSDK.Message.Request.Event;
using Wlitsoft.Framework.WeixinSDK.Message.Response;

namespace Wlitsoft.Framework.WeixinSDK.Message.Process
{
    /// <summary>
    /// 接收请求消息处理。
    /// </summary>
    public class RequestMessageProcess
    {
        #region 私有属性

        /// <summary>
        /// 响应消息类型集合缓存。
        /// </summary>
        private static readonly ConcurrentDictionary<RequestMsgType, Type> _requestMessageTypesCache;

        /// <summary>
        /// 响应事件消息类型集合缓存。
        /// </summary>
        private static readonly ConcurrentDictionary<RequestMsgEventType, Type> _requestEventMessageTypesCache;

        #endregion

        #region 解析服务器接收到的微信服务器推送过来的消息

        /// <summary>
        /// 解析服务器接收到的微信服务器推送过来的消息。
        /// </summary>
        /// <typeparam name="T">消息对象类型。</typeparam>
        /// <param name="message">服务器接收到的请求消息。</param>
        /// <returns>接收请求消息对象。</returns>
        public static T Parse<T>(string message)
            where T : IRequestMessage
        {
            return (T)Parse(message);
        }

        /// <summary>
        /// 解析服务器接收到的微信服务器推送过来的消息。
        /// </summary>
        /// <param name="message">服务器接收到的请求消息。</param>
        /// <returns>接收请求消息对象。</returns>
        public static IRequestMessage Parse(string message)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(message))
                throw new StringNullOrEmptyException(nameof(message));

            #endregion

            #region 获取消息类型

            dynamic xmlMsgObj = new DynamicXml(message);
            string msgTypeText = xmlMsgObj.MsgType.Value;
            RequestMsgType msgType = EnumExtension.GetEnumItemByDescription<RequestMsgType>(msgTypeText);

            #endregion

            //如果不是 事件推送 则，
            if (msgType != RequestMsgType.Event)
            {
                return GetRequestMessageByMsgType(msgType, message);
            }
            else
            {
                string eventTypeText = xmlMsgObj.Event.Value;
                RequestMsgEventType eventType = EnumExtension.GetEnumItemByDescription<RequestMsgEventType>(eventTypeText);

                return GetRequestEventMessageByEventType(eventType, message);
            }
        }

        #endregion

        #region 根据配置处理消息

        /// <summary>
        /// 根据配置处理消息。
        /// </summary>
        /// <returns>一个字符串，表示要响应给微信服务器的内容。</returns>
        public static string ProcessByConfig(string message)
        {

            #region 参数校验

            if (string.IsNullOrEmpty(message))
                throw new StringNullOrEmptyException(nameof(message));

            #endregion

            MessageProcessConfiguration configInfo = WeixinApp.MessageProcessConfig;

            IRequestMessage requestMessage = Parse(message);

            Type messageProcessType = null;

            //普通消息处理。
            if (requestMessage.MsgType != RequestMsgType.Event)
            {
                if (configInfo.MessageList.Any())
                {
                    MessageConfiguration msgConfig = configInfo.MessageList.FirstOrDefault(m => m.MsgType == requestMessage.MsgType);
                    if (msgConfig != null)
                    {
                        messageProcessType = msgConfig.WeixinMessageProcessType;
                    }
                }
            }
            else //事件消息处理。
            {
                if (configInfo.EventMessageList.Any())
                {
                    RequestEventMessageBase requestEventMessage = (RequestEventMessageBase)requestMessage;

                    //没有事件KEY的事件消息。
                    EventMessageConfiguration eventMsgConfig = configInfo.EventMessageList.FirstOrDefault(e => e.EventType == requestEventMessage.Event && string.IsNullOrEmpty(e.EventKey));
                    if (eventMsgConfig != null)
                        messageProcessType = eventMsgConfig.WeixinMessageProcessType;
                    else
                    {
                        //含有事件KEY的事件消息。
                        EventMessageConfiguration hasKeyEventMsgConfig = configInfo.EventMessageList.FirstOrDefault(e => e.EventType == requestEventMessage.Event && e.EventKey == ((IRequestMessageEventKey)requestEventMessage).EventKey);
                        if (hasKeyEventMsgConfig != null)
                            messageProcessType = hasKeyEventMsgConfig.WeixinMessageProcessType;
                    }
                }
            }

            //如果类型不为空则，
            if (messageProcessType != null)
            {
                IWeixinMessageProcess wxmsgProess = (IWeixinMessageProcess)Activator.CreateInstance(messageProcessType);
                wxmsgProess.RequestMessage = requestMessage;
                wxmsgProess.Process();

                //如果指定要响应空字符串则返回空字符串给微信服务器。
                if (wxmsgProess.IsResponseEmptyString)
                    return string.Empty;

                #region 响应消息基本属性赋值

                if (wxmsgProess.ResponseMessage != null)
                {
                    wxmsgProess.ResponseMessage.FromUserName = requestMessage.ToUserName;
                    wxmsgProess.ResponseMessage.ToUserName = requestMessage.FromUserName;
                    wxmsgProess.ResponseMessage.CreateTime = DateTime.Now.GetUnixTimestamp();
                }

                #endregion

                return ResponseMessageProcess.Parse((ResponseMessageBase)wxmsgProess.ResponseMessage);
            }

            //如果没有任何响应则返回给微信服务器一个空字符串。
            return string.Empty;
        }

        #endregion

        #region 私有方法

        #region 根据消息类型获取 IRequestMessage

        /// <summary>
        /// 根据消息类型获取 <see cref="IRequestMessage"/> 。
        /// </summary>
        /// <param name="msgType">消息类型。</param>
        /// <param name="message">XML 消息字符串。</param>
        /// <returns>请求消息对象。</returns>
        private static IRequestMessage GetRequestMessageByMsgType(RequestMsgType msgType, string message)
        {
            #region 参数校验

            if (msgType == RequestMsgType.Event)
                throw new Exception("不能用该方法处理事件消息类型。");

            #endregion

            bool isExist = WeixinApp.MessageProcessConfig.MessageList.Any(m => m.MsgType == msgType);

            //如果在配置里面不存在则不处理。
            if (!isExist)
            {
                return null;
            }

            //如果响应消息类型集合中不存在则将类型放到字典中缓存，
            string typeName = $"Wlitsoft.Framework.WeixinSDK.Message.Request.Request{msgType}Message,Wlitsoft.Framework.WeixinSDK";
            Type type = Type.GetType(typeName, true, true);
            return (IRequestMessage)message.ToXmlObject(_requestMessageTypesCache.GetOrAdd(msgType, type));
        }

        #endregion

        #region 根据事件类型获取 IRequestMessage

        /// <summary>
        /// 根据事件类型获取 <see cref="IRequestMessage"/> 。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="message">XML 消息字符串。</param>
        /// <returns>请求消息对象。</returns>
        private static IRequestMessage GetRequestEventMessageByEventType(RequestMsgEventType eventType, string message)
        {
            bool isExist = WeixinApp.MessageProcessConfig.EventMessageList.Any(m => m.EventType == eventType);

            //如果在配置里面不存在则不处理。
            if (!isExist)
            {
                return null;
            }

            //如果响应事件消息类型集合中不存在则将类型放到字典中缓存，
            string typeName = $"Wlitsoft.Framework.WeixinSDK.Message.Request.Event.Request{eventType}EventMessage,Wlitsoft.Framework.WeixinSDK";
            Type type = Type.GetType(typeName, true, true);
            return (IRequestMessage)message.ToXmlObject(_requestEventMessageTypesCache.GetOrAdd(eventType, type));
        }

        #endregion

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="RequestMessageProcess"/> 的静态实例。
        /// </summary>
        static RequestMessageProcess()
        {
            _requestMessageTypesCache = new ConcurrentDictionary<RequestMsgType, Type>();
            _requestEventMessageTypesCache = new ConcurrentDictionary<RequestMsgEventType, Type>();
        }

        #endregion
    }
}
