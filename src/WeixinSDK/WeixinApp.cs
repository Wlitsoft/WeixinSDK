/**********************************************************************************************************************
 * 描述：
 *      微信应用。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 * 
 *********************************************************************************************************************/

using Wlitsoft.Framework.Common;
using Wlitsoft.Framework.Common.Core;
using Wlitsoft.Framework.Common.Log;
using Wlitsoft.Framework.Common.Serializer.JsonNet;
using Wlitsoft.Framework.WeixinSDK.Configuration;
using Wlitsoft.Framework.WeixinSDK.TokenService;

namespace Wlitsoft.Framework.WeixinSDK
{
    /// <summary>
    /// 微信应用。
    /// </summary>
    public class WeixinApp
    {

        /// <summary>
        /// 日志记录者名称。
        /// </summary>
        internal static string LoggerName;

        /// <summary>
        /// 开发配置。
        /// </summary>
        internal static DevConfiguration DevConfig;

        /// <summary>
        /// 令牌服务。
        /// </summary>
        internal static TokenServiceBase TokenService;

        /// <summary>
        /// 日志记录者。
        /// </summary>
        public static ILog GetLogger()
        {
            if (string.IsNullOrEmpty(LoggerName))
                return new EmptyLogger();
            return App.LoggerService.GetLogger(LoggerName);
        }

        /// <summary>
        /// 初始化 <see cref="WeixinApp"/> 类的静态实例。
        /// </summary>
        static WeixinApp()
        {
            App.Builder.AddSerializer(SerializeType.Json, new JsonNetJsonSerializer());
        }
    }
}
