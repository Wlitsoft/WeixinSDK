/**********************************************************************************************************************
 * 描述：
 *      开发配置信息类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 *      作者：李亮  时间：2017年01月07日	 编辑 添加 PayConfig 属性。
 *********************************************************************************************************************/
namespace Wlitsoft.Framework.WeixinSDK.Configuration
{
    /// <summary>
    /// 开发配置信息类。
    /// </summary>
    public sealed class DevConfiguration
    {
        /// <summary>
        /// 获取或设置 应用ID。
        /// </summary>
        public string AppID { get; set; }

        /// <summary>
        /// 获取或设置 应用密钥。
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// 获取或设置 令牌。
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 获取或设置 消息加解密密钥。
        /// </summary>
        public string EncodingAESKey { get; set; }

        /// <summary>
        /// 获取或设置 JS接口调试开关。
        /// </summary>
        public bool JSApiDebug { get; set; }

        /// <summary>
        /// 获取或设置 支付配置。
        /// </summary>
        public PayConfiguration PayConfig { get; set; }

        /// <summary>
        /// 初始化 <see cref="DevConfiguration"/> 类的新实例。
        /// </summary>
        public DevConfiguration()
        {
            this.PayConfig = new PayConfiguration();
        }
    }
}
