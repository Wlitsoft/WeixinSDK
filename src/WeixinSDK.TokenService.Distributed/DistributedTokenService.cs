/**********************************************************************************************************************
 * 描述：
 *      分布式令牌服务。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年02月18日	 新建
 * 
 *********************************************************************************************************************/

using System;
using Wlitsoft.Framework.Common.Core;

namespace Wlitsoft.Framework.WeixinSDK.TokenService.Distributed
{
    /// <summary>
    /// 分布式令牌服务。
    /// </summary>
    public class DistributedTokenService : TokenServiceBase
    {
        #region 内部属性

        /// <summary>
        /// 缓存键值前缀。
        /// </summary>
        internal static string CacheKeyPrefix;

        /// <summary>
        /// 缓存过期时间。
        /// </summary>
        internal static TimeSpan CacheExpiredTime;

        #endregion

        #region 私有属性

        /// <summary>
        /// 分布式缓存。
        /// </summary>
        private IDistributedCache _cache;

        /// <summary>
        /// 令牌缓存键值。
        /// </summary>
        private readonly string _tokenCacheKey;

        /// <summary>
        /// Js接口票证缓存键值。
        /// </summary>
        private readonly string _jsTickectCacheKey;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="DistributedTokenService"/> 的新实例。
        /// </summary>
        public DistributedTokenService(IDistributedCache cache)
        {
            _cache = cache;
            this._tokenCacheKey = $"{CacheKeyPrefix}_{WeixinApp.DevConfig.AppID}_Token";
            this._jsTickectCacheKey = $"{CacheKeyPrefix}_{WeixinApp.DevConfig.AppID}_JsTickect";
        }

        #endregion

        #region TokenServiceBase 成员

        /// <summary>
        /// 获取令牌。
        /// <para>刷新令牌后，JSTickect会自动刷新。</para>
        /// </summary>
        /// <param name="isForceRefresh">是否强制刷新。</param>
        /// <returns>令牌。</returns>
        public override string GetToken(bool isForceRefresh = false)
        {
            string token = this._cache.Get<string>(this._tokenCacheKey);
            if (string.IsNullOrEmpty(token) || isForceRefresh)
            {
                token = base.BaseApiGetAccessToken();
                this._cache.Set<string>(this._tokenCacheKey, token, CacheExpiredTime);

                #region 强制刷新 Js接口票证

                this.GetJsTickect(true);
                WeixinApp.Logger.Info("DistributedTokenService.GetToken => 强制刷新 js 令牌");

                #endregion

                WeixinApp.Logger.Info($"DistributedTokenService.GetTokenv => 将获取到的Token设置到分布式缓存中，isForceRefresh={isForceRefresh}Token为:{token}");
            }
            return token;
        }

        /// <summary>
        /// 获取Js接口票证。
        /// </summary>
        /// <param name="isForceRefresh">是否强制刷新。</param>
        /// <returns>Js接口票证</returns>
        public override string GetJsTickect(bool isForceRefresh = false)
        {
            string tickect = this._cache.Get<string>(this._jsTickectCacheKey);
            WeixinApp.Logger.Info($"DistributedTokenService.GetJsTickect => 从分布式缓存中获取到的JsTickect为:{tickect}");
            if (string.IsNullOrEmpty(tickect) || isForceRefresh)
            {
                tickect = base.BaseApiGetTickect(this.GetToken());
                this._cache.Set<string>(this._jsTickectCacheKey, tickect, CacheExpiredTime);
                WeixinApp.Logger.Info($"DistributedTokenService.GetJsTickect => 将获取到的JsTickect设置到分布式缓存中，isForceRefresh={isForceRefresh}JsTickect为:{tickect}");
            }
            return tickect;
        }

        #endregion
    }
}
