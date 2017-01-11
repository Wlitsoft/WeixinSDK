/**********************************************************************************************************************
 * 描述：
 *      微信JSSDK chooseWXPay 模型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月11日	 新建
 * 
 *********************************************************************************************************************/
using Newtonsoft.Json;

namespace Wlitsoft.Framework.WeixinSDK.Model.PayModel
{
    /// <summary>
    /// 微信JSSDK chooseWXPay 模型。
    /// </summary>
    public class WxChooseWXPayModel
    {
        /// <summary>
        /// 生成签名的时间戳。
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        /// <summary>
        /// 生成签名的随机串。
        /// </summary>
        [JsonProperty("nonceStr")]
        public string NonceStr { get; set; }

        /// <summary>
        /// 统一支付接口返回的prepay_id参数值，提交格式如：prepay_id=***）。
        /// </summary>
        [JsonProperty("package")]
        public string Package { get; set; }

        /// <summary>
        /// 签名方式，默认为'SHA1'，使用新版支付需传入'MD5'。
        /// </summary>
        [JsonProperty("signType")]
        public string SignType { get; set; }

        /// <summary>
        /// 支付签名。
        /// </summary>
        [JsonProperty("paySign")]
        public string PaySign { get; set; }

        /// <summary>
        /// 初始化 <see cref="WxChooseWXPayModel"/> 类的新实例。
        /// </summary>
        public WxChooseWXPayModel()
        {
            this.SignType = "MD5";
        }
    }
}
