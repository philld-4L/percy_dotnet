using System;

namespace Percy.Webdriver
{
    public interface IPercyConfig
    {
        /// <summary>
        /// Percy Server address
        /// </summary>
        string PercyServer { get; set; }
        string PercyDOM();
        string ClientInfo { get; }
    }
}
