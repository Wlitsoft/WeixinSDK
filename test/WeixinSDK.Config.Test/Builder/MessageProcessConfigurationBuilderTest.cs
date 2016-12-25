using Wlitsoft.Framework.Common;
using Wlitsoft.Framework.Common.Core;
using Wlitsoft.Framework.Common.Serializer.JsonNet;
using Wlitsoft.Framework.WeixinSDK.Config.Builder;
using Wlitsoft.Framework.WeixinSDK.Configuration;
using Xunit;

namespace WeixinSDK.Config.Test.Builder
{
    public class MessageProcessConfigurationBuilderTest
    {
        [Fact]
        public void BuildByJsonFileTest()
        {
            App.Builder.AddSerializer(SerializeType.Json, new JsonNetJsonSerializer());
            MessageProcessConfiguration config = MessageProcessConfigurationBuilder.BuildByJsonFile("./Conf/MessageProcessConfig.json");

            Assert.NotNull(config);
            Assert.True(config.MessageList.Count > 0);
            Assert.True(config.EventMessageList.Count > 0);
            Assert.Equal<string>("Key01", config.EventMessageList[0].EventKey);
        }
    }
}
