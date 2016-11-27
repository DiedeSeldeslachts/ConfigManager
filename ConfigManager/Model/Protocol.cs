using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigManager.Model
{
    [Serializable]
    public class Protocol : ObservableObject
    {
        public Protocol()
        {
            ConnectionConfigs.CollectionChanged += _connectionConfigs_CollectionChanged;
        }

        private string _name;
        private ObservableCollection<ConnectionConfig> _connectionConfigs;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
        public ObservableCollection<ConnectionConfig> ConnectionConfigs {
            get
            {
                if (_connectionConfigs == null) {
                    _connectionConfigs = new ObservableCollection<ConnectionConfig>();
                }

                return _connectionConfigs;
            }
            set
            {
                _connectionConfigs = value;
                RaisePropertyChanged("ConnectionConfigs");
            }
        }

        private void _connectionConfigs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (ConnectionConfig item in e.OldItems)
                {
                    //Removed items
                    item.PropertyChanged -= EntityViewModelPropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ConnectionConfig item in e.NewItems)
                {
                    //Added items
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }
            }
            RaisePropertyChanged("ConnectionConfigs");
            Debug.WriteLine("a config collection has changed");
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged("ConnectionConfigs");
            Debug.WriteLine("a config has changed");
            //This will get called when the property of an object inside the collection changes
        }
    }
}
