/**********************************************************************************************************************
 * 描述：
 *      接收请求订阅事件消息。
 * 
 * 变更历史：
 *      作者：李亮  时间：2015年12月27日	 新建
 * 
 *********************************************************************************************************************/
using System.Xml.Serialization;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Message.Request.Event
{
    /// <summary>
    /// 接收请求订阅事件消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestSubscribeEventMessage : RequestEventMessageBase, IRequestMessageEventKey
    {
        #region RequestEventMessageBase 成员

        /// <summary>
        /// 获取 事件类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgEventType Event => RequestMsgEventType.Subscribe;

        #endregion

        #region IRequestMessageEventKey 成员

        /// <summary>
        /// 获取或设置 事件 KEY 值。
        /// </summary>
        public string EventKey { get; set; }

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 二维码的ticket，可用来换取二维码图片。
        /// </summary>
        public string Ticket { get; set; }

        #endregion
    }
}
