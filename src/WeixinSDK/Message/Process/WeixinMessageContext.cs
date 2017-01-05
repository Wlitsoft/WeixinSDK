/**********************************************************************************************************************
 * 描述：
 *      微信消息上下文。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月04日	 新建
 * 
 *********************************************************************************************************************/
namespace Wlitsoft.Framework.WeixinSDK.Message.Process
{
    /// <summary>
    /// 微信消息上下文。
    /// </summary>
    public class WeixinMessageContext
    {
        /// <summary>
        /// 获取或设置 HTTP 请求内容。
        /// </summary>
        public string HttpRequestContent { get; set; }

        /// <summary>
        /// 获取或设置 HTTP 请求参数。 
        /// </summary>
        public HttpRequestParams HttpRequestParams { get; set; }
    }
}
