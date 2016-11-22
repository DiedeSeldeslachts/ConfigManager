using ConfigManager.Data;
using ConfigManager.Model;
using ConfigManager.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigManager.DI
{
    public class IocInitializer
    {
        public IocInitializer()
        {
            SimpleIoc.Default.Register<IXmlRepository<DomainCollection>, DomainRepository>();
        }
    }
}
