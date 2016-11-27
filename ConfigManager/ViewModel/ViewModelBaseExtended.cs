using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using ConfigManager.Data;
using GalaSoft.MvvmLight.Ioc;
using ConfigManager.Model;

namespace ConfigManager.ViewModel
{
    public class ConfigViewModelBase<T> : ViewModelBase where T : class
    {
        /// <summary>
        /// Overrides the RaisePropertyChanged method, and saves everytime something changes
        /// </summary>
        /// <param name="propertyName"></param>
        public override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            //SimpleIoc.Default.GetInstance<IXmlRepository<DomainCollection>>().SaveContents(Domains);
            base.RaisePropertyChanged(propertyName);
        }
    }
}
