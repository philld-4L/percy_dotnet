using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percy.Webdriver.Test.Mocks
{
    internal class M_PercyConfig : IPercyConfig
    {
        
        public string PercyServer { get; set; }

        public string ClientInfo { get; set; }

        public string PercyDOM()
        {
            return M_PercyDOM;
        }

        public string M_PercyDOM { get; set; }
        public bool HealthCheck { get; set; }
        public TimeSpan HealthCheckInterval { get; set; }
        public DateTime? LastHealthCheck { get; set; }
    }
}
