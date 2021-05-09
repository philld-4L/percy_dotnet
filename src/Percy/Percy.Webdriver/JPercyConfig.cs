using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Percy.Webdriver
{
    public class JPercyConfig : IPercyConfig
    {
        public string PercyServer { get; set; }

        public string ClientInfo => "percy_dotnet/" + this.GetType().Assembly.GetName().Version;

        public bool HealthCheck => this.GetHealthCheck();

        public TimeSpan HealthCheckInterval { get; set ; }
        public DateTime? LastHealthCheck { get ; set ; }

        public string PercyDOM()
        {
            return this.GetPercyDOM();
        }

        public static JPercyConfig LoadFromFile(string path)
        {
            string json = System.IO.File.ReadAllText(path);
            return LoadFromString(json);
        }

        public static JPercyConfig LoadFromString(string json)
        {
            return JsonConvert.DeserializeObject<JPercyConfig>(json);
        }
    }
}
