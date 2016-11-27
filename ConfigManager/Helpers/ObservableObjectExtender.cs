using ConfigManager.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConfigManager.Helpers
{
    public static class ObservableObjectExtender
    {
        ///// <summary>
        ///// Overrides the RaisePropertyChanged method, and saves everytime something changes
        ///// </summary>
        ///// <param name="propertyName"></param>
        //public static void RaisePropertyChanged(this DomainCollection collection, [CallerMemberName] string propertyName = null)
        //{
        //    //SimpleIoc.Default.GetInstance<IXmlRepository<DomainCollection>>().SaveContents(Domains);
        //    base.RaisePropertyChanged(propertyName);
        //}
        //public static void RaisePropertyChanged()
        //Extend the ObservableObject to incorporate a save feature
    }
}
