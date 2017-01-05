/**********************************************************************************************************************
 * 描述：
 *      接收请求链接消息。
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
    /// 接收请求链接消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestLinkMessage : RequestMessageBase
    {
        #region RequestMessageBase 成员

        /// <summary>
        /// 获取 请求消息类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgType MsgType => RequestMsgType.Link;

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 消息标题。
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置 消息描述。
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置 消息链接。
        /// </summary>
        public string Url { get; set; }

        #endregion
    }
}
