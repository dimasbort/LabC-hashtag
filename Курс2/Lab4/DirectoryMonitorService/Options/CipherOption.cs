using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DirectoryMonitorService
{
    public class CipherOption
    {
        [JsonPropertyName("cipherkey")]
        [XmlElement(ElementName = "cipherkey")]
        public string Key { get; set; }

        public CipherOption()
        { }

        //генератор повторений пароля
        private string GetRepeatKey(int textLength)
        {
            var r = Key;
            while (r.Length < textLength)
            {
                r += r;
            }

            return r.Substring(0, textLength);
        }

        //метод шифрования/дешифровки
        private string Cipher(string text)
        {
            var currentKey = GetRepeatKey(text.Length);
            var res = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                res += ((char)(text[i] ^ currentKey[i])).ToString();
            }

            return res;
        }

        //шифрование текста
        public string Encrypt(string plainText, string password)
            => Cipher(plainText);

        //расшифровка текста
        public string Decrypt(string encryptedText, string password)
            => Cipher(encryptedText);
    }
}
