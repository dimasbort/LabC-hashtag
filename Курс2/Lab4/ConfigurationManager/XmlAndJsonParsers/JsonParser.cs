using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConfigurationManager
{
    class JsonParser
    {
        public JsonParser()
        { }

        public T Parse<T>(string path) where T : new()
        {
            T option = new T();

            using (var reader = new StreamReader(path))
            {
                string info = reader.ReadToEnd();

                if (string.IsNullOrWhiteSpace(info))
                {
                    throw new ArgumentNullException("Пустая строка");
                }

                info = FindRequiredOption(info, typeof(T).Name);
                option = JsonSerializer.Deserialize<T>(info);
            }

            return option;
        }

        private string FindRequiredOption(string info, string startPos)
        {
            StringBuilder jsonString = new StringBuilder(info);

            jsonString.Remove(0, info.IndexOf(startPos) + startPos.Length + 3);

            char[] symbols = jsonString.ToString().ToCharArray();

            int brackets = 0;
            int count = 0;

            do
            {
                if (symbols[count] == '{')
                    brackets++;
                if (symbols[count] == '}')
                    brackets--;

                count++;
            } while (brackets != 0);

            info = jsonString.ToString().Substring(0, count);

            return info;
        }
    }
}
