/**********************************************************************************************************************
 * 描述：
 *      事件消息配置信息类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Configuration
{
    /// <summary>
    /// 事件消息配置信息类。
    /// </summary>
    public class EventMessageConfiguration : MessageConfigurationBase
    {
        /// <summary>
        /// 获取或设置 事件类型。
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// 获取或设置 事件KEY值字符串。
        /// </summary>
        public string EventKey { get; set; }

        /// <summary>
        /// 初始化 <see cref="EventMessageConfiguration"/> 类的新实例。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="weixinMessageProcess">微信消息处理对象。</param>
        public EventMessageConfiguration(string eventType, WeixinMessageProcessBase weixinMessageProcess)
            : base(weixinMessageProcess)
        {
            this.EventType = eventType;
        }
    }
}
