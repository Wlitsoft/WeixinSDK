/**********************************************************************************************************************
 * 描述：
 *      接收请求消息 基类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2015年12月27日	 新建
 * 
 *********************************************************************************************************************/
using System.Xml.Serialization;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Message.Request
{
    /// <summary>
    /// 接收请求消息 基类。
    /// </summary>
    [XmlRoot("xml")]
    public abstract class RequestMessageBase : IRequestMessage
    {
        #region IRequestMessage 成员

        /// <summary>
        /// 获取或设置 开发者微信号。
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 获取或设置 发送方帐号（一个OpenID）。
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 获取或设置 消息创建时间 。
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// 获取 消息类型。
        /// </summary>
        public abstract RequestMsgType MsgType { get; }

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 消息id。
        /// </summary>
        public long MsgId { get; set; }

        #endregion
    }
}
