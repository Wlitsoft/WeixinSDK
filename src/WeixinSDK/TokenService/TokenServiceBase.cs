/**********************************************************************************************************************
 * 描述：
 *      令牌服务基类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 * 
 *********************************************************************************************************************/

using System;
using Wlitsoft.Framework.WeixinSDK.Api;
using Wlitsoft.Framework.WeixinSDK.Model.BaseApiModel;

namespace Wlitsoft.Framework.WeixinSDK.TokenService
{
    /// <summary>
    /// 令牌服务基类。
    /// </summary>
    public abstract class TokenServiceBase
    {
        /// <summary>
        /// 获取令牌。
        /// <para>刷新令牌后，JSTickect会自动刷新。</para>
        /// </summary>
        /// <param name="isForceRefresh">是否强制刷新。</param>
        /// <returns>令牌。</returns>
        public abstract string GetToken(bool isForceRefresh = false);

        /// <summary>
        /// 获取Js接口票证。
        /// </summary>
        /// <param name="isForceRefresh">是否强制刷新。</param>
        /// <returns>Js接口票证</returns>
        public abstract string GetJsTickect(bool isForceRefresh = false);

        /// <summary>
        /// 基础接口 - 获取令牌。
        /// </summary>
        /// <returns>令牌。</returns>
        protected string BaseApiGetAccessToken()
        {
            GetAccessTokenModel result = BaseApi.GetAccessToken();
            if (string.IsNullOrEmpty(result.ErrorMessage))
                return result.AccessToken;
            throw new Exception(string.Format("获取AccessToken失败，错误信息：{0}", result.ResponseResultString));
        }

        /// <summary>
        /// Js Api 获取jsapi_ticket。
        /// </summary>
        /// <param name="token">令牌。</param>
        /// <returns>js api 票证。</returns>
        protected string JSApiGetTickect(string token)
        {
            throw new NotImplementedException();
        }
    }
}
