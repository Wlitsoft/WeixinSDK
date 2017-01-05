using Wlitsoft.Framework.WeixinSDK.Api;
using Wlitsoft.Framework.WeixinSDK.Model.UserManagementApiModel;
using Xunit;

namespace WeixinSDK.Test.Api
{
    public class UserManagementApiTest : TestBase
    {
        [Fact]
        public void GetUserInfoTest()
        {
            GetUserInfoResultModel result = UserManagementApi.GetUserInfo(base.TestOpenId);

            Assert.NotNull(result);
            Assert.Equal(0, result.ErrorCode);
            Assert.True(result.OpenID.Length > 0);
        }
    }
}
