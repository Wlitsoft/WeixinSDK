/**********************************************************************************************************************
 * 描述：
 *      接收请求上报地理位置事件消息。
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
    /// 接收请求上报地理位置事件消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestLocationEventMessage : RequestEventMessageBase
    {
        #region RequestEventMessageBase 成员

        /// <summary>
        /// 获取 事件类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgEventType Event => RequestMsgEventType.Location;

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 地理位置纬度。
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// 获取或设置 地理位置经度。
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// 获取或设置 地理位置精度。
        /// </summary>
        public double Precision { get; set; }

        #endregion
    }
}
