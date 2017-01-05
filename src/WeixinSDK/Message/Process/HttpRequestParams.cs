/**********************************************************************************************************************
 * 描述：
 *      HTTP 请求参数。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月04日	 新建
 * 
 *********************************************************************************************************************/
using System;

namespace Wlitsoft.Framework.WeixinSDK.Message.Process
{
    /// <summary>
    /// HTTP 请求参数。
    /// </summary>
    public class HttpRequestParams
    {
        /// <summary>
        /// 获取或设置 微信加密签名。
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 获取或设置 时间戳。
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// 获取或设置 随机数。
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// 获取或设置 加密类型。
        /// </summary>
        public string Encrypt_Type { get; set; }

        /// <summary>
        /// 获取 是否加密。
        /// </summary>
        public bool IsEncrypt
        {
            get
            {
                //url上无encrypt_type参数或者其值为raw时表示为不加密；encrypt_type为aes时，表示aes加密（暂时只有raw和aes两种值)。
                if (string.IsNullOrEmpty(this.Encrypt_Type) || this.Encrypt_Type == "raw")
                    return false;
                if (this.Encrypt_Type == "aes")
                    return true;
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 获取或设置 消息签名。
        /// </summary>
        public string Msg_Signature { get; set; }
    }
}
