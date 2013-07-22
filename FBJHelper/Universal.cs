using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows;
using System.Xml;
using System.Net;
using System.Windows.Input;

namespace FBJHelper
{
    public class Universal<T> where T : class
    {
        /// <summary>
        /// 主要用于将xml反序列化成对应的实体或实体集合
        /// T 为要反序列化成对象的类型
        ///  参数xmlStr 为要进行序列化的字符串
        /// </summary>
        /// <param name="xmlStr"></param>
        /// <returns></returns>
        public static T DeSerializeXMLToObject(string xmlStr)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                System.IO.StringReader reader = new System.IO.StringReader(xmlStr);
                T t = serializer.Deserialize(reader) as T;
                return t;
            }
            catch (Exception e)
            {
                //MessageBox.Show(string.Format("数据转换错误：{0}\r\n", e.Message));
            }
            return null;
        }

        /// <summary>
        /// 对象序列化成xml格式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerialObjectToXML(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            System.Text.StringBuilder output = new System.Text.StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter(output);
            serializer.Serialize(writer, obj);
            return output.ToString();
        }

        /// <summary>
        /// 深度克隆某一实体.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T Clone(T t)
        {
            return Newtonsoft.Json.JavaScriptConvert.DeserializeObject<T>(Newtonsoft.Json.JavaScriptConvert.SerializeObject(t));
        }
    }
}
