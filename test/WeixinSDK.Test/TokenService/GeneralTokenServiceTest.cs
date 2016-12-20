using System.Threading;
using Wlitsoft.Framework.Common;
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
            Assert.True(token.Length > 0);

            Thread.Sleep(3000);

            string token2 = tokenService.GetToken();
            Assert.True(token2.Length > 0);
        }
    }
}
