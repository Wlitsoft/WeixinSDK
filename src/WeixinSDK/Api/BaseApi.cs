/**********************************************************************************************************************
 * 描述：
 *      基础支持 Api。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 * 
 *********************************************************************************************************************/

using Wlitsoft.Framework.WeixinSDK.Extension;
using Wlitsoft.Framework.WeixinSDK.Model.BaseApiModel;

namespace Wlitsoft.Framework.WeixinSDK.Api
{
    /// <summary>
    /// 基础支持 Api。
    /// </summary>
    public static class BaseApi
    {
        #region 获取AccessToken

        /// <summary>
        /// 获取AccessToken。
        /// </summary>
        /// <returns>令牌字符串。</returns>
        public static GetAccessTokenResultModel GetAccessToken()
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={WeixinApp.DevConfig.AppID}&secret={WeixinApp.DevConfig.AppSecret}";
            return url.GetApiInvokeResult<GetAccessTokenResultModel>();
        }

        #endregion

        #region 获取jsapi_ticket

        /// <summary>
        /// 获取jsapi_ticket。
        /// </summary>
        /// <param name="accessToken">公众号令牌，由 <see cref="BaseApi.GetAccessToken()"/> 获取。</param>
        /// <returns>js接口票证。</returns>
        public static GetTickectResultModel GetTickect(string accessToken)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={accessToken}&type=jsapi";
            return url.GetApiInvokeResult<GetTickectResultModel>();
        }

        #endregion
    }
}
