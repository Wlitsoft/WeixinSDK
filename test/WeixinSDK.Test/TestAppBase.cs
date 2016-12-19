using Wlitsoft.Framework.Common;
using Wlitsoft.Framework.WeixinSDK;
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
            tokenService.Run();

            App.Builder
                .SetWeixinLoggerName("WeixinSDK")
                .SetWeixinDevConfigByAppSettings()
                .SetTokenService(tokenService);
        }

        [Fact]
        public void InitConfigTesst()
        {
            //WeixinApp.
        }
    }
}
