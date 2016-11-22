using ConfigManager.DI;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System.Windows;

namespace ConfigManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            IocInitializer initializer = new IocInitializer();
        }
    }
}
