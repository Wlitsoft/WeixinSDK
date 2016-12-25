/**********************************************************************************************************************
 * 描述：
 *      发送响应消息接口。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/
using Wlitsoft.Framework.Common.Serialize;

namespace Wlitsoft.Framework.WeixinSDK.Core
{
    /// <summary>
    /// 发送响应消息接口。
    /// </summary>
    public interface IResponseMessage
    {
        /// <summary>
        /// 获取或设置 接收方帐号（收到的OpenID）。
        /// </summary>
        XmlCDATAElement ToUserName { get; set; }

        /// <summary>
        /// 获取或设置 开发者微信号。
        /// </summary>
        XmlCDATAElement FromUserName { get; set; }

        /// <summary>
        /// 获取或设置 消息创建时间 。
        /// </summary>
        long CreateTime { get; set; }

        /// <summary>
        /// 获取 消息类型。
        /// </summary>
        XmlCDATAElement MsgType { get; set; }
    }
}
