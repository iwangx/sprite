using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CssSprite
{
    public static class XmlSerializer
    {
        public static void SaveToXml(string filePath, object sourceObj)
        {
            if (!string.IsNullOrEmpty(filePath) && sourceObj != null)
            {
                using(FileStream filw =new FileStream(filePath,FileMode.OpenOrCreate)){
                    
                }
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    /*
                    System.Xml.Serialization.XmlSerializer xmlSerializer = string.IsNullOrEmpty(xmlRootName) ?
                        new System.Xml.Serialization.XmlSerializer(type) :
                        new System.Xml.Serialization.XmlSerializer(type, new XmlRootAttribute(xmlRootName));
                     */
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(sourceObj.GetType());
                    xmlSerializer.Serialize(writer, sourceObj);
                }
                /*
                if (!File.Exists(filePath)) 
                {
                   File.Create(filePath);
                }
                */
                //type = type != null ? type : sourceObj.GetType();
                
            }
        }

        public static object LoadFromXml(string filePath, Type type)
        {
            object result = null;
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
                    result = xmlSerializer.Deserialize(reader);
                }
            }
            return result;
        }
    }
}
