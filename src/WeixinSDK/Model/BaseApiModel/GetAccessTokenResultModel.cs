/**********************************************************************************************************************
 * 描述：
 *      获取公众号令牌 结果模型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 * 
 *********************************************************************************************************************/
using Newtonsoft.Json;

namespace Wlitsoft.Framework.WeixinSDK.Model.BaseApiModel
{
    /// <summary>
    /// 获取公众号令牌 结果模型。
    /// </summary>
    public class GetAccessTokenResultModel : ResultModelBase
    {
        /// <summary>
        /// 获取或设置 凭证。
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 获取或设置 凭证有效时间，单位：秒。
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
