/**********************************************************************************************************************
 * 描述：
 *      公众号支付。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月11日	 新建
 * 
 *********************************************************************************************************************/

using System.Collections.Generic;
using Wlitsoft.Framework.Common.Exception;
using Wlitsoft.Framework.WeixinSDK.Extension;
using Wlitsoft.Framework.WeixinSDK.Model.PayModel;

namespace Wlitsoft.Framework.WeixinSDK.Pay
{
    /// <summary>
    /// 公众号支付。
    /// </summary>
    public static class MPPay
    {
        #region 获取微信支付模型对象

        /// <summary>
        /// 获取微信支付模型对象。
        /// </summary>
        /// <param name="timestamp">生成签名的时间戳。</param>
        /// <param name="nonceStr">生成签名的随机串。</param>
        /// <param name="prepayId">预支付交易会话标识。</param>
        /// <returns>微信支付模型对象。</returns>
        public static WxChooseWXPayModel GetWxChooseWXPayModel(long timestamp, string nonceStr, string prepayId)
        {
            if (string.IsNullOrEmpty(nonceStr))
                throw new ObjectNullException(nameof(nonceStr));

            WxChooseWXPayModel model = new WxChooseWXPayModel()
            {
                Timestamp = timestamp,
                NonceStr = nonceStr,
                Package = $"prepay_id={prepayId}"
            };

            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                {"appId", WeixinApp.DevConfig.AppID},
                {"timeStamp", model.Timestamp.ToString()},
                {"nonceStr", model.NonceStr},
                {"package", model.Package},
                {"signType", model.SignType}
            };

            model.PaySign = ParamsSignerEx.GetSign(dic);
            return model;
        }

        #endregion
    }
}
