/**********************************************************************************************************************
 * 描述：
 *      接收请求点击菜单跳转链接时的事件消息。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月27日	 新建
 * 
 *********************************************************************************************************************/

using System.Xml.Serialization;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Message.Request.Event
{
    /// <summary>
    /// 接收请求点击菜单跳转链接时的事件消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestViewEventMessage : RequestEventMessageBase, IRequestMessageEventKey
    {
        #region RequestEventMessageBase 成员

        /// <summary>
        /// 获取 事件类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgEventType Event => RequestMsgEventType.View;

        #endregion

        #region IEventKey 成员

        /// <summary>
        /// 获取或设置 事件KEY值，设置的跳转URL。
        /// </summary>
        public string EventKey { get; set; }

        #endregion
    }
}
