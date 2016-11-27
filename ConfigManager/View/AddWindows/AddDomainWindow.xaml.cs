using ConfigManager.Model;
using ConfigManager.ViewModel;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ConfigManager.View.AddWindows
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddDomainWindow : Window
    {
        public AddDomainWindow()
        {
            InitializeComponent();
        }

        //private void AddButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Domain domain = new Domain()
        //    {
        //        Name = NameText.Text
        //    };

        //    MainViewModel viewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
        //    viewModel.Domains.Add(domain);
        //}
    }
}
