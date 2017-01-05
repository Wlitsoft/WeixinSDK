/**********************************************************************************************************************
 * 描述：
 *      检测签名。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月04日	 新建
 * 
 *********************************************************************************************************************/
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Wlitsoft.Framework.WeixinSDK.Message.Security
{
    /// <summary>
    /// 检测签名。
    /// </summary>
    public class CheckSignature
    {
        #region 检查签名是否正确

        /// <summary>
        /// 检查签名是否正确。
        /// </summary>
        /// <param name="signature">微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数。</param>
        /// <param name="timestamp">时间戳。</param>
        /// <param name="nonce">随机数。</param>
        /// <returns>如果返回 <c>true</c> 标识该请求来源于微信。</returns>
        public static bool Check(string signature, string timestamp, string nonce)
        {
            string token = WeixinApp.DevConfig.Token;
            var arr = new[] { token, timestamp, nonce }.OrderBy(z => z).ToArray();
            var arrString = string.Join("", arr);
            var sha1 = SHA1.Create();
            var sha1Arr = sha1.ComputeHash(Encoding.UTF8.GetBytes(arrString));
            StringBuilder enText = new StringBuilder();
            foreach (var b in sha1Arr)
            {
                enText.AppendFormat("{0:x2}", b);
            }

            if (signature != enText.ToString())
            {
                //写日志。
                WeixinApp.Logger.Error("CheckSignature Error！");
                return false;
            }
            return true;
        }

        #endregion

        #region 执行签名校验

        /// <summary>
        /// 执行签名校验。
        /// </summary>
        /// <param name="signature">微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数。</param>
        /// <param name="timestamp">时间戳。</param>
        /// <param name="nonce">随机数。</param>
        /// <param name="echostr">随机字符串。</param>
        /// <returns>如果校验成功则返回随机字符串（<paramref name="echostr"/>），否则抛出异常。</returns>
        public static string Execute(string signature, string timestamp, string nonce, string echostr)
        {
            if (Check(signature, timestamp, nonce))
            {
                return echostr;
            }
            throw new Exception("校验签名失败！");
        }

        #endregion
    }
}
