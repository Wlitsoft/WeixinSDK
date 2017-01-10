/**********************************************************************************************************************
 * 描述：
 *      支付配置信息类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年01月07日	 新建
 * 
 *********************************************************************************************************************/

namespace Wlitsoft.Framework.WeixinSDK.Configuration
{
    /// <summary>
    /// 支付配置信息类。
    /// </summary>
    public class PayConfiguration
    {
        /// <summary>
        /// 获取或设置微信支付分配的商户号。
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 获取或设置微信支付分配的秘钥。
        /// </summary>
        public string PartnerKey { get; set; }
    }
}
