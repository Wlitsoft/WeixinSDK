/**********************************************************************************************************************
 * 描述：
 *      获取用户信息 结果模型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/
using Newtonsoft.Json;

namespace Wlitsoft.Framework.WeixinSDK.Model.OAuth2ApiModel
{
    /// <summary>
    /// 获取用户信息 结果模型。
    /// </summary>
    public class GetOAuthUserInfoResultModel : ResultModelBase
    {
        /// <summary>
        /// 获取或设置 用户的唯一标识。
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 获取或设置 用户昵称。
        /// </summary>
        [JsonProperty("nickname")]
        public string NickName { get; set; }

        /// <summary>
        /// 获取或设置 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知。
        /// </summary>
        [JsonProperty("sex")]
        public int Sex { get; set; }

        /// <summary>
        /// 获取或设置 用户个人资料填写的省份。
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 获取或设置 普通用户个人资料填写的城市。
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 获取或设置 国家，如中国为CN。
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// 获取或设置 用户头像。
        /// <para></para>
        /// </summary>
        [JsonProperty("headimgurl")]
        public string HeadImgUrl { get; set; }

        /// <summary>
        /// 获取或设置 用户特权信息。
        /// <para>json 数组，如微信沃卡用户为（chinaunicom）。</para>
        /// </summary>
        [JsonProperty("privilege")]
        public string[] Privilege { get; set; }

        /// <summary>
        /// 获取或设置 用户唯一标识（UnionID机制）。
        /// <para>只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。</para>
        /// </summary>
        [JsonProperty("unionid")]
        public string UnionId { get; set; }

    }
}
