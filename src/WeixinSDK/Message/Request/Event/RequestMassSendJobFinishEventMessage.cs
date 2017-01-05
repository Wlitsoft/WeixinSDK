/**********************************************************************************************************************
 * 描述：
 *      接收请求群发完成事件消息。
 * 
 * 变更历史：
 *      作者：李亮  时间：2016年12月27日	 新建
 * 
 *********************************************************************************************************************/

using System.ComponentModel;
using System.Xml.Serialization;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.WeixinSDK.Core;

namespace Wlitsoft.Framework.WeixinSDK.Message.Request.Event
{
    /// <summary>
    /// 接收请求群发完成事件消息。
    /// </summary>
    [XmlRoot("xml")]
    public class RequestMassSendJobFinishEventMessage : RequestEventMessageBase
    {
        #region RequestEventMessageBase 成员

        /// <summary>
        /// 获取 事件类型。
        /// </summary>
        [XmlIgnore]
        public override RequestMsgEventType Event => RequestMsgEventType.MassSendJobFinish;

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置 群发的消息ID。
        /// </summary>
        public long MsgID { get; set; }

        /// <summary>
        /// 获取或设置 群发的结果。
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 获取 群发的结果文本描述。
        /// </summary>
        [XmlIgnore]
        public string StatusText => this.Status;

        /// <summary>
        /// 获取或设置 group_id下粉丝数；或者openid_list中的粉丝数。
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 获取或设置 过滤（过滤是指特定地区、性别的过滤、用户设置拒收的过滤，用户接收已超4条的过滤）后，准备发送的粉丝数，原则上，FilterCount = SentCount + ErrorCount。
        /// </summary>
        public int FilterCount { get; set; }

        /// <summary>
        /// 获取或设置 发送成功的粉丝数。
        /// </summary>
        public int SentCount { get; set; }

        /// <summary>
        /// 获取或设置 发送失败的粉丝数。
        /// </summary>
        public int ErrorCount { get; set; }

        #endregion

        #region 群发状态

        /// <summary>
        /// 群发状态。
        /// </summary>
        public enum MassStatus
        {
            /// <summary>
            /// 发送成功。
            /// </summary>
            [Description("sendsuccess")]
            SendSuccess,

            /// <summary>
            /// 发送失败。
            /// </summary>
            [Description("sendfail")]
            SendFail,

            /// <summary>
            /// 涉嫌广告。
            /// </summary>
            [Description("err(10001)")]
            Err_10001,

            /// <summary>
            /// 涉嫌政治。
            /// </summary>
            [Description("err(20001)")]
            Err_20001,

            /// <summary>
            /// 涉嫌社会。
            /// </summary>
            [Description("err(20004)")]
            Err_20004,

            /// <summary>
            /// 涉嫌色情。
            /// </summary>
            [Description("err(20002)")]
            Err_20002,

            /// <summary>
            /// 涉嫌违法犯罪。
            /// </summary>
            [Description("err(20006)")]
            Err_20006,

            /// <summary>
            /// 涉嫌欺诈。
            /// </summary>
            [Description("err(20008)")]
            Err_20008,

            /// <summary>
            /// 涉嫌版权。
            /// </summary>
            [Description("err(20013)")]
            Err_20013,

            /// <summary>
            /// 涉嫌互推(互相宣传)。
            /// </summary>
            [Description("err(22000)")]
            Err_22000,

            /// <summary>
            /// 涉嫌其他。
            /// </summary>
            [Description("err(21000)")]
            Err_21000,

        }

        #endregion
    }
}
