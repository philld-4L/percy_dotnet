using Percy.Webdriver.Test.Mocks;
using System;
using Xunit;

namespace Percy.Webdriver.Test
{
    public class T_WebdriverExtensions
    {
        [Fact]
        public void _BuildSnapshot()
        {
            var driver = new M_WebDriver();
            var config = new M_PercyConfig { ClientInfo = "Test", M_PercyDOM = "DOM" };
            string actual = driver.BuildSnapshot(config);
            string expected = "return PercyDOM.serialize({ enableJavascript: false})\n";
            Assert.Equal(expected, actual);

            actual = driver.BuildSnapshot(config, true);
            expected = "return PercyDOM.serialize({ enableJavascript: true})\n";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void _EnvironmentInfo()
        {
            var driver = new M_WebDriver();
            var config = new M_PercyConfig { ClientInfo = "Test", M_PercyDOM = "DOM" };
            string actual = driver.EnvironmentInfo();
            Assert.Equal("Percy.Webdriver.Test.Mocks.M_WebDriver", actual);
        }
    }

}
