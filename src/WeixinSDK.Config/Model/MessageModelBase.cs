/**********************************************************************************************************************
 * 描述：
 *      消息基类。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/
using System;
using Newtonsoft.Json;

namespace Wlitsoft.Framework.WeixinSDK.Config.Model
{
    /// <summary>
    /// 消息基类。
    /// </summary>
    internal abstract class MessageModelBase
    {
        /// <summary>
        /// 获取或设置 消息处理类型全名称。
        /// </summary>
        [JsonProperty("Type")]
        public string TypeString { get; set; }

        /// <summary>
        /// 获取或设置 消息处理类型。
        /// </summary>
        [JsonIgnore]
        public Type Type => Type.GetType(this.TypeString);
    }
}
