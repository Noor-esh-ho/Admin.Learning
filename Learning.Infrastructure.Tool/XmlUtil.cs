using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Learning.Infrasturcture.Tool
{
    /// <summary>
    /// 所有xml文件操作
    /// </summary>
    public static class XmlUtil
    {

        /// <summary>
        /// 获取节点下的所有子节点
        /// </summary>
        /// <param name="path">xml地址</param>
        /// <param name="names">节点名称、可以有多级节点.....</param>
        /// <returns>所有要获取的子节点</returns>
        public static XmlNodeList GetNodes(string path, params string[] names)
        {
            XmlDocument myXml = new XmlDocument();
            myXml.Load(path);
            XmlElement xml = myXml.DocumentElement;

            foreach (string item in names)
            {
                xml = GetNode(xml, item);
            }
            return xml.ChildNodes;

        }




        /// <summary>
        /// 获取对应节点信息
        /// </summary>
        /// <param name="xe"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static XmlElement GetNode(XmlElement xe, string name)
        {
            foreach (XmlElement item in xe.ChildNodes)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

    }
}
