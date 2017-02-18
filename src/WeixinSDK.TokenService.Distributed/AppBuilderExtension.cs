/**********************************************************************************************************************
 * 描述：
 *      应用 构造 静态扩展类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年02月18日	 新建
 * 
 *********************************************************************************************************************/

using System;
using Wlitsoft.Framework.Common.Exception;

namespace Wlitsoft.Framework.WeixinSDK.TokenService.Distributed
{
    /// <summary>
    /// 应用 构造 静态扩展类。
    /// </summary>
    public class AppBuilderExtension
    {
        /// <summary>
        /// 设置分布式缓存令牌服务。
        /// </summary>
        /// <param name="cacheKeyPrefix">缓存键值前缀。</param>
        /// <param name="cacheExpiredTime">缓存过期时间。</param>
        public static void SetDistributedTokenService(string cacheKeyPrefix, TimeSpan cacheExpiredTime)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(cacheKeyPrefix))
                throw new StringNullOrEmptyException(nameof(cacheKeyPrefix));

            #endregion

            if (cacheExpiredTime > TimeSpan.FromSeconds(7200))
                throw new Exception("缓存的过期时间不能大于 7200 秒。");

            DistributedTokenService.CacheKeyPrefix = cacheKeyPrefix;
            DistributedTokenService.CacheExpiredTime = cacheExpiredTime;
        }
    }
}
