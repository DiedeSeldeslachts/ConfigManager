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
    public class DomainCollection : ObservableObject
    {
        private ObservableCollection<Domain> _domains;
        public ObservableCollection<Domain> Domains
        {
            get
            {
                if(_domains == null) { _domains = new ObservableCollection<Domain>(); }
                return _domains;
            }
            set
            {
                _domains = value;
                RaisePropertyChanged("Domains");
            }
        }
        public DomainCollection()
        {
            Domains.CollectionChanged += _domains_CollectionChanged;
        }
        private void _domains_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Domain item in e.OldItems)
                {
                    //Removed items
                    item.PropertyChanged -= EntityViewModelPropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Domain item in e.NewItems)
                {
                    //Added items
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }
            }
            RaisePropertyChanged("Domains");
            Debug.WriteLine("a domain collection has changed");
        }
        public virtual void EntityViewModelPropertyChanged(object sender, EventArgs e)
        {
            RaisePropertyChanged("Domains");
            Debug.WriteLine("a domain has changed");
            //This will get called when the property of an object inside the collection changes
        }
    }
}
