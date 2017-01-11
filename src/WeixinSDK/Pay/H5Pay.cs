/**********************************************************************************************************************
 * 描述：
 *      H5 支付。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月11日	 新建
 * 
 *********************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.Common.Security;
using Wlitsoft.Framework.WeixinSDK.Extension;
using Wlitsoft.Framework.WeixinSDK.Model.PayModel;

namespace Wlitsoft.Framework.WeixinSDK.Pay
{
    /// <summary>
    /// H5 支付。
    /// </summary>
    public static class H5Pay
    {
        #region 构造 DeepLink

        /// <summary>
        /// 构造 DeepLink。
        /// </summary>
        /// <param name="prepayId">预支付交易会话标识。</param>
        /// <returns>用于H5调用微信支付的 DeepLink。</returns>
        public static string BuildDeepLink(string prepayId)
        {
            string nonceStr = Common.Extension.StringExtension.NewNonceStr(32);
            string timestamp = DateTime.Now.GetUnixTimestamp().ToString();

            #region 获得签名

            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                {"appid", WeixinApp.DevConfig.AppID},
                {"noncestr", nonceStr},
                {"package", TradeType.WAP.ToString()},
                {"prepayid", prepayId},
                {"timestamp", timestamp}
            };

            //获取签名。
            string sign = ParamsSignerEx.GetSign(dic);

            #endregion

            StringBuilder sb1 = new StringBuilder();
            sb1.AppendFormat("appid={0}", dic["appid"]);
            sb1.AppendFormat("&noncestr={0}", dic["noncestr"]);
            sb1.AppendFormat("&package={0}", dic["package"]);
            sb1.AppendFormat("&prepayid={0}", dic["prepayid"]);
            sb1.AppendFormat("&sign={0}", sign);
            sb1.AppendFormat("&timestamp={0}", dic["timestamp"]);

            string string2 = HttpUtility.UrlEncode(sb1.ToString());
            return $"weixin://wap/pay?{string2}";
        }

        #endregion
    }
}
