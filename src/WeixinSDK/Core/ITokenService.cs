/**********************************************************************************************************************
 * 描述：
 *      令牌服务接口。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 * 
 *********************************************************************************************************************/

namespace Wlitsoft.Framework.WeixinSDK.Core
{
    /// <summary>
    /// 令牌服务接口。
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// 获取令牌。
        /// <para>刷新令牌后，JSTickect会自动刷新。</para>
        /// </summary>
        /// <param name="isForceRefresh">是否强制刷新。</param>
        /// <returns>令牌。</returns>
        string GetToken(bool isForceRefresh = false);

        /// <summary>
        /// 获取Js接口票证。
        /// </summary>
        /// <param name="isForceRefresh">是否强制刷新。</param>
        /// <returns>Js接口票证</returns>
        string GetJsTickect(bool isForceRefresh = false);
    }
}
