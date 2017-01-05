/**********************************************************************************************************************
 * 描述：
 *      发送响应图片消息。
 * 
 * 变更历史：
 *      作者：李亮  时间：2015年12月27日	 新建
 * 
 *********************************************************************************************************************/
using System;
using System.Xml.Serialization;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.Common.Serialize;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Message.Response
{
    /// <summary>
    /// 发送响应图片消息。
    /// </summary>
    [XmlRoot("xml")]
    public class ResponseImageMessage : ResponseMessageBase
    {
        #region ResponseMessageBase 成员

        /// <summary>
        /// 获取 响应消息类型。
        /// </summary>
        public override XmlCDATAElement MsgType
        {
            get { return ResponseMsgType.Image.GetDescription(); }
            set { throw new NotImplementedException(); }
        }

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 发送响应图片消息模型  图片数据。
        /// </summary>
        public ImageData Image { get; set; }

        #endregion

        #region 发送响应图片消息 图片数据

        /// <summary>
        /// 发送响应图片消息 图片数据。
        /// </summary>
        public class ImageData
        {

            #region 公共属性

            /// <summary>
            /// 获取或设置 通过素材管理接口上传多媒体文件，得到的id。
            /// </summary>
            public XmlCDATAElement MediaId { get; set; }

            #endregion

            #region 构造方法

            /// <summary>
            /// 初始化 <see cref="ImageData"/> 类的新实例。
            /// </summary>
            public ImageData()
            {

            }

            /// <summary>
            /// 根据通过素材管理接口上传多媒体文件，得到的id 初始化 <see cref="ImageData"/> 类的新实例。
            /// </summary>
            /// <param name="mediaId">通过素材管理接口上传多媒体文件，得到的id。</param>
            public ImageData(string mediaId)
            {
                this.MediaId = mediaId;
            }

            #endregion

        }

        #endregion
    }
}
