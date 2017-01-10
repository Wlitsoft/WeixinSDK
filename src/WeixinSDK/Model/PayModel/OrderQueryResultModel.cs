/**********************************************************************************************************************
 * 描述：
 *      查询订单返回结果模型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月07日	 新建
 * 
 *********************************************************************************************************************/
using System.Xml.Serialization;

namespace Wlitsoft.Framework.WeixinSDK.Model.PayModel
{
    /// <summary>
    /// 查询订单返回结果模型。
    /// </summary>
    [XmlRoot("xml")]
    public class OrderQueryResultModel : PayResultModelBase
    {
        /// <summary>
        /// 用户标识。
        /// <para>用户在商户appid下的唯一标识。</para>
        /// </summary>
        [XmlElement("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 是否关注公众账号。
        /// <para>用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效。</para>
        /// </summary>
        [XmlElement("is_subscribe")]
        public string IsSubscribe { get; set; }

        /// <summary>
        /// 交易状态。
        /// <para>
        /// SUCCESS—支付成功 
        ///REFUND—转入退款 
        ///NOTPAY—未支付 
        ///CLOSED—已关闭 
        ///REVOKED—已撤销（刷卡支付） 
        ///USERPAYING--用户支付中 
        ///PAYERROR--支付失败(其他原因，如银行返回失败)
        /// </para>
        /// </summary>
        [XmlElement("trade_state")]
        public string TradeState { get; set; }

        /// <summary>
        /// 付款银行。
        /// <para>银行类型，采用字符串类型的银行标识。</para>
        /// </summary>
        [XmlElement("bank_type")]
        public string BankType { get; set; }

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
        /// 现金支付货币类型。
        /// <para>货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY。</para>
        /// </summary>
        [XmlElement("cash_fee_type")]
        public string CashFeeType { get; set; }

        /// <summary>
        /// 代金券金额。
        /// <para>“代金券”金额<=订单金额，订单金额-“代金券”金额=现金支付金额。</para>
        /// </summary>
        [XmlElement("coupon_fee")]
        public int CouponFee { get; set; }

        /// <summary>
        /// 代金券使用数量。
        /// <para> 代金券使用数量。</para>
        /// </summary>
        [XmlElement("coupon_count")]
        public int CouponCount { get; set; }

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
        /// 附加数据。
        /// <para>附加数据，原样返回。</para>
        /// </summary>
        [XmlElement("attach")]
        public string Attach { get; set; }

        /// <summary>
        /// 支付完成时间。
        /// <para>订单支付时间，格式为yyyyMMddHHmmss。</para>
        /// </summary>
        [XmlElement("time_end")]
        public string TimeEnd { get; set; }

        /// <summary>
        /// 交易状态描述。
        /// <para>对当前查询订单状态的描述和下一步操作的指引。</para>
        /// </summary>
        [XmlElement("trade_state_desc")]
        public string TradeStateDesc { get; set; }
    }
}
