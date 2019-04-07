using System;
using System.IO;
using System.Xml;

namespace utils
{
    public class XmlSerializer
    {
        public string Serialize<T>(T item) where T : class
        {
            if(item == null)
                throw new ArgumentNullException(nameof(item));

            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();

            var xmlWriter = new XmlTextWriter(stringWriter);
            serializer.Serialize(xmlWriter, item);

            return stringWriter.ToString();
        }
    }
}