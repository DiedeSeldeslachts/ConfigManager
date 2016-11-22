using ConfigManager.Model;
using System.Windows;

namespace ConfigManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DomainTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ProtocolTreeView.ItemsSource = ((Domain)(e.NewValue)).ProtocolSubdevisions;
        }

        private void ProtocolTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ConfigsTreeView.ItemsSource = ((Protocol)(e.NewValue)).ConnectionConfigs;
        }
    }
}
