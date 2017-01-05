/**********************************************************************************************************************
 * 描述：
 *      接收请求文本消息。
 * 
 * 变更历史：
 *      作者：李亮  时间：2015年12月27日	 新建
 * 
 *********************************************************************************************************************/
using System.Xml.Serialization;
using Wlitsoft.Framework.WeixinSDK.Core;
using Wlitsoft.Framework.Common.Extension;

namespace Wlitsoft.Framework.WeixinSDK.Message.Request
{
    /// <summary>
    /// 接收请求文本消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestTextMessage : RequestMessageBase
    {
        #region RequestMessageBase 成员

        /// <summary>
        /// 获取 请求消息类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgType MsgType => RequestMsgType.Text;

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 文本消息内容。
        /// </summary>
        public string Content { get; set; }

        #endregion
    }
}
