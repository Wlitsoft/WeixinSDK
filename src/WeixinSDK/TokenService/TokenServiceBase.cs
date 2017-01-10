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
using Wlitsoft.Framework.WeixinSDK.Core;
using Wlitsoft.Framework.WeixinSDK.Model.BaseApiModel;

namespace Wlitsoft.Framework.WeixinSDK.TokenService
{
    /// <summary>
    /// 令牌服务基类。
    /// </summary>
    public abstract class TokenServiceBase : ITokenService
    {
        #region ITokenService 成员

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

        #endregion

        /// <summary>
        /// 基础接口 - 获取令牌。
        /// </summary>
        /// <returns>令牌。</returns>
        protected string BaseApiGetAccessToken()
        {
            GetAccessTokenResultModel result = BaseApi.GetAccessToken();
            if (result.ErrorCode == 0)
            {
                WeixinApp.Logger.Info($"TokenServiceBase_GetAccessToken: 当前 Token:{result.AccessToken}");
                return result.AccessToken;
            }

            string errMsg = $"TokenServiceBase_GetAccessToken: 获取 Token 失败，错误信息：{result.ResponseResultString}";
            WeixinApp.Logger.Fatal(errMsg);
            throw new Exception(errMsg);
        }

        /// <summary>
        /// Js Api 获取jsapi_ticket。
        /// </summary>
        /// <param name="token">令牌。</param>
        /// <returns>js api 票证。</returns>
        protected string BaseApiGetTickect(string token)
        {
            GetTickectResultModel result = BaseApi.GetTickect(token);
            if (result.ErrorCode == 0)
            {
                WeixinApp.Logger.Info($"TokenServiceBase_GetTickect: 当前 Tickect:{result.Ticket}");
                return result.Ticket;
            }

            string errMsg = $"TokenServiceBase_GetTickect: 获取 Tickect 失败，错误信息：{result.ResponseResultString}";
            WeixinApp.Logger.Fatal(errMsg);
            throw new Exception(errMsg);
        }
    }
}
