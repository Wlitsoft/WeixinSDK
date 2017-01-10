/**********************************************************************************************************************
 * 描述：
 *      支付返回结果模型基类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月07日	 新建
 * 
 *********************************************************************************************************************/
using System.Xml.Serialization;

namespace Wlitsoft.Framework.WeixinSDK.Model.PayModel
{
    /// <summary>
    /// 支付返回结果模型基类。
    /// </summary>
    public class PayResultModelBase
    {
        /// <summary>
        /// 返回状态码。
        /// <para>SUCCESS/FAIL </para>
        /// </summary>
        [XmlElement("return_code")]
        public string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息。
        /// </summary>
        [XmlElement("return_msg")]
        public string ReturnMsg { get; set; }

        /// <summary>
        /// 公众账号ID。
        /// <para>调用接口提交的公众账号ID。</para>
        /// </summary>
        [XmlElement("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 商户号。
        /// <para>调用接口提交的商户号。</para>
        /// </summary>
        [XmlElement("mch_id")]
        public string MchId { get; set; }

        /// <summary>
        /// 设备号。
        /// <para>调用接口提交的终端设备号。</para>
        /// </summary>
        [XmlElement("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 随机字符串。
        /// <para>微信返回的随机字符串。</para>
        /// </summary>
        [XmlElement("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名。
        /// <para>微信返回的签名。</para>
        /// </summary>
        [XmlElement("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 业务结果。
        /// <para>SUCCESS/FAIL。</para>
        /// </summary>
        [XmlElement("result_code")]
        public string ResultCode { get; set; }

        /// <summary>
        /// 错误代码。
        /// </summary>
        [XmlElement("err_code")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误代码描述。
        /// </summary>
        [XmlElement("err_code_des")]
        public string ErrCodeDes { get; set; }

        /// <summary>
        /// 交易类型。
        /// <para>调用接口提交的交易类型，取值如下：JSAPI，NATIVE，APP</para>
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeType { get; set; }

        /// <summary>
        /// 原生提交字符串。
        /// </summary>
        [XmlIgnore]
        public string NativePostString { get; set; }

        /// <summary>
        /// 原生结果字符串。
        /// </summary>
        [XmlIgnore]
        public string NativeResultString { get; set; }
    }
}