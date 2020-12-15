using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ConfigurationManager
{
    class XmlParser
    {
        public XmlParser()
        { }

        public T Parse<T>(string path) where T : new()
        {
            T option = new T();
            var formatter = new XmlSerializer(typeof(T));


            using (var reader = new StreamReader(path))
            {
                using (var xmlReader = XmlReader.Create(reader))
                {
                    xmlReader.ReadToDescendant(typeof(T).Name);

                    option = (T)formatter.Deserialize(xmlReader);
                }
            }

            return option;
        }
    }
}
