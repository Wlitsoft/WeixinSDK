/**********************************************************************************************************************
 * 描述：
 *      接收请求消息接口。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/
namespace Wlitsoft.Framework.WeixinSDK.Core
{
    /// <summary>
    /// 接收请求消息接口。
    /// </summary>
    public interface IRequestMessage
    {
        /// <summary>
        /// 获取或设置 开发者微信号。
        /// </summary>
        string ToUserName { get; set; }

        /// <summary>
        /// 获取或设置 发送方帐号（一个OpenID）。
        /// </summary>
        string FromUserName { get; set; }

        /// <summary>
        /// 获取或设置 消息创建时间 。
        /// </summary>
        long CreateTime { get; set; }

        /// <summary>
        /// 获取 消息类型。
        /// </summary>
        string MsgType { get; }
    }
}
