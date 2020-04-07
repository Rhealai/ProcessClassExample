using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XmlConsole_002
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("XMLFile1.xml");

            XmlNode root = xDoc.DocumentElement;
            //XmlNode user;
            XmlNodeList nodeList;
            nodeList = root.SelectNodes("descendant::user");

            XmlElement xe;
            for (int i = 0; i < nodeList.Count; i++)
            {
                xe = (XmlElement)nodeList.Item(i);
                if (xe.InnerText.Trim() == "wcc")
                {
                    //Modified Specified attributes.
                    //xe.LastChild.Attributes["time"].Value = DateTime.Now.ToString();

                    //Remove Node(element)
                    //    root.RemoveChild(xe); 

                }
            }

            nodeList = root.SelectNodes("descendant::user");

            foreach (XmlNode OnNode in nodeList)
            {
                Console.WriteLine(OnNode.InnerText.Trim());
                Console.WriteLine(OnNode.LastChild.Attributes["time"].Value);
            }


            Console.ReadKey();


        }
    }
}
