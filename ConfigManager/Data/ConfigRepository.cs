using ConfigManager.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ConfigManager.Data
{
    public class DomainRepository : IXmlRepository<DomainCollection>
    {
        public string XmlDocumentPath { get; set; }

        public DomainRepository()
        {
            XmlDocumentPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["configFilePath"].ToString());
        }
        public DomainCollection GetContents()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(XmlDocumentPath);
                string xmlString = document.OuterXml;
                using (StringReader read = new StringReader(xmlString))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(DomainCollection));
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        return (DomainCollection)serializer.Deserialize(reader);
                    }
                }
            }catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                //TODO: log
                return new DomainCollection();
            }
            //return new DomainCollection()
            //{
            //    new Domain() {
            //        Name = "Scooore",
            //        ProtocolSubdevisions = new System.Collections.ObjectModel.ObservableCollection<Protocol>() {
            //            new Protocol() {
            //                Name = "FTP",
            //                ConnectionConfigs = new System.Collections.ObjectModel.ObservableCollection<ConnectionConfig>()
            //                {
            //                    new ConnectionConfig()
            //                    {
            //                        Name = "testServer"
            //                    }
            //                }
            //            }
            //        }
            //    }
            //};
        }

        public void SaveContents(DomainCollection contents)
        {
            try
            {
                XmlDocument document = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(typeof(DomainCollection));
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, contents);
                    stream.Position = 0;
                    document.Load(stream);
                    document.Save(XmlDocumentPath);
                }
            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                //TODO: LOG
            }
              
        }
    }
}
