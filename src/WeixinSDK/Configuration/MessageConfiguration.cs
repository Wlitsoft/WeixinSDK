/**********************************************************************************************************************
 * 描述：
 *      普通消息配置信息类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/

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
        public string MsgType { get; set; }

        /// <summary>
        /// 初始化 <see cref="MessageConfiguration"/> 类的新实例。
        /// </summary>
        /// <param name="msgType">消息类型。</param>
        /// <param name="weixinMessageProcess">微信消息处理对象。</param>
        public MessageConfiguration(string msgType, WeixinMessageProcessBase weixinMessageProcess)
            : base(weixinMessageProcess)
        {
            this.MsgType = msgType;
        }
    }
}
