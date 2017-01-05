/**********************************************************************************************************************
 * 描述：
 *      接收请求弹出地理位置选择器的事件消息。
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
    /// 接收请求弹出地理位置选择器的事件消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestLocationSelectEventMessage : RequestEventMessageBase, IRequestMessageEventKey
    {
        #region RequestEventMessageBase 成员

        /// <summary>
        /// 获取 事件类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgEventType Event => RequestMsgEventType.LocationSelect;

        #endregion

        #region IEventKey 成员

        /// <summary>
        /// 获取或设置 事件KEY值，由开发者在创建菜单时设定。
        /// </summary>
        public string EventKey { get; set; }

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 发送的位置信息。
        /// </summary>
        public SendLocationInfoData SendLocationInfo { get; set; }

        #endregion

        #region 发送的位置信息数据

        /// <summary>
        /// 发送的位置信息数据。
        /// </summary>
        public class SendLocationInfoData
        {
            /// <summary>
            /// 获取或设置 X坐标信息。
            /// </summary>
            public double Location_X { get; set; }

            /// <summary>
            /// 获取或设置 Y坐标信息。
            /// </summary>
            public double Location_Y { get; set; }

            /// <summary>
            /// 获取或设置 精度，可理解为精度或者比例尺、越精细的话 scale越高。
            /// </summary>
            public int Scale { get; set; }

            /// <summary>
            /// 获取或设置 地理位置的字符串信息。
            /// </summary>
            public string Label { get; set; }

            /// <summary>
            /// 获取或设置 朋友圈POI的名字，可能为空。
            /// </summary>
            public string Poiname { get; set; }

        }

        #endregion
    }
}
