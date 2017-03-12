using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializableStyle
{
    public class StyleSerializer
    {
        public static string SerializeStyle(CustomStyle s)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CustomStyle));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, s);
            string serialized = writer.ToString();
            return serialized;
        }

        public static CustomStyle DeserializeStyle(string serialized)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CustomStyle));
            StringReader reader = new StringReader(serialized);
            CustomStyle deser = (CustomStyle)serializer.Deserialize(reader);
            return deser;
        }
    }
}
