/**********************************************************************************************************************
 * 描述：
 *      批量获取用户基本信息 结果模型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Wlitsoft.Framework.WeixinSDK.Model.UserManagementApiModel
{
    /// <summary>
    /// 批量获取用户基本信息 结果模型。
    /// </summary>
    public class GetUserInfosResultModel : ResultModelBase
    {
        /// <summary>
        /// 获取或设置 用户基本信息列表。
        /// </summary>
        [JsonProperty("user_info_list")]
        public List<GetUserInfoResultModel> UserInfoList { get; set; }
    }
}