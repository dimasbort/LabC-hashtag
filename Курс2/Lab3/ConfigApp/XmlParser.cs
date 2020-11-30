using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ConfigApp
{
    class XmlParser : IParse
    {
        public XmlParser()
        { }

        public T Parse<T>(string path) where T : new()
        {
            T property = new T();
            var serializer = new XmlSerializer(typeof(T));

            using (var stream = new FileStream(path, FileMode.Open))
            {
                var xmlReader = XmlReader.Create(stream);

                xmlReader.ReadToDescendant(typeof(T).Name);

                property = (T)serializer.Deserialize(xmlReader);
            }

            return property;
        }
    }
}
