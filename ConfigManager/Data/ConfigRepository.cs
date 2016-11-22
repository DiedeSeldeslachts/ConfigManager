using ConfigManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigManager.Data
{
    public class DomainRepository : IXmlRepository<DomainCollection>
    {
        public string XmlDocumentPath { get; set; }

        public DomainCollection GetContents()
        {
            return new DomainCollection()
            {
                new Domain() {
                    Name = "Scooore",
                    ProtocolSubdevisions = new System.Collections.ObjectModel.ObservableCollection<Protocol>() {
                        new Protocol() {
                            Name = "FTP",
                            ConnectionConfigs = new System.Collections.ObjectModel.ObservableCollection<ConnectionConfig>()
                            {
                                new ConnectionConfig()
                                {
                                    Name = "testServer"
                                }
                            }
                        }
                    }
                }
            };
        }


    }
}
