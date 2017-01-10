/**********************************************************************************************************************
 * 描述：
 *      应用 构造 静态扩展类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 *      作者：李亮  时间：2017年01月07日	 编辑 添加 “设置支付接口调用所使用的证书” 方法。
 *********************************************************************************************************************/
using System.Security.Cryptography.X509Certificates;
using Wlitsoft.Framework.Common;
using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.WeixinSDK.Configuration;
using Wlitsoft.Framework.WeixinSDK.Core;

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

        #region 设置支付接口调用所使用的证书

        /// <summary>
        /// 设置支付接口调用所使用的证书。
        /// </summary>
        /// <param name="appBuilder">应用构造。</param>
        /// <param name="certStoreLocation">证书存储区的位置。</param>
        /// <param name="certStoreName">证书存储区的名称。</param>
        /// <param name="certSubjectName">证书的主题名称。</param>
        /// <returns>应用构造。</returns>
        public static AppBuilder SetPayApiCertificate(this AppBuilder appBuilder, StoreLocation certStoreLocation, StoreName certStoreName, string certSubjectName)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(certSubjectName))
                throw new StringNullOrEmptyException(nameof(certSubjectName));

            #endregion

            X509Store store = new X509Store(certStoreName, certStoreLocation);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindBySubjectName, certSubjectName, false);
            if (certs.Count == 0)
                throw new System.Exception($"未找到指定的证书：certSubjectName:“{certSubjectName}”");

            appBuilder.SetPayApiCertificate(certs[0]);
            return appBuilder;
        }

        /// <summary>
        /// 设置支付接口调用所使用的证书。
        /// </summary>
        /// <param name="appBuilder">应用构造。</param>
        /// <param name="certificate">证书。</param>
        /// <returns>应用构造。</returns>
        public static AppBuilder SetPayApiCertificate(this AppBuilder appBuilder, X509Certificate certificate)
        {
            #region 参数校验

            if (certificate == null)
                throw new ObjectNullException(nameof(certificate));

            #endregion

            WeixinApp.PayApiCertificate = certificate;
            return appBuilder;
        }

        #endregion
    }
}
