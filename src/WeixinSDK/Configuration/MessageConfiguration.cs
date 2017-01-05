/**********************************************************************************************************************
 * 描述：
 *      普通消息配置信息类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/

using System;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Configuration
{
    /// <summary>
    /// 普通消息配置信息类。
    /// </summary>
    public class MessageConfiguration : MessageConfigurationBase
    {
        /// <summary>
        /// 获取或设置 消息类型。
        /// </summary>
        public RequestMsgType MsgType { get; set; }

        /// <summary>
        /// 初始化 <see cref="MessageConfiguration"/> 类的新实例。
        /// </summary>
        /// <param name="msgType">消息类型。</param>
        /// <param name="weixinMessageProcessType">微信消息处理对象类型声明。</param>
        public MessageConfiguration(RequestMsgType msgType, Type weixinMessageProcessType)
            : base(weixinMessageProcessType)
        {
            this.MsgType = msgType;
        }
    }

    /// <summary>
    /// 普通消息配置信息类。
    /// </summary>
    /// <typeparam name="TWeixinMessageProcess">微信消息处理类型。</typeparam>
    public class MessageConfiguration<TWeixinMessageProcess> : MessageConfiguration
        where TWeixinMessageProcess : IWeixinMessageProcess
    {
        /// <summary>
        /// 初始化 <see cref="MessageConfiguration"/> 类的新实例。
        /// </summary>
        /// <param name="msgType">消息类型。</param>
        public MessageConfiguration(RequestMsgType msgType)
            : base(msgType, typeof(TWeixinMessageProcess))
        {

        }
    }
}
