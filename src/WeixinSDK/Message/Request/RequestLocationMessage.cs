/**********************************************************************************************************************
 * 描述：
 *      接收请求地理位置消息。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月27日	 新建
 * 
 *********************************************************************************************************************/

using System.Xml.Serialization;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Message.Request
{
    /// <summary>
    /// 接收请求视频消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestLocationMessage : RequestMessageBase
    {
        #region RequestMessageBase 成员

        /// <summary>
        /// 获取 请求消息类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgType MsgType => RequestMsgType.Location;

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 地理位置维度。
        /// </summary>
        public double Location_X { get; set; }

        /// <summary>
        /// 获取或设置 地理位置经度。
        /// </summary>
        public double Location_Y { get; set; }

        /// <summary>
        /// 获取或设置 地图缩放大小。
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// 获取或设置 地理位置信息。
        /// </summary>
        public string Label { get; set; }

        #endregion
    }
}
