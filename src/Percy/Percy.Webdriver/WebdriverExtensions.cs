using OpenQA.Selenium;
using System;

namespace Percy.Webdriver
{
    /// <summary>
    /// Extension methods for IWebdriver
    /// </summary>
    public static class WebdriverExtensions
    {
        /// <summary>
        /// Capture a snapshot for percy
        /// </summary>
        /// <param name="driver">Webdriver context we are capturing the snapshot from</param>
        public static string BuildSnapshot(this IWebDriver driver, IPercyConfig config, bool enableJavascript = false)
        {
            var jsExe = (IJavaScriptExecutor)driver;
            //fetch the DOM
            jsExe.ExecuteScript(config.PercyDOM());
            string snapshot = "return PercyDOM.serialize({ enableJavascript: "+ enableJavascript.ToString() + "})\n";
            //now create the snapshot
            return jsExe.ExecuteScript(snapshot).ToString();

        }

        /// <summary>
        /// Fetches the environment info for the WebDriver instance being used
        /// </summary>
        /// <param name="driver">Our webdriver instance</param>
        /// <returns>The instance's type</returns>
        public static string EnvironmentInfo(this IWebDriver driver)
        {
            return driver.GetType().FullName;
        }

    
    }
}
