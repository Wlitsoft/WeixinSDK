using Wlitsoft.Framework.WeixinSDK.Core;
using Wlitsoft.Framework.WeixinSDK.Message.Process;
using Wlitsoft.Framework.WeixinSDK.Message.Request;
using Xunit;

namespace WeixinSDK.Test.Message.Process
{
    public class RequestMessageProcessTest : TestBase
    {
        [Fact]
        public void RequestTextMessageParseTest()
        {
            const string xml = @"<xml>
                         <ToUserName><![CDATA[toUser]]></ToUserName>
                         <FromUserName><![CDATA[fromUser]]></FromUserName> 
                         <CreateTime>1348831860</CreateTime>
                         <MsgType><![CDATA[text]]></MsgType>
                         <Content><![CDATA[this is a test]]></Content>
                         <MsgId>1234567890123456</MsgId>
                         </xml>";

            RequestTextMessage message = RequestMessageProcess.Parse<RequestTextMessage>(xml);
            Assert.Equal("toUser", message.ToUserName);
            Assert.Equal("fromUser", message.FromUserName);
            Assert.Equal(1348831860, message.CreateTime);
            Assert.Equal(RequestMsgType.Text, message.MsgType);
            Assert.Equal("this is a test", message.Content);
            Assert.Equal(1234567890123456, message.MsgId);

            //第二次解析，校验是否在类型字典中取的类型。
            RequestTextMessage message2 = RequestMessageProcess.Parse<RequestTextMessage>(xml);
            Assert.Equal("toUser", message2.ToUserName);
        }

        [Fact]
        public void ProcessByConfigTest()
        {
            //文本消息处理测试。
            const string textmsg = @"<xml>
                         <ToUserName><![CDATA[toUser]]></ToUserName>
                         <FromUserName><![CDATA[fromUser]]></FromUserName> 
                         <CreateTime>1348831860</CreateTime>
                         <MsgType><![CDATA[text]]></MsgType>
                         <Content><![CDATA[this is a test]]></Content>
                         <MsgId>1234567890123456</MsgId>
                         </xml>";

            string textmsgResult = RequestMessageProcess.ProcessByConfig(textmsg);
            Assert.True(textmsgResult.Length > 0);

            //事件Key为：Key_001 的点击事件消息处理测试。
            const string clickEventMsg = @"<xml>
                        <ToUserName><![CDATA[toUser]]></ToUserName>
                        <FromUserName><![CDATA[FromUser]]></FromUserName>
                        <CreateTime>123456789</CreateTime>
                        <MsgType><![CDATA[event]]></MsgType>
                        <Event><![CDATA[subscribe]]></Event>
                        <EventKey><![CDATA[Key_001]]></EventKey>
                        </xml>";

            string clickEventMsgResult = RequestMessageProcess.ProcessByConfig(clickEventMsg);
            Assert.True(clickEventMsgResult.Length > 0);
        }
    }
}
