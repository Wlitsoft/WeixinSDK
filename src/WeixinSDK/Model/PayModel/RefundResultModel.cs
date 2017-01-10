/**********************************************************************************************************************
 * 描述：
 *      申请退款返回结果模型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月07日	 新建
 * 
 *********************************************************************************************************************/
using System.Xml.Serialization;

namespace Wlitsoft.Framework.WeixinSDK.Model.PayModel
{
    /// <summary>
    /// 申请退款返回结果模型。
    /// </summary>
    [XmlRoot("xml")]
    public class RefundResultModel : PayResultModelBase
    {
        /// <summary>
        /// 微信支付订单号。
        /// </summary>
        [XmlElement("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号。
        /// <para>商户系统的订单号，与请求一致。</para>
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 商户退款单号。
        /// <para>商户系统内部的退款单号，商户系统内部唯一，同一退款单号多次请求只退一笔。</para>
        /// </summary>
        [XmlElement("out_refund_no")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号。
        /// </summary>
        [XmlElement("refund_id")]
        public string RefundId { get; set; }

        /// <summary>
        /// 退款渠道。
        /// <para>ORIGINAL—原路退款 BALANCE—退回到余额</para>
        /// </summary>
        [XmlElement("refund_channel")]
        public string RefundChannel { get; set; }

        /// <summary>
        /// 申请退款金额。
        /// <para>退款总金额,单位为分,可以做部分退款。</para>
        /// </summary>
        [XmlElement("refund_fee")]
        public int RefundFee { get; set; }

        /// <summary>
        /// 订单金额。
        /// <para>订单总金额，单位为分，只能为整数。</para>
        /// </summary>
        [XmlElement("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>
        /// 应结订单金额。
        /// <para>应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。 </para>
        /// </summary>
        [XmlElement("settlement_total_fee")]
        public int SettlementTotalFee { get; set; }

        /// <summary>
        /// 订单金额货币种类。
        /// <para>货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY。</para>
        /// </summary>
        [XmlElement("fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        /// 现金支付金额。
        /// <para>现金支付金额，单位为分，只能为整数。</para>
        /// </summary>
        [XmlElement("cash_fee")]
        public int CashFee { get; set; }

        /// <summary>
        /// 现金退款金额。
        /// <para>现金退款金额，单位为分，只能为整数。</para>
        /// </summary>
        [XmlElement("cash_refund_fee")]
        public int CashRefundFee { get; set; }

        /// <summary>
        /// 操作员。
        /// <para>操作员帐号, 默认为商户号。</para>
        /// </summary>
        [XmlElement("op_user_id")]
        public string OpUserId { get; set; }
    }
}
