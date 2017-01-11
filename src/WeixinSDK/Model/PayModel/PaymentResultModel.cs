/**********************************************************************************************************************
 * 描述：
 *      企业付款返回结果。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月11日	 新建
 * 
 *********************************************************************************************************************/
using System.Xml.Serialization;

namespace Wlitsoft.Framework.WeixinSDK.Model.PayModel
{
    /// <summary>
    /// 企业付款返回结果。
    /// </summary>
    [XmlRoot("xml")]
    public class PaymentResultModel : PayResultModelBase
    {
        /// <summary>
        /// 公众账号ID。
        /// <para>调用接口提交的公众账号ID。</para>
        /// </summary>
        [XmlElement("mch_appid")]
        public string MchAppId { get; set; }

        /// <summary>
        /// 商户订单号。
        /// <para>商户系统的订单号，与请求一致。</para>
        /// </summary>
        [XmlElement("partner_trade_no")]
        public string PartnerTradeNo { get; set; }

        /// <summary>
        /// 微信支付订单号。
        /// </summary>
        [XmlElement("payment_no")]
        public string PaymentNo { get; set; }

        /// <summary>
        /// 微信支付成功时间。
        /// </summary>
        [XmlElement("payment_time")]
        public string PaymentTime { get; set; }
    }
}
