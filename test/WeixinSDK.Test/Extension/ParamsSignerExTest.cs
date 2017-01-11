using System.Collections.Generic;
using Wlitsoft.Framework.WeixinSDK.Extension;
using Xunit;

namespace WeixinSDK.Test.Extension
{
    public class ParamsSignerExTest : TestBase
    {
        [Fact]
        public void GetSignTest()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                {"p1", "p1"},
                { "p2", "p2"}
            };

            string sign = ParamsSignerEx.GetSign(dic);

            Assert.Equal("FA51F2AE815D49B03340352D71775C53", sign);
        }
    }
}
