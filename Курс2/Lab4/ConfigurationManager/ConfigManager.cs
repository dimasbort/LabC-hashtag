using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationManager
{
    public class ConfigManager
    {
        public ConfigManager()
        { }

        public T GetOption<T>(string path) where T : new()
        {
            T option = new T();

            if (path.Contains(".xml"))
            {
                XmlParser parser = new XmlParser();
                option = parser.Parse<T>(path);
            }
            else if (path.Contains(".json"))
            {
                JsonParser parser = new JsonParser();
                option = parser.Parse<T>(path);
            }
            else
            {
                throw new IOException("Файл с неправильным расширением");
            }

            return option;
        }
    }
}
