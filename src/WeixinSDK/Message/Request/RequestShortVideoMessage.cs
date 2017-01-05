/**********************************************************************************************************************
 * 描述：
 *      接收请求小视频消息。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月27日	 新建
 * 
 *********************************************************************************************************************/

using System.Xml.Serialization;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Message.Request
{
    /// <summary>
    /// 接收请求视频消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestShortVideoMessage : RequestVideoMessage
    {
        #region RequestMessageBase 成员

        /// <summary>
        /// 获取 请求消息类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgType MsgType => RequestMsgType.ShortVideo;

        #endregion
    }
}
