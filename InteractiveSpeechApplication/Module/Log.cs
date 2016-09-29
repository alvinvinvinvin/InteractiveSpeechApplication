using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace InteractiveSpeechApplication.Module
{
    class Log
    {
        private List<Session> sessions = new List<Session>();
        public Log() { }
        //Default path to store log file.
        private static string currentDate = DateTime.Now.ToString("yyyy_MM_dd");
        private static string fileExtendtion = ".log";
        private static string fileName = "Han_Chen_TEST_APP_";
        private static string fullFileName = fileName + currentDate + fileExtendtion;
        private string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fullFileName));
        public void recordSession(Session session)
        {
            sessions.Add(session);
        }
        private bool fileExists()
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Generate XML file
        /// </summary>
        public void generateXML()
        {
            XmlDocument doc = new XmlDocument();
            if (fileExists())
            {
                //Read file
                doc.Load(path);
                XmlNodeList root_LOG = doc.GetElementsByTagName("LOG");
                //Add session to it
                List<XmlElement> sessionNodes = generateSessionNodes(doc);
                foreach (XmlElement s in sessionNodes)
                {
                    if(s != null)
                    root_LOG.Item(0).AppendChild(s);
                }
                doc.Save(path);
                Console.Write("XML file has been updated. Press any key to exit.");
            }
            else
            {
                
                XmlElement root_LOG = doc.CreateElement("LOG");
                doc.AppendChild(root_LOG);
                List<XmlElement> sessionNodes = generateSessionNodes(doc);
                foreach (XmlElement s in sessionNodes)
                {
                    root_LOG.AppendChild(s);
                }
                doc.Save(path);
                Console.Write("XML file has been created. Press any key to exit.");
            }
            
            
            Console.ReadKey();
        }

        /// <summary>
        /// Generate session nodes as XML elements
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private List<XmlElement> generateSessionNodes(XmlDocument doc)
        {
            List<XmlElement> sessionList = new List<XmlElement>();
            foreach (Session s in sessions)
            {
                XmlElement node_SESSION = doc.CreateElement("SESSION");
                foreach (Prompt p in s.getPromptList())
                {
                    XmlElement element = null;
                    if (p.GetType() == typeof(SAY))
                    {
                        element = doc.CreateElement("SAY");
                        element.InnerText = p.toString();

                    }
                    else if (p.GetType() == typeof(ASK))
                    {
                        element = doc.CreateElement("ASK");
                        element.SetAttribute("NAME", (p as ASK).getName());
                        element.SetAttribute("RESPONSE", (p as ASK).getResponse());
                        element.InnerText = p.toString();
                    }
                    else if (p.GetType() == typeof(Transfer))
                    {
                        element = doc.CreateElement("TRANSFER");
                        element.SetAttribute("DATE", (p as Transfer).getDATE());
                        element.SetAttribute("CURRENT_TIME", (p as Transfer).getCurrentTime());
                        element.SetAttribute("VALID", (p as Transfer).getValid());
                    }
                    node_SESSION.AppendChild(element);
                }
                sessionList.Add(node_SESSION);
            }
            return sessionList;
        }
    }
}
