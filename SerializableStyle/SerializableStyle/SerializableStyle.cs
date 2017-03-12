using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SerializableStyle
{
    public class CustomStyle : Style, IXmlSerializable
    {

        public CustomStyle()
        {

        }

        public CustomStyle(Type TargetType)
        {
            this.TargetType = TargetType;

        }

        public XmlSchema GetSchema()
        {
            return (null);
        }

        public void ReadXml(XmlReader reader)
        {


            reader.MoveToContent();

            string target = reader.GetAttribute("Target");
            Type type = Type.GetType(target);
            while (reader.Read())
            {
                string pName = reader.GetAttribute("Property") + "Property";
                pName = pName.Trim();
                string pValue = reader.GetAttribute("Value");
                FieldInfo info = type.GetField(pName, BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
                DependencyProperty property = info.GetValue(null) as DependencyProperty;
                double d;
                Double.TryParse((string)pValue, out d);
                this.Setters.Add(new Setter(property, d));

            }


        }

        public void WriteXml(XmlWriter writer)

        {


            writer.WriteAttributeString("Target", this.TargetType.AssemblyQualifiedName);
            foreach (Setter s in this.Setters)
            {
                writer.WriteStartElement("Setter");
                writer.WriteAttributeString("Property", s.Property.Name);
                writer.WriteAttributeString("Value", s.Value.ToString());
                writer.WriteEndElement();
            }

            return;
        }


    }
}
