using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace LandWin.Shared
{
    public class SqlDataList : List<IDictionary<string,object>>
    {
        public XmlDocument ToXml()
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement root = xmlDoc.CreateElement("data");

            xmlDoc.AppendChild(root);

            foreach (IDictionary<string, object> info in this)
            {
                XmlElement element = xmlDoc.CreateElement("item");
                root.AppendChild(element);
                foreach (KeyValuePair<string, object> item in info)
                {
                    XmlElement ID = xmlDoc.CreateElement(item.Key);
                    ID.InnerText = item.Value.ToString();
                    element.AppendChild(ID);
                }
            }


            return xmlDoc;
        }
    }
}
