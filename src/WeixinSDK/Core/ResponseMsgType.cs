/**********************************************************************************************************************
 * 描述：
 *      发送响应消息类型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/

using System.ComponentModel;

namespace Wlitsoft.Framework.WeixinSDK.Core
{
    /// <summary>
    /// 发送响应消息类型。
    /// </summary>
    public enum ResponseMsgType
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
        /// 音乐消息。
        /// </summary>
        [Description("music")]
        Music,

        /// <summary>
        /// 图文消息。
        /// </summary>
        [Description("news")]
        News,

    }
}
