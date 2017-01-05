/**********************************************************************************************************************
 * 描述：
 *      接收请求模板消息发送完成事件消息。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月27日	 新建
 * 
 *********************************************************************************************************************/

using System.ComponentModel;
using System.Xml.Serialization;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Message.Request.Event
{
    /// <summary>
    /// 接收请求模板消息发送完成事件消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestTemplateSendJobFinishEventMessage : RequestEventMessageBase
    {
        #region RequestEventMessageBase 成员

        /// <summary>
        /// 获取 事件类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgEventType Event => RequestMsgEventType.TemplateSendJobFinish;

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 发送的消息ID。
        /// </summary>
        public long MsgID { get; set; }

        /// <summary>
        /// 获取或设置 发送的结果。
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 获取 发送的结果文本描述。
        /// </summary>
        [XmlIgnore]
        public string StatusText => this.Status;

        #endregion

        #region 发送状态

        /// <summary>
        /// 发送状态。
        /// </summary>
        public enum SendStatus
        {
            /// <summary>
            /// 发送成功。
            /// </summary>
            [Description("success")]
            SendSuccess,

            /// <summary>
            /// 发送失败，用户拒绝接收。
            /// </summary>
            [Description("failed:user block")]
            UserBlock,

            /// <summary>
            /// 发送失败，系统原因。
            /// </summary>
            [Description("failed: system failed")]
            SendFail,

        }

        #endregion
    }
}
