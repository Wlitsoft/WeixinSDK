/**********************************************************************************************************************
 * 描述：
 *      应用 构造 静态扩展类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/

using Wlitsoft.Framework.Common;
using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.WeixinSDK.Config.Builder;
using Wlitsoft.Framework.WeixinSDK.Extension;

namespace Wlitsoft.Framework.WeixinSDK.Config.Extension
{
    /// <summary>
    /// 应用 构造 静态扩展类。
    /// </summary>
    public static class AppBuilderExtension
    {
        #region 设置微信开发配置

        /// <summary>
        /// 以项目配置文件 AppSettings 配置节点的方式设置微信开发配置。
        /// </summary>
        /// <param name="appBuilder">应用构造。</param>
        /// <returns>应用 构造 静态扩展。</returns>
        public static AppBuilder SetWeixinDevConfigByAppSettings(this AppBuilder appBuilder)
        {
            appBuilder.SetWeixinDevConfig(DevConfigurationBuilder.BuildByAppSettings());
            return appBuilder;
        }

        /// <summary>
        /// 以 json 配置文件的方式设置微信开发配置。
        /// </summary>
        /// <param name="appBuilder">应用构造。</param>
        /// <param name="configFilePath">配置文件路径。</param>
        /// <returns>应用 构造 静态扩展。</returns>
        public static AppBuilder SetWeixinDevConfigByJsonFile(this AppBuilder appBuilder, string configFilePath)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(configFilePath))
                throw new StringNullOrEmptyException(nameof(configFilePath));

            #endregion

            appBuilder.SetWeixinDevConfig(DevConfigurationBuilder.BuildByJsonFile(configFilePath));
            return appBuilder;
        }

        #endregion

        #region 设置微信消息处理配置

        /// <summary>
        /// 以 json 配置文件的方式设置微信消息处理配置。
        /// </summary>
        /// <param name="appBuilder">应用构造。</param>
        /// <param name="configFilePath">配置文件路径。</param>
        /// <returns>应用 构造 静态扩展。</returns>
        public static AppBuilder SetWeixinMessageProcessConfigByJsonFile(this AppBuilder appBuilder, string configFilePath)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(configFilePath))
                throw new StringNullOrEmptyException(nameof(configFilePath));

            #endregion

            appBuilder.SetWeixinMessageConfig(MessageProcessConfigurationBuilder.BuildByJsonFile(configFilePath));
            return appBuilder;
        }

        #endregion
    }
}
