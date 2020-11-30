using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConfigApp
{
    public class Paths
    {
        [JsonPropertyName("Source")]
        public string Source { get; set; }
        [JsonPropertyName("Target")]
        public string Target { get; set; }
        [JsonPropertyName("Logger")]
        public string Logger { get; set; }

        public Paths()
        { }
    }
}
