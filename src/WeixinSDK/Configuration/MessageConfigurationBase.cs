/**********************************************************************************************************************
 * 描述：
 *      消息配置信息抽象基类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Configuration
{
    /// <summary>
    /// 消息配置信息抽象基类。
    /// </summary>
    public abstract class MessageConfigurationBase
    {
        /// <summary>
        /// 获取或设置 微信消息处理对象。
        /// </summary>
        public IWeixinMessageProcess WeixinMessageProcess { get; set; }

        /// <summary>
        /// 初始化 <see cref="IWeixinMessageProcess"/> 类的新实例。
        /// </summary>
        /// <param name="weixinMessageProcess">微信消息处理对象。</param>
        protected MessageConfigurationBase(IWeixinMessageProcess weixinMessageProcess)
        {
            this.WeixinMessageProcess = weixinMessageProcess;
        }
    }
}
