/**********************************************************************************************************************
 * 描述：
 *      授权 Api。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/
using System;
using System.Linq;
using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.WeixinSDK.Extension;
using Wlitsoft.Framework.WeixinSDK.Model.OAuth2ApiModel;

namespace Wlitsoft.Framework.WeixinSDK.Api
{
    /// <summary>
    /// 授权 Api。
    /// </summary>
    public static class OAuth2Api
    {
        #region 获取用户同意授权后的Code

        /// <summary>
        /// 获取用户同意授权后的Code。
        /// </summary>
        /// <param name="redirectUrl">授权后重定向的回调链接全地址。</param>
        /// <param name="state">重定向后会带上state参数，开发者可以填写a-zA-Z0-9的参数值，最多128字节。</param>
        /// <param name="scopes">应用授权作用域。</param>
        /// <returns>获取到Code。</returns>
        public static string GetUserAgreeAuthCode(string redirectUrl, string state, params OAuthScope[] scopes)
        {
            string scopeStr = scopes.Aggregate(string.Empty, (current, scope) => current + $"{scope.ToString()},").TrimEnd(',');
            return $"https://open.weixin.qq.com/connect/oauth2/authorize?appid={WeixinApp.DevConfig.AppID}&redirect_uri={redirectUrl}&response_type=code&scope={scopeStr}&state={state}#wechat_redirect";
        }

        #endregion

        #region 获取网页授权的访问令牌

        /// <summary>
        /// 获取网页授权的访问令牌。
        /// </summary>
        /// <param name="code">用户同意授权后的Code。</param>
        /// <returns>网页授权的访问令牌结果对象。</returns>
        public static OAuthAccessTokenResultModel GetAccessToken(string code)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(code))
                throw new StringNullOrEmptyException(nameof(code));

            #endregion

            string url = $"https://api.weixin.qq.com/sns/oauth2/access_token?appid={WeixinApp.DevConfig.AppID}&secret={WeixinApp.DevConfig.AppSecret}&code={code}&grant_type=authorization_code";
            return url.GetJson<OAuthAccessTokenResultModel>();
        }

        #endregion

        #region 获取用户信息

        /// <summary>
        /// 获取用户信息。
        /// </summary>
        /// <param name="accessToken">网页授权接口调用凭证。</param>
        /// <param name="openId">要获取的用户的唯一标识。</param>
        /// <param name="lang">语言。</param>
        /// <returns>获取用户信息结果对象。</returns>
        public static GetOAuthUserInfoResultModel GetOAuthUserInfo(string accessToken, string openId, string lang = "zh_CN")
        {
            #region 参数校验

            if (string.IsNullOrEmpty(accessToken))
                throw new StringNullOrEmptyException(nameof(accessToken));

            if (string.IsNullOrEmpty(openId))
                throw new StringNullOrEmptyException(nameof(openId));

            if (string.IsNullOrEmpty(lang))
                throw new ArgumentNullException(nameof(lang));

            #endregion

            string url = $"https://api.weixin.qq.com/sns/userinfo?access_token={accessToken}&openid={openId}&lang=zh_CN";
            return url.GetJson<GetOAuthUserInfoResultModel>();
        }

        #endregion

    }
}
