using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
//using BillingSystem.Models;
using System.IO;
using System.Data.Common;

namespace FBJHelper
{
    public sealed class OperateXml
    {
        public Type inType { get; set; }

        public OperateXml()
        {
        }
        /// <summary>
        /// 判断xml文件是否存在
        /// </summary>
        /// <param name="xmlPath">文件路径</param>
        /// <param name="xmlName">文件名称</param>
        /// <returns></returns>
        public bool XmlIsExist(string xmlPath, string xmlName)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(string.Concat(@"", xmlPath, xmlName));
                return fileInfo.Exists;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void InsertOrCreates(string xmlPath, string xmlName, string[] value, string rootName, string[] xmlElmentNode)
        {
            if (XmlIsExist(xmlPath, xmlName))
            {
                InsertXml(xmlPath,xmlName,value,xmlElmentNode);
            }
            else
            {
                CreateXml(xmlPath, xmlName, value, xmlElmentNode);
            }
        }

        public void CreateXml(string xmlPath, string xmlName, string[] value, string[] xmlElementNode)
        {
            try
            {
                string str = inType.ToString();
                if (str.Length < 5)
                {
                    return;
                }
                string rootName = str.Substring(str.Length - 5, 4);
                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(dec);

                XmlElement root = doc.CreateElement(rootName);
                doc.AppendChild(root);
                XmlNode childElement = doc.CreateElement(str);
                for (int i = 0; i < xmlElementNode.Length; i++)
                {
                    XmlElement xe = doc.CreateElement(xmlElementNode[i]);
                    xe.InnerText = value[i];
                    childElement.AppendChild(xe);
                }
                root.AppendChild(childElement);
                doc.Save(string.Concat(@"", xmlPath, xmlName));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InsertXml(string xmlPath, string xmlName, string[] value, string[] xmlElementNode)
        {
            try
            {
                string str = inType.ToString();
                if (str.Length < 5)
                {
                    return;
                }
                string rootName = str.Substring(str.Length - 5, 4);
                XmlDocument doc = new XmlDocument();
                doc.Load(string.Concat(@"", xmlPath, xmlName));
                XmlNode root = doc.SelectSingleNode(rootName);
                XmlElement childElement = doc.CreateElement(str);
                for (int i = 0; i < xmlElementNode.Length; i++)
                {
                    XmlElement xe = doc.CreateElement(xmlElementNode[i]);
                    xe.InnerText = value[i];
                    childElement.AppendChild(xe);
                }

                root.AppendChild(childElement);
                doc.Save(string.Concat(@"", xmlPath, xmlName));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateXml(string xmlPath,string xmlName,string OperValue,string newValue,string operName)
        {
            try
            {
                bool breakAll=false;
                string str = inType.ToString();
                if (str.Length < 5)
                {
                    return;
                }
                string rootName = str.Substring(str.Length-5,4);
                XmlDocument doc = new XmlDocument();
                doc.Load(string.Concat(@"",xmlPath,xmlName));
                XmlNodeList list = doc.SelectSingleNode(rootName).ChildNodes;
                foreach (XmlNode node in list)
                {
                    if (breakAll) break;
                    XmlElement xe = (XmlElement)node;
                    foreach (XmlNode xn in xe.ChildNodes)
                    {
                        XmlElement x = (XmlElement)xn;
                        if (x.Name == operName && x.InnerText == OperValue)
                        {
                            x.InnerText = newValue;
                            breakAll = true;
                            break;
                        }
                    }
                }
                doc.Save(string .Concat(@"",xmlPath,xmlName));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteXml(string xmlPath, string xmlName, string OperValue, string newValue, string operName)
        {
            try
            {
                string str = inType.ToString();
                if (str.Length < 5)
                {
                    return;
                }
                string rootName = str.Substring(str.Length-5,4);
                XmlDocument doc = new XmlDocument();
                doc.Load(string.Concat(@"",xmlPath,xmlName));
                XmlNodeList list = doc.SelectSingleNode(rootName).ChildNodes;
                bool breakAll = false;
                foreach (XmlNode node in list)
                {
                    if (breakAll)
                    {
                        return;
                    }
                    XmlElement xe = (XmlElement)node;
                    foreach (XmlNode xn in xe.ChildNodes)
                    {
                        XmlElement x = (XmlElement)xn;
                        if (x.Name == operName && x.InnerText==OperValue)
                        {
                            x.InnerText = newValue;
                            breakAll = true;
                            break;
                        }
                    }
                }
                doc.Save(string.Concat(@"",xmlPath,xmlName));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void GetXml(string xmlPath)
        {
            
            //XmlTextReader reader = null;
            //try
            //{
            //    reader = new XmlTextReader(xmlPath);
            //    string str = string.Empty;
            //    while (reader.Read())
            //    {
            //        if (reader.NodeType == XmlNodeType.Element)
            //        {
            //            if (reader.LocalName.Equals("sign"))
            //            {
            //                str = reader.ReadString();
            //                break;
            //            }
            //        }
            //    }
            //    return str;
            //}
            //catch
            //{
            //    throw;
            //}
            //finally
            //{
            //    if (reader != null)
            //    {
            //        reader.Close();
            //        reader = null;
            //    }
            //}
        }

        //public List<T> GetXml<T>(string xmlPath, string xmlName, string[] elementNodes, Type[] type) where T : class
        //{
        //    XmlTextReader reader = null;
        //    List<T> list = new List<T>();
        //    try
        //    {
        //        reader = new XmlTextReader(string.Concat(@"", xmlPath, xmlName));
        //        string str = string.Empty;
        //        while (reader.Read())
        //        {
        //            if (reader.NodeType == XmlNodeType.Element)
        //            {
        //                for (int i = 0; i < elementNodes.Length; i++)
        //                {
        //                    if (reader.Name == elementNodes[i])
        //                    {
        //                        if (type[i]==decimal)
        //                        {
                                    
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        //public void Dispose()
        //{
        //    this.Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!disposing)
        //        return;
        //}
    }
}
