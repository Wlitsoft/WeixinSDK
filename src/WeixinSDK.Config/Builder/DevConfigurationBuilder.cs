/**********************************************************************************************************************
 * 描述：
 *      开发配置构造者。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 *      作者：李亮  时间：2017年01月07日	 编辑 添加 PayConfig 相关代码。
 *********************************************************************************************************************/

using System;
using System.Configuration;
using System.IO;
using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.WeixinSDK.Configuration;

namespace Wlitsoft.Framework.WeixinSDK.Config.Builder
{
    /// <summary>
    /// 开发配置构造者。
    /// </summary>
    public static class DevConfigurationBuilder
    {
        /// <summary>
        /// 根据 AppSettings 构造。
        /// </summary>
        /// <returns>一个 <see cref="DevConfiguration"/> 实例。</returns>
        public static DevConfiguration BuildByAppSettings()
        {
            return new DevConfiguration()
            {
                AppID = ConfigurationManager.AppSettings["WeixinSDK.Dev.AppID"],
                AppSecret = ConfigurationManager.AppSettings["WeixinSDK.Dev.AppSecret"],
                Token = ConfigurationManager.AppSettings["WeixinSDK.Dev.Token"],
                EncodingAESKey = ConfigurationManager.AppSettings["WeixinSDK.Dev.EncodingAESKey"],
                JSApiDebug = Convert.ToBoolean(ConfigurationManager.AppSettings["WeixinSDK.Dev.JSApiDebug"] ?? "false"),
                PayConfig = new PayConfiguration()
                {
                    MchId = ConfigurationManager.AppSettings["WeixinSDK.Dev.Pay.MchId"],
                    PartnerKey = ConfigurationManager.AppSettings["WeixinSDK.Dev.Pay.PartnerKey"]
                }
            };
        }

        /// <summary>
        /// 根据 json 配置文件构造。
        /// </summary>
        /// <param name="configFilePath">配置文件路径.</param>
        /// <returns>一个 <see cref="DevConfiguration"/> 实例。</returns>
        public static DevConfiguration BuildByJsonFile(string configFilePath)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(configFilePath))
                throw new StringNullOrEmptyException(nameof(configFilePath));

            #endregion

            string fileText = File.ReadAllText(configFilePath);
            return fileText.ToJsonObject<DevConfiguration>();
        }
    }
}
