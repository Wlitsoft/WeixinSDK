using System;
using System.Threading;
using WeixinSDK.Test.Fake;
using Wlitsoft.Framework.Common;
using Wlitsoft.Framework.Common.Logger.Log4Net;
using Wlitsoft.Framework.Common.Serialize.Dynamic;
using Wlitsoft.Framework.WeixinSDK.Configuration;
using Wlitsoft.Framework.WeixinSDK.Core;
using Wlitsoft.Framework.WeixinSDK.Extension;
using Wlitsoft.Framework.WeixinSDK.Message.Process;
using Wlitsoft.Framework.WeixinSDK.Message.Security.Crypto;
using Wlitsoft.Framework.WeixinSDK.TokenService;
using Xunit;

namespace WeixinSDK.Test.Message.Process
{
    /// <summary>
    /// 微信消息处理者测试。
    /// <remarks>
    /// 运行该单元测试需要将配置文件中的配置项改成
    /// WeixinSDK.AppID wx5823bf96d3bd56c7
    /// WeixinSDK.Token QDG6eK
    /// WeixinSDK.EncodingAESKey jWmYm7qr5nMoAUwZRjGtBxmz3KA1tkAj3ykkR6q2B2C
    /// </remarks>
    /// </summary>
    public class WeixinMessageHandlerTest
    {
        public WeixinMessageHandlerTest()
        {
            //设置日志。
            App.Builder.SetLog4NetLoggerByXmlConfig("./Conf/log4net.conf");

            DevConfiguration devConfig = new DevConfiguration()
            {
                AppID = "wx5823bf96d3bd56c7",
                Token = "QDG6eK",
                EncodingAESKey = "jWmYm7qr5nMoAUwZRjGtBxmz3KA1tkAj3ykkR6q2B2C"
            };

            DebugTokenService tokenService = new DebugTokenService()
            {
                Token = "xxxxxxxxx"
            };

            //设置微信SDK相关。
            App.Builder
                .SetWeixinLogger("WeixinSDKLog")
                .SetWeixinDevConfig(devConfig)
                .SetWeixinTokenService(tokenService);

            MessageProcessConfiguration pc = new MessageProcessConfiguration();
            pc.MessageList.Add(new MessageConfiguration<RequestTextMessageProcessFake>(RequestMsgType.Text));

            App.Builder
                .SetWeixinMessageConfig(pc);
        }

        [Fact]
        public void ExecuteTest_DataNativeMessageHandle()
        {
            const string xml = @"<xml>
                                 <ToUserName><![CDATA[toUser]]></ToUserName>
                                 <FromUserName><![CDATA[fromUser]]></FromUserName> 
                                 <CreateTime>1348831860</CreateTime>
                                 <MsgType><![CDATA[text]]></MsgType>
                                 <Content><![CDATA[this is a test]]></Content>
                                 <MsgId>1234567890123456</MsgId>
                                 </xml>";

            WeixinMessageContext context = new WeixinMessageContext()
            {
                HttpRequestContent = xml,
                HttpRequestParams = new HttpRequestParams()
                {
                    Encrypt_Type = "raw",
                    Signature = "72e5966e52226c51c2ae8a012815cda2f1056171",
                    Timestamp = "14433232323"
                }
            };

            WeixinMessageHandler handler = new WeixinMessageHandler(context);

            string content = handler.Execute();

            Assert.NotNull(content);
            Assert.True(content.Length > 0);

            //响应 xml 结果 测试。
            dynamic contentXmlObj = new DynamicXml(content);

            Assert.Equal("fromUser", contentXmlObj.ToUserName.Value);
            Assert.Equal("toUser", contentXmlObj.FromUserName.Value);
            Assert.True(Convert.ToInt64(contentXmlObj.CreateTime.Value) > 0);
            Assert.Equal("text", contentXmlObj.MsgType.Value);
            Assert.Equal("this is a test", contentXmlObj.Content.Value);

        }

