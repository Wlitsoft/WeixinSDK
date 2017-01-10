using System.Threading;
using Wlitsoft.Framework.Common;
using Wlitsoft.Framework.WeixinSDK.Config.Extension;
using Wlitsoft.Framework.WeixinSDK.Extension;
using Wlitsoft.Framework.WeixinSDK.TokenService;
using Xunit;

namespace WeixinSDK.Test.TokenService
{
    public class GeneralTokenServiceTest
    {
        [Fact]
        public void RunTest()
        {
            //初始化配置信息。
            App.Builder.SetWeixinDevConfigByAppSettings();

            GeneralTokenService tokenService = new GeneralTokenService();
            tokenService.Run();

            Assert.True(tokenService.RunStatus);

            string token = tokenService.GetToken();
            string tickect = tokenService.GetJsTickect();

            Assert.True(token.Length > 0);
            Assert.True(tickect.Length > 0);

            Thread.Sleep(3000);

            string token2 = tokenService.GetToken();
            string tickect2 = tokenService.GetJsTickect();

            Assert.True(token2.Length > 0);
            Assert.True(tickect2.Length > 0);
        }
    }
}
