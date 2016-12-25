/**********************************************************************************************************************
 * 描述：
 *      事件消息。
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
    /// 事件消息。
    /// </summary>
    internal sealed class EventMessageModel : MessageModelBase
    {
        /// <summary>
        /// 获取或设置 事件类型。
        /// </summary>
        [JsonProperty("EventType")]
        public RequestMsgEventType EventType { get; set; }

        /// <summary>
        /// 获取或设置 事件KEY值字符串。
        /// </summary>
        [JsonProperty("EventKey")]
        public string EventKey { get; set; }
    }
}
