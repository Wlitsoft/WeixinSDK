/**********************************************************************************************************************
 * 描述：
 *      接收请求资质认证失败事件消息。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月27日	  新建
 * 
 *********************************************************************************************************************/

using System.Xml.Serialization;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Message.Request.Event
{
    /// <summary>
    /// 接收请求资质认证失败事件消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestQualificationVerifyFailEventMessage : RequestEventMessageBase
    {
        #region RequestEventMessageBase 成员

        /// <summary>
        /// 获取 事件类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgEventType Event => RequestMsgEventType.QualificationVerifyFail;

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 失败发生时间。
        /// </summary>
        public long FailTime { get; set; }

        /// <summary>
        /// 获取或设置 认证失败的原因。
        /// </summary>
        public string FailReason { get; set; }

        #endregion
    }
}
