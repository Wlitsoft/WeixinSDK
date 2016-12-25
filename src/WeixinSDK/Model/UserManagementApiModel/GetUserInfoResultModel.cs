/**********************************************************************************************************************
 * 描述：
 *      获取用户基本信息 结果模型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/
using System;
using Newtonsoft.Json;
using Wlitsoft.Framework.Common.Extension;

namespace Wlitsoft.Framework.WeixinSDK.Model.UserManagementApiModel
{
    /// <summary>
    /// 获取用户基本信息 结果模型。
    /// </summary>
    public class GetUserInfoResultModel : ResultModelBase
    {

        /// <summary>
        /// 获取或设置 用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息。 
        /// </summary>
        [JsonProperty("subscribe")]
        public int Subscribe { get; set; }

        /// <summary>
        /// 获取 用户是否订阅该公众号。
        /// </summary>
        [JsonIgnore]
        public bool IsSubscribe
        {
            get { return this.Subscribe == 1; }
        }

        /// <summary>
        /// 获取或设置 用户的标识，对当前公众号唯一。
        /// </summary>
        [JsonProperty("openid")]
        public string OpenID { get; set; }

        /// <summary>
        /// 获取或设置 用户的昵称。
        /// </summary>
        [JsonProperty("nickname")]
        public string NickName { get; set; }

        /// <summary>
        /// 获取或设置 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知。
        /// </summary>
        [JsonProperty("sex")]
        public int Sex { get; set; }

        /// <summary>
        /// 获取或设置 用户所在城市。
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 获取或设置 用户所在国家。
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// 获取或设置 用户所在省份。
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 获取或设置 用户的语言，简体中文为zh_CN 。
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// 获取或设置 用户头像。
        /// <para>最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空。若用户更换头像，原有头像URL将失效。</para>
        /// </summary>
        [JsonProperty("headimgurl")]
        public string HeadImgUrl { get; set; }

        /// <summary>
        /// 获取或设置 用户关注时间，为时间戳。
        /// <para>如果用户曾多次关注，则取最后关注时间。</para>
        /// </summary>
        [JsonProperty("subscribe_time")]
        public long SubscribeTime { get; set; }

        /// <summary>
        /// 获取或设置 用户关注时间。
        /// </summary>
        public DateTime SubscribeDateTime => this.SubscribeTime.ToDateTime();

        /// <summary>
        /// 获取或设置 用户 UnionID 。
        /// <para>只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段</para>
        /// </summary>
        [JsonProperty("unionid")]
        public string UnionID { get; set; }

        /// <summary>
        /// 获取或设置 公众号运营者对粉丝的备注。
        /// <para>公众号运营者可在微信公众平台用户管理界面对粉丝添加备注。</para>
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 获取或设置 用户所在的分组ID。
        /// </summary>
        [JsonProperty("groupid")]
        public int GroupID { get; set; }
    }
}
