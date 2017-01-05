/**********************************************************************************************************************
 * 描述：
 *      响应支付结果通知消息。
 * 
 * 变更历史：
 *      作者：李亮  时间：2015年12月27日	 新建
 * 
 *********************************************************************************************************************/
using System.Xml.Serialization;
using Wlitsoft.Framework.Common.Serialize;

namespace Wlitsoft.Framework.WeixinSDK.Message.Response
{
    /// <summary>
    /// 响应支付结果通知消息。
    /// </summary>
    [XmlRoot("xml")]
    public class ResponsePayResultNotifyMessage
    {
        /// <summary>
        /// 返回状态码。
        /// <para>SUCCESS/FAIL</para>
        /// </summary>
        [XmlElement("return_code")]
        public XmlCDATAElement ReturnCode { get; set; }

        /// <summary>
        /// 返回信息。
        /// <para>返回信息，如非空，为错误原因：签名失败 参数格式校验错误</para>
        /// </summary>
        [XmlElement("return_msg")]
        public XmlCDATAElement ReturnMsg { get; set; }
    }
}
