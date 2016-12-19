/**********************************************************************************************************************
 * 描述：
 *      开发配置构造者。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 * 
 *********************************************************************************************************************/

using System.Configuration;
using System.IO;
using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.Common.Extension;

namespace Wlitsoft.Framework.WeixinSDK.Configuration
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
                AppSecret = ConfigurationManager.AppSettings["WeixinSDK.Dev.AppSecret"]
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
