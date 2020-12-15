using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DirectoryMonitorService
{
    public class PathOption
    {
        [JsonPropertyName("sourceDirectory")]
        [XmlElement(ElementName = "sourceDirectory")]
        public string SourceDirectory { get; set; }

        [JsonPropertyName("targetDirectory")]
        [XmlElement(ElementName = "targetDirectory")]
        public string TargetDirectory { get; set; }

        [JsonPropertyName("DBProperty1")]
        [XmlElement(ElementName = "DBProperty1")]
        public string DBPath1 { get; set; }

        public PathOption()
        { }
    }
}
