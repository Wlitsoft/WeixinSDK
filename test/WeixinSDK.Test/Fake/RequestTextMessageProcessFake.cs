using Wlitsoft.Framework.WeixinSDK.Core;
using Wlitsoft.Framework.WeixinSDK.Message.Request;
using Wlitsoft.Framework.WeixinSDK.Message.Response;

namespace WeixinSDK.Test.Fake
{
    /// <summary>
    /// 文本消息请求处理。
    /// </summary>
    public class RequestTextMessageProcessFake : WeixinMessageProcessBase
    {
        #region WeixinMessageProcessBase 成员

        /// <summary>
        /// 执行处理。
        /// </summary>
        public override void Process()
        {
            RequestTextMessage requestMessage = base.GetRequestMessage<RequestTextMessage>();

            ResponseTextMessage responseMessage = new ResponseTextMessage()
            {
                Content = requestMessage.Content
            };

            base.ResponseMessage = responseMessage;
        }

        #endregion
    }
}
