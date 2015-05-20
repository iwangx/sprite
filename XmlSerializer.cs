using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CssSprite
{
    public static class XmlSerializer
    {
        /// <summary>
        /// 保存xml到文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="sourceObj">对象</param>
        public static void SaveToXml(string filePath, object sourceObj)
        {
            if (!string.IsNullOrEmpty(filePath) && sourceObj != null)
            {
                using(FileStream filw =new FileStream(filePath,FileMode.OpenOrCreate)){
                    
                }
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(sourceObj.GetType());
                    xmlSerializer.Serialize(writer, sourceObj);
                }
                
            }
        }

        /// <summary>
        /// 从文件中加载xml对象
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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

        /// <summary>
        /// xml序列成字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string XMLSerialize<T>(T entity)
        {
            StringBuilder buffer = new StringBuilder();
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (TextWriter writer = new StringWriter(buffer))
            {
                serializer.Serialize(writer, entity);
            }

            return buffer.ToString();
        }

        /// <summary>
        /// 字符串转换为xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static T DeXMLSerialize<T>(string xmlString)
        {
            T cloneObject = default(T);

            StringBuilder buffer = new StringBuilder();
            buffer.Append(xmlString);

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (TextReader reader = new StringReader(buffer.ToString()))
            {
                Object obj = serializer.Deserialize(reader);
                cloneObject = (T)obj;
            }
            return cloneObject;
        }
    }
}
