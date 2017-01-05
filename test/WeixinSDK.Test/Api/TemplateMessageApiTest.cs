using System;
using Wlitsoft.Framework.WeixinSDK.Api;
using Wlitsoft.Framework.WeixinSDK.Model.TemplateMessageApiModel;
using Xunit;

namespace WeixinSDK.Test.Api
{
    public class TemplateMessageApiTest : TestBase
    {
        [Fact]
        public void SendTemplateMessageTest()
        {
            string templateId = "QMLApk4W8Jm9sUgwsCd-6jT1vxZAEUQXdJHMjF8bE3Y";
            string detailUrl = "http://www.github.com/wlitsoft/weixinsdk";
            TemplateMessageParameterDictionary pdic = new TemplateMessageParameterDictionary();
            pdic.Add("Content", new TemplateMessageParameterDataModel($"当前时间:{DateTime.Now}"));

            SendTemplateMessageResultModel result = TemplateMessageApi.SendTemplateMessage(base.TestOpenId, templateId, detailUrl, "#ffffff", pdic);

            Assert.NotNull(result);
            Assert.True(result.MsgId > 0);
        }
    }
}
