/**********************************************************************************************************************
 * 描述：
 *      消息处理配置信息类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/
using System.Collections.Generic;

namespace Wlitsoft.Framework.WeixinSDK.Configuration
{
    /// <summary>
    /// 消息处理配置信息类。
    /// </summary>
    public class MessageProcessConfiguration
    {
        #region 公共属性

        /// <summary>
        /// 获取或设置 普通消息配置信息列表。
        /// </summary>
        public List<MessageConfiguration> MessageList { get; set; }
        /// <summary>
        /// 获取或设置 事件消息配置信息列表。
        /// </summary>
        public List<EventMessageConfiguration> EventMessageList { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="MessageProcessConfiguration"/> 类的新实例。
        /// </summary>
        public MessageProcessConfiguration()
        {
            this.MessageList = new List<MessageConfiguration>();
            this.EventMessageList = new List<EventMessageConfiguration>();
        }

        #endregion
    }
}
