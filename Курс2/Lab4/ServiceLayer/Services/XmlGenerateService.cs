using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using DBModels.Entities;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class XmlGenerateService<T> : IXmlGenerateService
    {
        private readonly string pathToXml;

        public XmlGenerateService(string path)
        {
            pathToXml = path;
        }

        public void XmlGenerate<T>(IEnumerable<T> info)
        {
            try
            {
                List<T> emp = new List<T>(info);

                XmlSerializer formatter = new XmlSerializer(typeof(List<T>));

                using (FileStream fs = new FileStream(pathToXml, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, emp);
                }
            }
            catch (Exception trouble)
            {
                throw trouble;
            }

        }
    }
}
