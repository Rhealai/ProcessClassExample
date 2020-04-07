using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;


namespace XmlConsole_001
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test");
            //=======================================================
            //XMLexpample xEx = new XMLexpample();
            //xEx.AddElement("Rioyclai","Male","36","Pass","Taiwan");
            //xEx.showXml();
            //xEx.displayXml();


            XDocument xDoc = XDocument.Load("User.xml");
            

            // with Descendents
            var person = xDoc.Descendants("person");
            Console.WriteLine(person);

            // with Element
            var customer = xDoc.Root.Element("person");
            var optinStatus = customer.Element("pass");
            Console.WriteLine(optinStatus.Value);


            // for attribute
            var response = xDoc.Descendants("person").Single();
            var attr = response.Attribute("name");
            Console.WriteLine(attr.Value);

            //=======================================================
            Console.ReadKey();

        }
        //=======================================================





        //=======================================================
        private void xmlCreate()
        {
            XmlDocument doc = new XmlDocument();
            //建立根節點 Department
            XmlElement department = doc.CreateElement("Department");
            doc.AppendChild(department);
            //建立子節點 ChatRM
            XmlElement ChatRM = doc.CreateElement("ChatRM");
            ChatRM.SetAttribute("ID", "001");    //建立ID=001的屬性
            //加入至Department節點底下
            department.AppendChild(ChatRM);

            XmlElement members = doc.CreateElement("Members");//建立節點
            //加入至ChatRM節點底下
            ChatRM.AppendChild(members);

            XmlElement info = doc.CreateElement("Information");
            info.SetAttribute("User", "余小章");
            info.SetAttribute("EnrollDate", DateTime.Now.ToString());
            info.SetAttribute("IP", "127.0.0.1");

            //加入至members節點底下
            members.AppendChild(info);
            doc.Save("Test.xml");


        }
    }
    class XMLexpample
    {
        XmlDocument xmlDoc = new XmlDocument();
        bool isFileExisted;

        public XMLexpample()
        {
        }

        private void CreateRootElement()
        {
            XmlDeclaration declaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(declaration);
            xmlDoc = new XmlDocument();
            XmlElement xmlelem = xmlDoc.CreateElement("user");
            xmlDoc.AppendChild(xmlelem);
            //儲存建立好的XML文件
            xmlDoc.Save("User.xml");
        }

        #region XML基本操作
        //load xml file 
        private void LoadXml()
        {
            if (isFileExisted == false)
            {
                xmlDoc = new XmlDocument();
                CreateRootElement();
                isFileExisted = true;
                return;
            }
            xmlDoc = new XmlDocument();
            xmlDoc.Load("User.xml");
        }

        //新增節點 
        public void AddElement(string name, string sex, string age, string pass, string address)
        {
            //裝載Xml檔案
            LoadXml();
            //獲取根節點
            XmlNode xmldocSelect = xmlDoc.SelectSingleNode("user");
            //建立元素Person
            XmlElement personElement = xmlDoc.CreateElement("person");
            //person節點的三個屬性
            personElement.SetAttribute("name", name);
            personElement.SetAttribute("sex", sex);
            personElement.SetAttribute("age", age);
            //建立一個新的元素
            XmlElement passElement = xmlDoc.CreateElement("pass");
            //設定節點的串聯值
            passElement.InnerText = pass;
            //將新建立的節點pass新增為person節點的子節點
            personElement.AppendChild(passElement);
            XmlElement addrElement = xmlDoc.CreateElement("Address");
            addrElement.InnerText = address;
            personElement.AppendChild(addrElement);
            //新增person節點
            xmldocSelect.AppendChild(personElement);
            xmlDoc.Save("user.xml");
        }

        //輸出xml文件
        public void showXml()
        {
            LoadXml();
            //獲取根節點
            XmlElement rootElement = xmlDoc.DocumentElement;
            //挨個查詢其下的子節點
            foreach (XmlElement childElement in rootElement)
            {
                //分別輸出子節點屬性
                Console.WriteLine(childElement.GetAttribute("name"));
                Console.WriteLine(childElement.GetAttribute("sex"));
                Console.WriteLine(childElement.GetAttribute("age"));
                //獲取孫節點列表
                XmlNodeList grandsonNodes = childElement.ChildNodes;
                foreach (XmlNode grandsonNode in grandsonNodes)
                {
                    //顯示孫節點文字
                    Console.WriteLine(grandsonNode.InnerText);
                }
            }
        }

        //修改節點 
        public void UpdateElement(string name)
        {
            LoadXml();
            //獲取根節點的所有子節點 
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("user").ChildNodes;
            foreach (XmlNode childNode in nodeList)
            {
                XmlElement childElement = (XmlElement)childNode;
                //如果找到姓名為name的節點
                if (childElement.GetAttribute("name") == name)
                {
                    childElement.SetAttribute("name", "BYH");
                    //如果下面有子節點在下走 
                    XmlNodeList grandsonNodes = childElement.ChildNodes;
                    //繼續獲取xe子節點的所有子節點 
                    foreach (XmlNode grandsonNode in grandsonNodes)
                    {
                        XmlElement grandsonElement = (XmlElement)grandsonNode;
                        //如果找到節點名為pass的孫子節點
                        if (grandsonElement.Name == "pass")
                        {
                            grandsonElement.InnerText = "66666";
                            break;
                        }
                    }
                    break;
                }
            }
            xmlDoc.Save("user.xml");
        }
        public void deleteNode(string name)
        {
            LoadXml();
            //獲取根節點的所有子節點
            XmlNodeList childNodes = xmlDoc.SelectSingleNode("user").ChildNodes;
            foreach (XmlNode childNode in childNodes)
            {
                XmlElement childElement = (XmlElement)childNode;
                if (childElement.GetAttribute("name") == name)
                {
                    //刪除name屬性 
                    childElement.RemoveAttribute("name");
                    //刪除該節點的全部內容
                    childElement.RemoveAll();
                    break;
                }
            }
            xmlDoc.Save("user.xml");
        }

        #endregion

        public void displayXml() 
        {
            XmlNodeList elemList = xmlDoc.GetElementsByTagName("person");
            for (int i = 0; i < elemList.Count; i++)
            {
                Console.WriteLine(elemList[i].InnerXml);
            }  
        }
    }

}
