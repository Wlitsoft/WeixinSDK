/**********************************************************************************************************************
 * 描述：
 *      发送响应文本消息。
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
    /// 发送响应文本消息。
    /// </summary>
    [XmlRoot("xml")]
    public class ResponseTextMessage : ResponseMessageBase
    {

        #region ResponseMessageBase 成员

        /// <summary>
        /// 获取 响应消息类型。
        /// </summary>
        public override XmlCDATAElement MsgType
        {
            get { return ResponseMsgType.Text.GetDescription(); }
            set { throw new NotImplementedException(); }
        }

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 文本消息内容。
        /// </summary>
        public XmlCDATAElement Content { get; set; }

        #endregion

    }
}
