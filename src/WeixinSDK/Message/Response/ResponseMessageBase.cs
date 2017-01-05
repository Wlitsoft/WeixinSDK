/**********************************************************************************************************************
 * 描述：
 *      发送响应消息 基类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2015年12月27日	 新建
 * 
 *********************************************************************************************************************/
using System.Xml.Serialization;
using Wlitsoft.Framework.Common.Serialize;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Message.Response
{
    /// <summary>
    /// 发送响应消息 基类。
    /// </summary>
    [XmlRoot("xml")]
    public abstract class ResponseMessageBase : IResponseMessage
    {
        /// <summary>
        /// 获取或设置 接收方帐号（收到的OpenID）。
        /// </summary>
        public XmlCDATAElement ToUserName { get; set; }

        /// <summary>
        /// 获取或设置 开发者微信号。
        /// </summary>
        public XmlCDATAElement FromUserName { get; set; }

        /// <summary>
        /// 获取或设置 消息创建时间 。
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// 获取 消息类型。
        /// </summary>
        public abstract XmlCDATAElement MsgType { get; set; }
    }
}
