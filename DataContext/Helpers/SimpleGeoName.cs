using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataContextNamespace.Helpers
{
    [XmlRoot]
    public class SimpleGeoName
    {
        [XmlElement]
        public string Id { get; set; }

        [XmlElement]
        public string Name { get; set; }

        [XmlArray("Children")]
        public List<SimpleGeoName> Childrens { get; set; }

        [XmlElement]
        public string FCode { get; set; }

        [XmlElement]
        public string CountryCode { get; set; }

        [XmlElement]
        public string LocalNameEN { get; set; }

        [XmlElement]
        public string LocalNameES { get; set; }

        public string Serialize()
        {
            MemoryStream ms = new MemoryStream();
            StreamWriter writer = new StreamWriter(ms, Encoding.UTF8);
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            serializer.Serialize(writer, this);
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        public SimpleGeoName Deserialize(string xmlString)
        {
            try
            {
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xmlString));
                StreamReader reader = new StreamReader(ms, Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                SimpleGeoName instance = (SimpleGeoName)serializer.Deserialize(reader);
                return instance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
