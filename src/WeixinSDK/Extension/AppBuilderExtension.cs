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
using Wlitsoft.Framework.WeixinSDK.Core;
using Wlitsoft.Framework.WeixinSDK.TokenService;

namespace Wlitsoft.Framework.WeixinSDK.Extension
{
    /// <summary>
    /// 应用 构造 静态扩展类。
    /// </summary>
    public static class AppBuilderExtension
    {

        #region 设置微信开发配置

        /// <summary>
        /// 设置微信开发配置 <see cref="DevConfiguration"/>。
        /// </summary>
        /// <param name="appBuilder">应用构造。</param>
        /// <param name="config">一个 <see cref="DevConfiguration"/> 对象。</param>
        /// <returns>应用 构造 静态扩展。</returns>
        public static AppBuilder SetWeixinDevConfig(this AppBuilder appBuilder, DevConfiguration config)
        {
            #region 参数校验

            if (config == null)
                throw new ObjectNullException(nameof(config));

            #endregion

            WeixinApp.DevConfig = config;
            return appBuilder;
        }

        #endregion

        #region 设置微信消息处理配置

        /// <summary>
        /// 设置微信消息处理配置 <see cref="MessageProcessConfiguration"/>。
        /// </summary>
        /// <param name="appBuilder">应用构造。</param>
        /// <param name="config">一个 <see cref="MessageProcessConfiguration"/> 对象。</param>
        /// <returns>应用 构造 静态扩展。</returns>
        public static AppBuilder SetWeixinMessageConfig(this AppBuilder appBuilder, MessageProcessConfiguration config)
        {
            #region 参数校验

            if (config == null)
                throw new ObjectNullException(nameof(config));

            #endregion

            WeixinApp.MessageProcessConfig = config;
            return appBuilder;
        }

        #endregion

        #region 设置微信日志记录者

        /// <summary>
        /// 设置微信日志记录者。
        /// </summary>
        /// <param name="appBuilder">应用构造。</param>
        /// <param name="name">日志记录者名称。</param>
        public static AppBuilder SetWeixinLogger(this AppBuilder appBuilder, string name)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(name))
                throw new StringNullOrEmptyException(nameof(name));

            #endregion

            //设置日志记录者。
            WeixinApp.Logger = App.LoggerService.GetLogger(name);

            return appBuilder;
        }

        #endregion

        #region 设置微信令牌服务

        /// <summary>
        /// 设置微信令牌服务。
        /// </summary>
        /// <param name="appBuilder">应用构造。</param>
        /// <param name="tokenService">令牌服务。</param>
        public static AppBuilder SetWeixinTokenService(this AppBuilder appBuilder, ITokenService tokenService)
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
