/**********************************************************************************************************************
 * 描述：
 *      关闭订单返回结果模型。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年01月07日	 新建
 * 
 *********************************************************************************************************************/
using System.Xml.Serialization;

namespace Wlitsoft.Framework.WeixinSDK.Model.PayModel
{
    /// <summary>
    /// 关闭订单返回结果模型。
    /// </summary>
    [XmlRoot("xml")]
    public class CloseOrderResultModel : PayResultModelBase
    {
    }
}
