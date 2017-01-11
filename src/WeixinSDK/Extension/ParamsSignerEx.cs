/**********************************************************************************************************************
 * 描述：
 *      参数签名扩展。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月11日	 新建
 * 
 *********************************************************************************************************************/

using System.Collections.Generic;
using Wlitsoft.Framework.Common.Security;

namespace Wlitsoft.Framework.WeixinSDK.Extension
{
    /// <summary>
    /// 参数签名扩展。
    /// </summary>
    public static class ParamsSignerEx
    {
        /// <summary>
        /// 获得签名。
        /// </summary>
        /// <param name="dic">要签名的参数。</param>
        /// <returns>签名。</returns>
        public static string GetSign(Dictionary<string, string> dic)
        {
            ParamsSigner signer = new ParamsSigner(WeixinApp.DevConfig.PayConfig.PartnerKey) { Params = dic };
            return signer.GetSign();
        }
    }
}
