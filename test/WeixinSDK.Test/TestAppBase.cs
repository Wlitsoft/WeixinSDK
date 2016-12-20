using Wlitsoft.Framework.Common;
using Wlitsoft.Framework.WeixinSDK;
using Wlitsoft.Framework.WeixinSDK.Configuration;
using Wlitsoft.Framework.WeixinSDK.Extension;
using Wlitsoft.Framework.WeixinSDK.TokenService;
using Xunit;

namespace WeixinSDK.Test
{
    public class TestAppBase
    {
        static TestAppBase()
        {
            GeneralTokenService tokenService = new GeneralTokenService();

            App.Builder
                .SetWeixinLoggerName("WeixinSDK")
                .SetWeixinDevConfigByAppSettings()
                .SetWeixinTokenService(tokenService);

            tokenService.Run();
        }

        [Fact]
        public void InitConfigTesst()
        {
            DevConfiguration devConfig = WeixinApp.DevConfig;

            Assert.NotNull(devConfig);
            Assert.True(devConfig.AppID.Length > 0);
            Assert.True(devConfig.AppSecret.Length > 0);
        }
    }
}
