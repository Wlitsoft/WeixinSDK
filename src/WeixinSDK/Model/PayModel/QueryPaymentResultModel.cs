/**********************************************************************************************************************
 * 描述：
 *      查询企业付款返回结果模型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月11日	 新建
 * 
 *********************************************************************************************************************/
using System.Xml.Serialization;

namespace Wlitsoft.Framework.WeixinSDK.Model.PayModel
{
    /// <summary>
    /// 查询企业付款返回结果模型。
    /// </summary>
    [XmlRoot("xml")]
    public class QueryPaymentResultModel : PayResultModelBase
    {
        /// <summary>
        /// 商户单号。
        /// <para>商户使用查询API填写的单号的原路返回。</para>
        /// </summary>
        [XmlElement("partner_trade_no")]
        public string PartnerTradeNo { get; set; }

        /// <summary>
        /// 付款单号。
        /// <para>调用企业付款API时，微信系统内部产生的单号。</para>
        /// </summary>
        [XmlElement("detail_id")]
        public string DetailId { get; set; }

        /// <summary>
        /// 转账状态。
        /// <para>
        /// SUCCESS:转账成功 
        /// FAILED:转账失败 
        /// PROCESSING:处理中
        /// </para>
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 失败原因。
        /// </summary>
        [XmlElement("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// 收款用户openid。
        /// <para>转账的openid。</para>
        /// </summary>
        [XmlElement("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 收款用户姓名。
        /// </summary>
        [XmlElement("transfer_name")]
        public string TransferName { get; set; }

        /// <summary>
        /// 付款金额。
        /// <para>付款金额单位分</para>
        /// </summary>
        [XmlElement("payment_amount")]
        public string PaymentAmount { get; set; }

        /// <summary>
        /// 转账时间。
        /// <para>发起转账的时间。</para>
        /// </summary>
        [XmlElement("transfer_time")]
        public string TransferTime { get; set; }

        /// <summary>
        /// 付款描述。
        /// <para>付款时候的描述。</para>
        /// </summary>
        [XmlElement("desc")]
        public string Desc { get; set; }
    }
}