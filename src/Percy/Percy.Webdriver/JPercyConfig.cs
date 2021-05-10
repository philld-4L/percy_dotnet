using Newtonsoft.Json;
using System;
using System.Text;

namespace Percy.Webdriver
{
    /// <summary>
    /// JSON implementation of IPercyConfig interface
    /// </summary>
    public class JPercyConfig : IPercyConfig
    {
        public string PercyServer { get; set; }

        public string ClientInfo => "percy_dotnet/" + this.GetType().Assembly.GetName().Version;

        public bool HealthCheck => this.GetHealthCheck();

        public TimeSpan HealthCheckInterval { get; set ; }
        public DateTime? LastHealthCheck { get ; set ; }

        /// <summary>
        /// Get the PercyDOM js
        /// </summary>
        /// <returns>A string containing the Percy DOM javascript that needs to be executed</returns>
        public string PercyDOM()
        {
            return this.GetPercyDOM();
        }

        /// <summary>
        /// Save the JPercyConfig object as a json file at the supplied path (UTF8 encoding)
        /// </summary>
        /// <param name="path">Full path of the file (including extension)</param>
        public void SaveToFile(string path)
        {
            SaveToFile(path, Encoding.UTF8);
        }

        /// <summary>
        /// Save the JPercyConfig object as a json file at the supplied path
        /// </summary>
        /// <param name="path">Full path of the file (including extension)</param>
        /// <param name="encoding">The encoding the file will be saved in</param>
        public void SaveToFile(string path, Encoding encoding)
        {
            string json = this.ToString();
            System.IO.File.WriteAllText(path, json, encoding);
        }

        /// <summary>
        /// Convert JPercyConfig object to a json string
        /// </summary>
        /// <returns>A string containing a json reprentation of the JPercyConfig object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Createa instance of JPercyConfig from json string at the specified path (UTF8 encoding)
        /// </summary>
        /// <param name="path">Full path to the PercyConfig json object (including extension)</param>
        /// <returns>JPercyConfig object</returns>
        public static JPercyConfig LoadFromFile(string path)
        {
            return LoadFromFile(path, Encoding.UTF8);
        }

        /// <summary>
        /// Create instance of JPercyConfig from json string at the specified path
        /// </summary>
        /// <param name="path">Full path to the JPercyConfig json object (including extension)</param>
        /// <param name="encoding">Encoding the file uses</param>
        /// <returns>JPercyConfig object</returns>
        public static JPercyConfig LoadFromFile(string path, Encoding encoding)
        {
            string json = System.IO.File.ReadAllText(path, encoding);
            return LoadFromString(json);
        }

        /// <summary>
        /// Create instance of JPercyConfig from json string
        /// </summary>
        /// <param name="json">A string containing a json representation of a JPercyConfig object</param>
        /// <returns>A JPercyConfig object</returns>
        public static JPercyConfig LoadFromString(string json)
        {
            return JsonConvert.DeserializeObject<JPercyConfig>(json);
        }
    }
}
