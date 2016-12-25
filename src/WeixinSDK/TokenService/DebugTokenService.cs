/**********************************************************************************************************************
 * 描述：
 *      调试令牌服务。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 *      作者：李亮  时间：2016年12月25日	 编辑  将 TokenServiceBase 抽象类 改成 ITokenService 接口。
 *********************************************************************************************************************/

using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.TokenService
{
    /// <summary>
    /// 调试令牌服务。
    /// </summary>
    public sealed class DebugTokenService : ITokenService
    {

        #region 公共属性

        /// <summary>
        /// 获取或设置 令牌。
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 获取或设置 Js接口票证。
        /// </summary>
        public string JsTickect { get; set; }

        #endregion

        #region ITokenService 成员

        /// <summary>
        /// 获取令牌。
        /// <para>刷新令牌后，JSTickect会自动刷新。</para>
        /// </summary>
        /// <param name="isForceRefresh">是否强制刷新。</param>
        /// <returns>令牌。</returns>
        public string GetToken(bool isForceRefresh = false)
        {
            return this.Token;
        }

        /// <summary>
        /// 获取Js接口票证。
        /// </summary>
        /// <param name="isForceRefresh">是否强制刷新。</param>
        /// <returns>Js接口票证</returns>
        public string GetJsTickect(bool isForceRefresh = false)
        {
            return this.JsTickect;
        }

        #endregion
    }
}
