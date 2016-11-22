using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigManager.Data
{
    public interface IXmlRepository<T> where T : class
    {
        string XmlDocumentPath { get; set; }
        T GetContents();
    }
}
