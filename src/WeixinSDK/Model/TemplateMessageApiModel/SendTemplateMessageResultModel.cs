/**********************************************************************************************************************
 * 描述：
 *      发送模板消息 结果模型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/
using Newtonsoft.Json;

namespace Wlitsoft.Framework.WeixinSDK.Model.TemplateMessageApiModel
{
    /// <summary>
    /// 发送模板消息 结果模型。
    /// </summary>
    public class SendTemplateMessageResultModel : ResultModelBase
    {
        /// <summary>
        /// 获取或设置 模板消息编号。
        /// </summary>
        [JsonProperty("msgid")]
        public long MsgId { get; set; }
    }
}
