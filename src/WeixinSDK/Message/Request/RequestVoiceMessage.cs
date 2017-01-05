/**********************************************************************************************************************
 * 描述：
 *      接收请求语音消息。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月27日	 新建
 * 
 *********************************************************************************************************************/

using System.Xml.Serialization;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Message.Request
{
    /// <summary>
    /// 接收请求语音消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestVoiceMessage : RequestMessageBase
    {

        #region RequestMessageBase 成员

        /// <summary>
        /// 获取 请求消息类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgType MsgType => RequestMsgType.Voice;

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 语音消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 获取或设置 语音格式，如amr，speex等。
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 获取或设置 语音识别结果，UTF8编码。
        /// <para>
        /// 注：由于客户端缓存，开发者开启或者关闭语音识别功能，对新关注者立刻生效，
        /// 对已关注用户需要24小时生效。开发者可以重新关注此帐号进行测试。
        /// </para>
        /// </summary>
        public string Recognition { get; set; }

        #endregion

    }
}