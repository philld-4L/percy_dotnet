using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Percy.Webdriver
{
    public class Percy
    {
        public IPercyConfig Config { get; set; }

        public void PostSnapshot(IWebDriver driver, SnapshotProperties snapshotProperties)
        {
            //do the healthcheck
            if (!Config.HealthCheck)
                return;
            //build the snapshot
            var DOMSnapshot = driver.BuildSnapshot(Config, snapshotProperties.EnableJavascript);
            //post the snapshot to the Percy server
            var snapshot = new Snapshot(DOMSnapshot, snapshotProperties, Config.ClientInfo, driver.EnvironmentInfo());
            snapshot.PostToServer(Config.PercyServer);
        }

        public static Percy LaunchFromJSONFile(string configPath)
        {
            var instance = new Percy();
            instance.Config = JPercyConfig.LoadFromFile(configPath);
            return instance;
        }
    }
}
