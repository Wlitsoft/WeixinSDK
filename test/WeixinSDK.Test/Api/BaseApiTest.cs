using Wlitsoft.Framework.Common;
using Wlitsoft.Framework.WeixinSDK.Api;
using Wlitsoft.Framework.WeixinSDK.Config.Extension;
using Wlitsoft.Framework.WeixinSDK.Model.BaseApiModel;
using Xunit;

namespace WeixinSDK.Test.Api
{
    public class BaseApiTest
    {
        public BaseApiTest()
        {
            App.Builder.SetWeixinDevConfigByAppSettings();
        }

        [Fact]
        public void GetAccessTokenTest()
        {
            GetAccessTokenResultModel result = BaseApi.GetAccessToken();

            Assert.NotNull(result);
            Assert.NotNull(result.AccessToken);
        }

        [Fact]
        public void GetTickectTest()
        {
            GetAccessTokenResultModel result = BaseApi.GetAccessToken();

            Assert.NotNull(result);
            Assert.NotNull(result.AccessToken);

            GetTickectResultModel tickectResult = BaseApi.GetTickect(result.AccessToken);

            Assert.NotNull(tickectResult);
            Assert.NotNull(tickectResult.Ticket);
        }
    }
}
