/**********************************************************************************************************************
 * 描述：
 *      发送响应图文消息。
 * 
 * 变更历史：
 *      作者：李亮  时间：2015年12月27日	 新建
 * 
 *********************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.Common.Serialize;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Message.Response
{
    /// <summary>
    /// 发送响应图文消息。
    /// </summary>
    [XmlRoot("xml")]
    public class ResponseNewsMessage : ResponseMessageBase
    {
        #region ResponseMessageBase 成员

        /// <summary>
        /// 获取 响应消息类型。
        /// </summary>
        [XmlIgnore]
        public override XmlCDATAElement MsgType
        {
            get { return ResponseMsgType.News.GetDescription(); }
            set { throw new NotImplementedException(); }
        }

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取 图文消息个数，限制为10条以内。
        /// </summary>
        public int ArticleCount
        {
            get
            {
                if (this.Articles == null) return 0;
                if (this.Articles.Count > 10)
                    throw new Exception("图文消息信息过多，不能超过 10 条。");
                return this.Articles.Count;
            }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// 获取或设置 多条图文消息信息，默认第一个item为大图,注意，如果图文数超过10，则将会无响应。
        /// </summary>
        [XmlArray("Articles")]
        [XmlArrayItem("item")]
        public List<ArticleData> Articles { get; set; }

        #endregion

        #region 发送响应图文消息 图文消息信息数据

        /// <summary>
        /// 发送响应图文消息 图文消息信息数据。
        /// </summary>
        public class ArticleData
        {
            /// <summary>
            /// 获取或设置 图文消息标题。
            /// </summary>
            public XmlCDATAElement Title { get; set; }

            /// <summary>
            /// 获取或设置 图文消息描述。
            /// </summary>
            public XmlCDATAElement Description { get; set; }

            /// <summary>
            /// 获取或设置 图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200。
            /// </summary>
            public XmlCDATAElement PicUrl { get; set; }

            /// <summary>
            /// 获取或设置 点击图文消息跳转链接。
            /// </summary>
            public XmlCDATAElement Url { get; set; }

        }

        #endregion
    }
}
