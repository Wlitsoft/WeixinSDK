using Wlitsoft.Framework.WeixinSDK.Api;
using Wlitsoft.Framework.WeixinSDK.Model.BaseApiModel;
using Xunit;

namespace WeixinSDK.Test.Api
{
    public class BaseApiTest : TestAppBase
    {
        [Fact]
        public void GetAccessTokenTest()
        {
            GetAccessTokenModel result = BaseApi.GetAccessToken();

            Assert.NotNull(result);
            Assert.NotNull(result.AccessToken);
        }
    }
}
