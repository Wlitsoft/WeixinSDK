using Wlitsoft.Framework.WeixinSDK.Core;
using Wlitsoft.Framework.WeixinSDK.Message.Request.Event;
using Wlitsoft.Framework.WeixinSDK.Message.Response;

namespace WeixinSDK.Test.Fake
{
    /// <summary>
    /// 订阅事件消息 Key_001 请求处理。
    /// </summary>
    public class RequestSubscribeEventMessageKey_001ProcessFake : WeixinMessageProcessBase
    {
        #region WeixinMessageProcessBase 成员

        /// <summary>
        /// 执行处理。
        /// </summary>
        public override void Process()
        {
            RequestSubscribeEventMessage requestMessage = base.GetRequestMessage<RequestSubscribeEventMessage>();

            ResponseTextMessage responseMessage = new ResponseTextMessage()
            {
                Content = requestMessage.EventKey
            };

            base.ResponseMessage = responseMessage;
        }

        #endregion
    }
}
