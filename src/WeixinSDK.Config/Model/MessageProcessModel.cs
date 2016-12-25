/**********************************************************************************************************************
 * 描述：
 *      消息处理。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Wlitsoft.Framework.WeixinSDK.Config.Model
{
    /// <summary>
    /// 消息处理。
    /// </summary>
    internal sealed class MessageProcessModel
    {
        #region 公共属性

        /// <summary>
        /// 获取或设置 普通消息配置信息列表。
        /// </summary>
        [JsonProperty("Messages")]
        public List<MessageModel> MessageList { get; set; }

        /// <summary>
        /// 获取或设置 事件消息配置信息列表。
        /// </summary>
        [JsonProperty("EventMessages")]
        public List<EventMessageModel> EventMessageList { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="MessageProcessModel"/> 类的新实例。
        /// </summary>
        public MessageProcessModel()
        {
            this.MessageList = new List<MessageModel>();
            this.EventMessageList = new List<EventMessageModel>();
        }

        #endregion
    }
}
