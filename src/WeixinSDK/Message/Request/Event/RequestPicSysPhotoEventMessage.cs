/**********************************************************************************************************************
 * 描述：
 *      接收请求弹出系统拍照发图的事件消息。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月27日	 新建
 * 
 *********************************************************************************************************************/

using System.Collections.Generic;
using System.Xml.Serialization;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Message.Request.Event
{
    /// <summary>
    /// 接收请求弹出系统拍照发图的事件消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestPicSysPhotoEventMessage : RequestEventMessageBase, IRequestMessageEventKey
    {
        #region RequestEventMessageBase 成员

        /// <summary>
        /// 获取 事件类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgEventType Event => RequestMsgEventType.PicSysPhoto;

        #endregion

        #region IEventKey 成员

        /// <summary>
        /// 获取或设置 事件KEY值，由开发者在创建菜单时设定。
        /// </summary>
        public string EventKey { get; set; }

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 发送的图片信息。
        /// </summary>
        public SendPicsInfoData SendPicsInfo { get; set; }

        #endregion

        #region 发送的图片信息数据

        /// <summary>
        /// 发送的图片信息数据。
        /// </summary>
        public class SendPicsInfoData
        {
            /// <summary>
            /// 获取或设置 发送的图片数量。
            /// </summary>
            public int Count { get; set; }

            /// <summary>
            /// 获取或设置 图片列表。
            /// </summary>
            [XmlArray("PicList")]
            [XmlArrayItem("item")]
            public List<PicData> PicList { get; set; }


            /// <summary>
            /// 图片数据。
            /// </summary>
            public class PicData
            {
                /// <summary>
                /// 获取或设置 图片的MD5值，开发者若需要，可用于验证接收到图片。
                /// </summary>
                public string PicMd5Sum { get; set; }
            }
        }

        #endregion
    }
}
