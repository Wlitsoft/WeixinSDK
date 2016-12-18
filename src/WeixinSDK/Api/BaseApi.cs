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
        /// <summary>
        /// 获取AccessToken。
        /// </summary>
        /// <returns>令牌字符串。</returns>
        public static GetAccessTokenModel GetAccessToken()
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={WeixinApp.DevConfig.AppID}&secret={WeixinApp.DevConfig.AppSecret}";
            return url.GetJson<GetAccessTokenModel>();
        }
    }
}
