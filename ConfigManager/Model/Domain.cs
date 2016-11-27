using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace ConfigManager.Model
{
    [Serializable]
    public class Domain : ObservableObject
    {
        public Domain()
        {
            ProtocolSubdevisions.CollectionChanged += _protocolSubdevisions_CollectionChanged;
        }

        private string _name;
        private ObservableCollection<Protocol> _protocolSubdevisions;
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
        public ObservableCollection<Protocol> ProtocolSubdevisions
        {
            get
            {
                if (_protocolSubdevisions == null) { _protocolSubdevisions = new ObservableCollection<Protocol>(); }
                return _protocolSubdevisions;
            }
            set
            {
                _protocolSubdevisions = value;
                RaisePropertyChanged("ProtocolSubdevisions");
            }
        }

        private void _protocolSubdevisions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Protocol item in e.OldItems)
                {
                    //Removed items
                    item.PropertyChanged -= EntityViewModelPropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Protocol item in e.NewItems)
                {
                    //Added items
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }
            }
            RaisePropertyChanged("ProtocolSubdevisions");
            Debug.WriteLine("a protocol collection has changed");
        }
        public void EntityViewModelPropertyChanged(object sender, EventArgs e)
        {
            RaisePropertyChanged("ProtocolSubdevisions");
            Debug.WriteLine("a protocol has changed");
            //This will get called when the property of an object inside the collection changes
        }
    }
}
