/**********************************************************************************************************************
 * 描述：
 *      获得令牌结果模型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月07日	 新建
 * 
 *********************************************************************************************************************/
using Newtonsoft.Json;

namespace Wlitsoft.Framework.WeixinSDK.Model.BaseApiModel
{
    /// <summary>
    /// 获得令牌结果模型。
    /// </summary>
    public class GetTickectResultModel : ResultModelBase
    {
        /// <summary>
        /// 获取或设置 票证。
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }

        /// <summary>
        /// 获取或设置 凭证有效时间，单位：秒。
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
