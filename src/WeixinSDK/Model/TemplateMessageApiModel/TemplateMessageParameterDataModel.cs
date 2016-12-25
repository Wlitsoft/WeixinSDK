/**********************************************************************************************************************
 * 描述：
 *      模板消息参数数据模型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月25日	 新建
 * 
 *********************************************************************************************************************/
using Newtonsoft.Json;

namespace Wlitsoft.Framework.WeixinSDK.Model.TemplateMessageApiModel
{
    /// <summary>
    /// 模板消息参数数据模型。
    /// </summary>
    public class TemplateMessageParameterDataModel
    {
        #region 公共属性

        /// <summary>
        /// 获取或设置 模板参数值。
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// 获取 模板参数 html 颜色。
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 根据参数值和参数颜色初始化 <see cref="TemplateMessageParameterDataModel"/> 类的新实例。
        /// </summary>
        /// <param name="value">参数值。</param>
        /// <param name="color">参数 html 颜色。</param>
        public TemplateMessageParameterDataModel(string value, string color = "#000000")
        {
            this.Value = value;
            this.Color = color;
        }

        #endregion
    }
}
