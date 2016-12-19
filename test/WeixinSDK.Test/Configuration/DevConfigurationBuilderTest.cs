using Wlitsoft.Framework.WeixinSDK.Configuration;
using Xunit;

namespace WeixinSDK.Test.Configuration
{
    public class DevConfigurationBuilderTest
    {
        [Fact]
        public void BuildByAppSettingsTest()
        {
            DevConfiguration devConfig = DevConfigurationBuilder.BuildByAppSettings();

            Assert.NotNull(devConfig);
            Assert.True(devConfig.AppID.Length > 0);
            Assert.True(devConfig.AppSecret.Length > 0);
        }

        [Fact]
        public void BuildByJsonFileTest()
        {
            DevConfiguration devConfig = DevConfigurationBuilder.BuildByJsonFile("./Conf/WeixinSDKDev.json");

            Assert.NotNull(devConfig);
            Assert.True(devConfig.AppID.Length > 0);
            Assert.True(devConfig.AppSecret.Length > 0);
        }
    }
}
