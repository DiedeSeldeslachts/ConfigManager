using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigManager.Helpers
{
    public class ObservableCascadeCollection<T> : ObservableCollection<T> where T : ObservableObject
    {
        public ObservableCascadeCollection()
        {
            base.CollectionChanged += OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (T item in e.OldItems)
                {
                    //Removed items
                    item.PropertyChanged -= EntityViewModelPropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (T item in e.NewItems)
                {
                    //Added items
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }
            }

            Debug.WriteLine("a config collection has changed");
        }

        public virtual void EntityViewModelPropertyChanged(object sender, EventArgs e)
        {
            ObservableObject observableObj = sender as ObservableObject;
            if (observableObj != null)
            {
                observableObj.RaisePropertyChanged(String.Empty);
                Debug.WriteLine("a domain has changed");
            }
            else
            {
                throw new Exception("sender of propertychanged is not of type ObservableObject");
            }

            //This will get called when the property of an object inside the collection changes
        }
    }
}
