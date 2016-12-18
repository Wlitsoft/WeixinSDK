/**********************************************************************************************************************
 * 描述：
 *      结果模型 基类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月18日	 新建
 * 
 *********************************************************************************************************************/
using Newtonsoft.Json;

namespace Wlitsoft.Framework.WeixinSDK.Model
{
    /// <summary>
    /// 结果模型 基类。
    /// </summary>
    public class ResultModelBase
    {
        /// <summary>
        /// 获取或设置 错误编码。
        /// </summary>
        [JsonProperty("errcode")]
        public int ErrorCode { get; set; }

        /// <summary>
        /// 获取或设置 错误信息。
        /// </summary>
        [JsonProperty("errmsg")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 获取或设置 服务器响应结果字符串。
        /// <para>用于 Debug。</para>
        /// </summary>
        public string ResponseResultString { get; set; }
    }
}
