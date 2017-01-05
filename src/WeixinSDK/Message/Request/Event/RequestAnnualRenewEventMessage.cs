/**********************************************************************************************************************
 * 描述：
 *      接收请求年审通知事件消息。
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
    /// 接收请求年审通知事件消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestAnnualRenewEventMessage : RequestEventMessageBase
    {
        #region RequestEventMessageBase 成员

        /// <summary>
        /// 获取 事件类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgEventType Event => RequestMsgEventType.AnnualRenew;

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 有效期。
        /// <para>有效期 (整形)，指的是时间戳，将于该时间戳认证过期，需尽快年审。</para>
        /// </summary>
        public long ExpiredTime { get; set; }

        #endregion
    }
}