        /// <summary>
        /// 方法 <see cref="WeixinMessageHandler.Execute()"/> 的单元测试。
        /// <para>忽略重复消息处理测试。</para>
        /// </summary>
        [Fact]
        public void ExecuteTest_IgnoreRepeatMessageHandle()
        {

            const string xml = @"<xml>
                                 <ToUserName><![CDATA[toUser]]></ToUserName>
                                 <FromUserName><![CDATA[fromUser]]></FromUserName> 
                                 <CreateTime>1348831860</CreateTime>
                                 <MsgType><![CDATA[text]]></MsgType>
                                 <Content><![CDATA[this is a test]]></Content>
                                 <MsgId>1234567890123456</MsgId>
                                 </xml>";

            WeixinMessageContext context = new WeixinMessageContext()
            {
                HttpRequestContent = xml,
                HttpRequestParams = new HttpRequestParams()
                {
                    Encrypt_Type = "raw",
                    Signature = "72e5966e52226c51c2ae8a012815cda2f1056171",
                    Timestamp = "14433232323"
                }
            };

            WeixinMessageHandler handler = new WeixinMessageHandler(context);

            string content = handler.Execute();

            Assert.NotNull(content);
            Assert.True(content.Length > 0);

            //模拟第二次请求，如果返回空字符串则表示已经忽略消息。
            Thread.Sleep(3000);

            WeixinMessageContext context2 = new WeixinMessageContext()
            {
                HttpRequestContent = xml,
                HttpRequestParams = new HttpRequestParams()
                {
                    Encrypt_Type = "raw",
                    Signature = "72e5966e52226c51c2ae8a012815cda2f1056171",
                    Timestamp = "14433232323"
                }
            };

            WeixinMessageHandler handler2 = new WeixinMessageHandler(context2);

            string content2 = handler2.Execute();

            Assert.NotNull(content2);
            Assert.Equal(string.Empty, content2);

        }

        /// <summary>
        /// 方法 <see cref="WeixinMessageHandler.Execute()"/> 的单元测试。
        /// <para>加密消息处理测试。</para>
        /// </summary>
        [Fact]
        public void ExecuteTest_EncryptMessageHandle()
        {

            const string xml = @"<xml>
                                     <ToUserName><![CDATA[wx5823bf96d3bd56c7]]></ToUserName>
                                     <Encrypt><![CDATA[RypEvHKD8QQKFhvQ6QleEB4J58tiPdvo+rtK1I9qca6aM/wvqnLSV5zEPeusUiX5L5X/0lWfrf0QADHHhGd3QczcdCUpj911L3vg3W/sYYvuJTs3TUUkSUXxaccAS0qhxchrRYt66wiSpGLYL42aM6A8dTT+6k4aSknmPj48kzJs8qLjvd4Xgpue06DOdnLxAUHzM6+kDZ+HMZfJYuR+LtwGc2hgf5gsijff0ekUNXZiqATP7PF5mZxZ3Izoun1s4zG4LUMnvw2r+KqCKIw+3IQH03v+BCA9nMELNqbSf6tiWSrXJB3LAVGUcallcrw8V2t9EL4EhzJWrQUax5wLVMNS0+rUPA3k22Ncx4XXZS9o0MBH27Bo6BpNelZpS+/uh9KsNlY6bHCmJU9p8g7m3fVKn28H3KDYA5Pl/T8Z1ptDAVe0lXdQ2YoyyH2uyPIGHBZZIs2pDBS8R07+qN+E7Q==]]></Encrypt>
                                 </xml>";

            WeixinMessageContext context = new WeixinMessageContext()
            {
                HttpRequestContent = xml,
                HttpRequestParams = new HttpRequestParams()
                {
                    Encrypt_Type = "aes",
                    Signature = "d2157f2f9079f4d6257b45edf665c43c62e60a0a",
                    Timestamp = "1409659813",
                    Nonce = "1372623149",
                    Msg_Signature = "477715d11cdb4164915debcba66cb864d751f3e6"
                }
            };

            WeixinMessageHandler handler = new WeixinMessageHandler(context);

            string content = handler.Execute();

            Assert.NotNull(content);
            Assert.True(content.Length > 0);

            //解密校验结果是否正确，
            dynamic resultXmlObj = new DynamicXml(content);

            Assert.Equal(context.HttpRequestParams.Timestamp, resultXmlObj.TimeStamp.Value);
            Assert.Equal(context.HttpRequestParams.Nonce, resultXmlObj.Nonce.Value);
            Assert.True(resultXmlObj.Encrypt.Value.Length > 0);

            //获取消息签名 后期解密字符串使用。
            string msgSignature = resultXmlObj.MsgSignature.Value;
            Assert.True(msgSignature.Length > 0);

            string sMsg = string.Empty;
            WeixinMsgCrypto msgCrypto = new WeixinMsgCrypto();
            int resultXmlDecryptResult = msgCrypto.DecryptMsg(msgSignature, context.HttpRequestParams.Timestamp, context.HttpRequestParams.Nonce, content, ref sMsg);

            Assert.Equal(Convert.ToInt32(WeixinMsgCryptoErrorCode.OK), resultXmlDecryptResult);
            Assert.True(sMsg.Length > 0);

            //解密后的 xml 结果 测试。
            dynamic contentXmlObj = new DynamicXml(sMsg);

            Assert.Equal("mycreate", contentXmlObj.ToUserName.Value);
            Assert.Equal("wx5823bf96d3bd56c7", contentXmlObj.FromUserName.Value);
            Assert.True(Convert.ToInt64(contentXmlObj.CreateTime.Value) > 0);
            Assert.Equal("text", contentXmlObj.MsgType.Value);
            Assert.Equal("hello", contentXmlObj.Content.Value);
        }
    }
}
