/**********************************************************************************************************************
 * 描述：
 *      网页授权的访问令牌 结果模型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/
using Newtonsoft.Json;

namespace Wlitsoft.Framework.WeixinSDK.Model.OAuth2ApiModel
{
    /// <summary>
    /// 网页授权的访问令牌 结果模型。
    /// </summary>
    public class OAuthAccessTokenResultModel : ResultModelBase
    {

        /// <summary>
        /// 获取或设置 网页授权接口调用凭证。
        /// <para>注意：此access_token与基础支持的access_token不同。</para>
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 获取或设置 access_token接口调用凭证超时时间，单位（秒）。
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// 获取或设置 用户刷新access_token。
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// 获取或设置 用户唯一标识。
        /// <para>请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID。</para>
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 获取或设置 用户授权的作用域，使用逗号（,）分隔。
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// 获取或设置 用户唯一标识（UnionID机制）。
        /// <para>只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。</para>
        /// </summary>
        [JsonProperty("unionid")]
        public string UnionId { get; set; }

    }
}
