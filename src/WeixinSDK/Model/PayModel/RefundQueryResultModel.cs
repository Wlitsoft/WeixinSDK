/**********************************************************************************************************************
 * 描述：
 *      查询退款返回结果模型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月07日	 新建
 * 
 *********************************************************************************************************************/
using System.Xml.Serialization;

namespace Wlitsoft.Framework.WeixinSDK.Model.PayModel
{
    /// <summary>
    /// 查询退款返回结果模型。
    /// </summary>
    [XmlRoot("xml")]
    public class RefundQueryResultModel : PayResultModelBase
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
        /// 订单金额。
        /// <para>订单总金额，单位为分。</para>
        /// </summary>
        [XmlElement("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>
        /// 应结订单金额。
        /// <para>应结订单金额=订单金额-非充值代金券金额，应结订单金额小于等于订单金额 。</para>
        /// </summary>
        [XmlElement("settlement_total_fee")]
        public int SettlementTotalFee { get; set; }

        /// <summary>
        /// 货币种类。
        /// <para>货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY。</para>
        /// </summary>
        [XmlElement("fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        /// 现金支付金额。
        /// <para>现金支付金额订单现金支付金额。</para>
        /// </summary>
        [XmlElement("cash_fee")]
        public int CashFee { get; set; }

        /// <summary>
        /// 退款笔数。
        /// <para>退款记录数。</para>
        /// </summary>
        [XmlElement("refund_count")]
        public int RefundCount { get; set; }
    }
}
