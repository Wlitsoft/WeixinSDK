/**********************************************************************************************************************
 * 描述：
 *      接收请求消息类型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2015年12月25日	 新建
 * 
 *********************************************************************************************************************/

using System.ComponentModel;

namespace Wlitsoft.Framework.WeixinSDK.Core
{
    /// <summary>
    /// 接收请求消息类型。
    /// </summary>
    public enum RequestMsgType
    {
        /// <summary>
        /// 文本消息。
        /// </summary>
        [Description("text")]
        Text,

        /// <summary>
        /// 图片消息。
        /// </summary>
        [Description("image")]
        Image,

        /// <summary>
        /// 语音消息。
        /// </summary>
        [Description("voice")]
        Voice,

        /// <summary>
        /// 视频消息。
        /// </summary>
        [Description("video")]
        Video,

        /// <summary>
        /// 小视频消息。
        /// </summary>
        [Description("shortvideo")]
        ShortVideo,
        
        /// <summary>
        /// 地理位置消息。
        /// </summary>
        [Description("location")]
        Location,

        /// <summary>
        /// 链接消息。
        /// </summary>
        [Description("link")]
        Link,

        /// <summary>
        /// 事件推送。
        /// </summary>
        [Description("event")]
        Event,
    }
}
