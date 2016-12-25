using Wlitsoft.Framework.WeixinSDK.TokenService;
using Xunit;

namespace WeixinSDK.Test.TokenService
{
    public class DebugTokenServiceTest
    {
        [Fact]
        public void GetTokenTest()
        {
            DebugTokenService tokenService = new DebugTokenService()
            {
                Token = "token11111"
            };

            string token = tokenService.GetToken();

            Assert.NotNull(token);
            Assert.Equal("token11111", token);
        }
    }
}
