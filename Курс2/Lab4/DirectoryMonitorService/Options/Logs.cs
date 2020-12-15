using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DirectoryMonitorService
{
    public class Logs
    {
        [JsonPropertyName("logProperty")]
        [XmlElement(ElementName = "logProperty")]
        public string Log { get; set; }

        public Logs()
        { }
    }
}
