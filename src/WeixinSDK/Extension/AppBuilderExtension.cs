/**********************************************************************************************************************
 * 描述：
 *      应用 构造 静态扩展类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 * 
 *********************************************************************************************************************/

using Wlitsoft.Framework.Common;
using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.WeixinSDK.Configuration;
using Wlitsoft.Framework.WeixinSDK.TokenService;

namespace Wlitsoft.Framework.WeixinSDK.Extension
{
    /// <summary>
    /// 应用 构造 静态扩展类。
    /// </summary>
    public static class AppBuilderExtension
    {

        #region 以项目配置文件 AppSettings 配置节点的方式设置 log4net 日志记录者

        /// <summary>
        /// 以项目配置文件 AppSettings 配置节点的方式设置 log4net 日志记录者。
        /// </summary>
        /// <param name="appBuilder">应用构造。</param>
        public static AppBuilder SetWeixinDevConfigByAppSettings(this AppBuilder appBuilder)
        {
            WeixinApp.DevConfig = DevConfigurationBuilder.BuildByAppSettings();
            return appBuilder;
        }

        #endregion

        #region 以 json 配置文件的方式设置 log4net 日志记录者

        /// <summary>
        /// 以 json 配置文件的方式设置 log4net 日志记录者。
        /// </summary>
        /// <param name="appBuilder">应用构造。</param>
        /// <param name="configFilePath">配置文件路径。</param>
        public static AppBuilder SetWeixinDevConfigByJsonFile(this AppBuilder appBuilder, string configFilePath)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(configFilePath))
                throw new StringNullOrEmptyException(nameof(configFilePath));

            #endregion

            WeixinApp.DevConfig = DevConfigurationBuilder.BuildByJsonFile(configFilePath);
            return appBuilder;
        }

        #endregion

        #region 设置微信日志记录者名称

        /// <summary>
        /// 设置微信日志记录者名称。
        /// </summary>
        /// <param name="appBuilder">应用构造。</param>
        /// <param name="name">日志记录者名称。</param>
        public static AppBuilder SetWeixinLoggerName(this AppBuilder appBuilder, string name)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(name))
                throw new StringNullOrEmptyException(nameof(name));

            #endregion

            WeixinApp.LoggerName = name;
            return appBuilder;
        }

        #endregion

        #region 设置令牌服务

        /// <summary>
        /// 设置令牌服务。
        /// </summary>
        /// <param name="appBuilder">应用构造。</param>
        /// <param name="tokenService">令牌服务。</param>
        public static AppBuilder SetTokenService(this AppBuilder appBuilder, TokenServiceBase tokenService)
        {
            #region 参数校验

            if (tokenService == null)
                throw new ObjectNullException(nameof(tokenService));

            #endregion

            WeixinApp.TokenService = tokenService;
            return appBuilder;
        }

        #endregion

    }
}
