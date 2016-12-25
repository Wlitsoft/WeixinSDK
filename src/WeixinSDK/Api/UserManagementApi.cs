/**********************************************************************************************************************
 * 描述：
 *      用户管理 Api。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/
using System;
using System.Collections.Generic;
using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.WeixinSDK.Extension;
using Wlitsoft.Framework.WeixinSDK.Model.UserManagementApiModel;

namespace Wlitsoft.Framework.WeixinSDK.Api
{
    /// <summary>
    /// 用户管理 Api。
    /// </summary>
    public class UserManagementApi
    {

        #region 获取用户基本信息（包括UnionID机制）

        /// <summary>
        /// 获取用户基本信息（包括UnionID机制）。
        /// </summary>
        /// <param name="openId">普通用户的标识，对当前公众号唯一。</param>
        /// <returns>获取用户基本信息 结果模型。</returns>
        public static GetUserInfoResultModel GetUserInfo(string openId)
        {
            // ReSharper disable once IntroduceOptionalParameters.Global
            return GetUserInfo(openId, "zh_CN");
        }

        /// <summary>
        /// 获取用户基本信息（包括UnionID机制）。
        /// </summary>
        /// <param name="openId">普通用户的标识，对当前公众号唯一。</param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语。</param>
        /// <returns>获取用户基本信息 结果模型。</returns>
        public static GetUserInfoResultModel GetUserInfo(string openId, string lang)
        {
            #region 参数校验

            if (string.IsNullOrEmpty(openId))
                throw new StringNullOrEmptyException(nameof(openId));

            if (string.IsNullOrEmpty(lang))
                throw new StringNullOrEmptyException(nameof(lang));

            #endregion

            string url = $"https://api.weixin.qq.com/cgi-bin/user/info?access_token={WeixinApp.TokenService.GetToken()}&openid={openId}&lang={lang}";
            return url.GetJson<GetUserInfoResultModel>();
        }

        #endregion

        #region 批量获取用户基本信息

        /// <summary>
        /// 批量获取用户基本信息。
        /// </summary>
        /// <param name="openIds">普通用户的标识，对当前公众号唯一。</param>
        /// <returns>批量获取用户基本信息 结果对象。</returns>
        public static GetUserInfosResultModel GetUserInfos(List<string> openIds)
        {
            // ReSharper disable once IntroduceOptionalParameters.Global
            return GetUserInfos(openIds, "zh_CN");
        }

        /// <summary>
        /// 批量获取用户基本信息。
        /// </summary>
        /// <param name="openIds">普通用户的标识，对当前公众号唯一。</param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语。</param>
        /// <returns>批量获取用户基本信息 结果对象。</returns>
        public static GetUserInfosResultModel GetUserInfos(List<string> openIds, string lang)
        {
            #region 参数校验

            if (openIds == null)
                throw new StringNullOrEmptyException(nameof(openIds));

            if (openIds.Count > 100)
                throw new Exception("一次不能大于100");

            if (string.IsNullOrEmpty(lang))
                throw new StringNullOrEmptyException(nameof(lang));

            #endregion

            string url = $"https://api.weixin.qq.com/cgi-bin/user/info/batchget?access_token={WeixinApp.TokenService.GetToken()}";

            #region 组织数据

            List<object> userList = new List<object>();
            foreach (string openId in openIds)
            {
                userList.Add(new { openid = openId, lang = lang });
            }

            var postdata = new
            {
                user_list = userList
            };

            #endregion

            return url.PostJson<GetUserInfosResultModel>(postdata);
        }

        #endregion
    }
}
