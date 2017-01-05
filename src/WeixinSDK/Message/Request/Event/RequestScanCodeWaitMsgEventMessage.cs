/**********************************************************************************************************************
 * 描述：
 *      接收请求扫码推事件且弹出“消息接收中”提示框的事件消息。
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
    /// 接收请求扫码推事件且弹出“消息接收中”提示框的事件消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestScanCodeWaitMsgEventMessage : RequestScanCodePushEventMessage
    {
        #region RequestEventMessageBase 成员

        /// <summary>
        /// 获取 事件类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgEventType Event => RequestMsgEventType.ScanCodeWaitMsg;

        #endregion
    }
}
