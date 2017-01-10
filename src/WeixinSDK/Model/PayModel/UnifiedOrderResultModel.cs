/**********************************************************************************************************************
 * 描述：
 *      统一下单返回结果模型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月07日	 新建
 * 
 *********************************************************************************************************************/
using System.Xml.Serialization;

namespace Wlitsoft.Framework.WeixinSDK.Model.PayModel
{
    /// <summary>
    /// 统一下单返回结果模型。
    /// </summary>
    [XmlRoot("xml")]
    public class UnifiedOrderResultModel : PayResultModelBase
    {
        /// <summary>
        /// 预支付交易会话标识。
        /// <para>微信生成的预支付回话标识，用于后续接口调用中使用，该值有效期为2小时。</para>
        /// </summary>
        [XmlElement("prepay_id")]
        public string PrepayId { get; set; }

        /// <summary>
        /// 二维码链接。
        /// <para>trade_type为NATIVE是有返回，可将该参数值生成二维码展示出来进行扫码支付。</para>
        /// </summary>
        [XmlElement("code_url")]
        public string CodeUrl { get; set; }
    }
}
