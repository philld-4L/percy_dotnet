using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Percy.Webdriver
{
    /// <summary>
    /// Internal static class to be called only by implementations of IPercyConfig.
    /// </summary>
    internal static class PercyConfigExtensions
    {
        /// <summary>
        /// Helper method that will actually get the Percy DOM to save different IPercyConfig.PercyDOM() implementations
        /// from duplicating the same code
        /// </summary>
        /// <param name="config">The implementation of IPercyConfig that we are extending</param>
        /// <returns>The Percy DOM string</returns>
        internal static string GetPercyDOM(this IPercyConfig config)
        {
            //if we've already fetched it, don't fetch it again
            if (!string.IsNullOrEmpty(_percyDOM))
                return _percyDOM;

            var url = config.PercyServer + "/percy/dom.js";

            var client = new HttpClient();
            _percyDOM = client.GetStringAsync(url).Result;
            return _percyDOM;
        }

        internal static bool GetHealthCheck(this IPercyConfig config)
        {
            //check whether we're past the interval from the last check, if not return that instead
            var now = DateTime.Now;
            if ((config.LastHealthCheck.HasValue) && (config.LastHealthCheck.Value + config.HealthCheckInterval < now))
                return _healthcheck;
            
            //update the last healthcheck
            config.LastHealthCheck = now;

            var url = config.PercyServer + "/percy/healthcheck";
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;

            //evaluate our healthcheck
            _healthcheck = response.StatusCode == System.Net.HttpStatusCode.OK;
            return _healthcheck;

        }

        private static string _percyDOM;
        private static bool _healthcheck;
    }
}
