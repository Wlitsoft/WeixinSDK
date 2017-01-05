/**********************************************************************************************************************
 * 描述：
 *      接收请求图片消息。
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
    /// 接收请求图片消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestImageMessage : RequestMessageBase
    {
        #region RequestMessageBase 成员

        /// <summary>
        /// 获取 请求消息类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgType MsgType => RequestMsgType.Image;

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 图片链接。
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 获取或设置 图片消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }

        #endregion
    }
}
