using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Percy.Webdriver
{
    internal class Snapshot : SnapshotProperties
    {
        public Snapshot(string domSnapshot, SnapshotProperties properties, string clientInfo, string environmentInfo)
        {
            this.DomSnapshot = domSnapshot;
            this.EnableJavascript = properties.EnableJavascript;
            this.MinHeight = properties.MinHeight;
            this.Name = properties.Name;
            this.PercyCSS = properties.PercyCSS;
            this.Url = properties.Url;
            this.Widths = properties.Widths;
        }
        public string DomSnapshot { get; set; }

        public string ClientInfo { get; set; }
        public string EnvironmentInfo { get; set; }

        public void PostToServer(string serverAddress)
        {
            var client = new HttpClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
            client.PostAsync(serverAddress + "/percy/snapshot", stringContent);
        }
    }
}
