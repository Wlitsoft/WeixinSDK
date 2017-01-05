/**********************************************************************************************************************
 * 描述：
 *      接收请求点击菜单拉取消息时的事件消息。
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
    /// 接收请求点击菜单拉取消息时的事件消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestClickEventMessage : RequestEventMessageBase, IRequestMessageEventKey
    {
        #region RequestEventMessageBase 成员

        /// <summary>
        /// 获取 事件类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgEventType Event => RequestMsgEventType.Click;

        #endregion

        #region IRequestMessageEventKey 成员

        /// <summary>
        /// 获取或设置 事件KEY值，与自定义菜单接口中KEY值对应。
        /// </summary>
        public string EventKey { get; set; }

        #endregion
    }
}
