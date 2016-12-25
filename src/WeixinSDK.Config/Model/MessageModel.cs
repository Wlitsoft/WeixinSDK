/**********************************************************************************************************************
 * 描述：
 *      普通消息。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/

using Newtonsoft.Json;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Config.Model
{
    /// <summary>
    /// 普通消息。
    /// </summary>
    internal sealed class MessageModel : MessageModelBase
    {
        /// <summary>
        /// 获取或设置 消息类型字符串。
        /// </summary>
        [JsonProperty("MsgType")]
        public RequestMsgType MsgType { get; set; }
    }
}
