/**********************************************************************************************************************
 * 描述：
 *      接收请求取消订阅事件消息。
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
    /// 接收请求取消订阅事件消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestUnSubscribeEventMessage : RequestEventMessageBase
    {
        #region RequestEventMessageBase 成员

        /// <summary>
        /// 获取 事件类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgEventType Event => RequestMsgEventType.UnSubscribe;

        #endregion
    }
}
