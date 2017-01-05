/**********************************************************************************************************************
 * 描述：
 *      接收请求扫码推事件的事件消息。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月27日	 新建
 * 
 *********************************************************************************************************************/

using System.Xml.Serialization;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Message.Request.Event
{
    /// <summary>
    /// 接收请求扫码推事件的事件消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestScanCodePushEventMessage : RequestEventMessageBase, IRequestMessageEventKey
    {
        #region RequestEventMessageBase 成员

        /// <summary>
        /// 获取 事件类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgEventType Event => RequestMsgEventType.ScanCodePush;

        #endregion

        #region IEventKey 成员

        /// <summary>
        /// 获取或设置 事件KEY值，由开发者在创建菜单时设定。
        /// </summary>
        public string EventKey { get; set; }

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 扫描信息。
        /// </summary>
        public ScanCodeInfoData ScanCodeInfo { get; set; }

        #endregion

        #region 扫描信息数据

        /// <summary>
        /// 扫描信息数据。
        /// </summary>
        public class ScanCodeInfoData
        {
            /// <summary>
            /// 获取或设置 扫描类型，一般是qrcode。
            /// </summary>
            public string ScanType { get; set; }

            /// <summary>
            /// 获取或设置 扫描结果，即二维码对应的字符串信息。
            /// </summary>
            public string ScanResult { get; set; }
        }

        #endregion
    }
}
