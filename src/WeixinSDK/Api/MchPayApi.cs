/**********************************************************************************************************************
 * 描述：
 *      企业付款 Api。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月11日	 新建
 * 
 *********************************************************************************************************************/

using System.Collections.Generic;
using Wlitsoft.Framework.WeixinSDK.Extension;
using Wlitsoft.Framework.WeixinSDK.Model.PayModel;

namespace Wlitsoft.Framework.WeixinSDK.Api
{
    /// <summary>
    /// 企业付款 Api。
    /// </summary>
    public static class MchPayApi
    {
        #region 企业付款

        /// <summary>
        /// 企业付款。
        /// </summary>
        /// <param name="partnerTradeNo">商户订单号。</param>
        /// <param name="openId">用户openid。</param>
        /// <param name="checkNameMode">校验用户姓名选项。</param>
        /// <param name="reUserName">收款用户姓名。</param>
        /// <param name="amount">金额 单位为分。</param>
        /// <param name="desc">企业付款描述信息。</param>
        /// <param name="spbillCreateIp">调用接口的机器Ip地址。</param>
        public static PaymentResultModel Payment(string partnerTradeNo, string openId, CheckNameMode checkNameMode, string reUserName, int amount, string desc, string spbillCreateIp)
        {
            Dictionary<string, string> postData = new Dictionary<string, string>
            {
                {"mch_appid", WeixinApp.DevConfig.AppID},
                {"mchid", WeixinApp.DevConfig.PayConfig.MchId},
                {"nonce_str", Common.Extension.StringExtension.NewNonceStr(32)},
                {"partner_trade_no", partnerTradeNo},
                {"openid", openId},
                {"check_name", checkNameMode.ToString()},
                {"re_user_name", reUserName},
                {"amount", amount.ToString()},
                {"desc", desc},
                {"spbill_create_ip", spbillCreateIp}
            };

            string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers";
            return HttpReqeustClientEx.PayApiInvokeResult<PaymentResultModel>(url, postData, true);
        }

        #endregion

        #region 查询企业付款

        /// <summary>
        /// 查询企业付款。
        /// </summary>
        /// <param name="partnerTradeNo">商户订单号。</param>
        /// <returns></returns>
        public static QueryPaymentResultModel QueryPayment(string partnerTradeNo)
        {
            Dictionary<string, string> postData = new Dictionary<string, string>
            {
                {"mch_id", WeixinApp.DevConfig.PayConfig.MchId},
                {"appid", WeixinApp.DevConfig.AppID},
                {"nonce_str", Common.Extension.StringExtension.NewNonceStr(32)},
                {"partner_trade_no", partnerTradeNo}
            };

            string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/gettransferinfo";
            return HttpReqeustClientEx.PayApiInvokeResult<QueryPaymentResultModel>(url, postData, true);
        }

        #endregion
    }
}
