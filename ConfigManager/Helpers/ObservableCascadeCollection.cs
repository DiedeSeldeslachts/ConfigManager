//using GalaSoft.MvvmLight;
//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConfigManager.Helpers
//{
//    public class ObservableCascadeCollection<T> where T : ObservableObject
//    {
//        private void _connectionConfigs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
//        {
//            if (e.Action == NotifyCollectionChangedAction.Remove)
//            {
//                foreach (T item in e.OldItems)
//                {
//                    //Removed items
//                    item.PropertyChanged -= EntityViewModelPropertyChanged;
//                }
//            }
//            else if (e.Action == NotifyCollectionChangedAction.Add)
//            {
//                foreach (T item in e.NewItems)
//                {
//                    //Added items
//                    item.PropertyChanged += EntityViewModelPropertyChanged;
//                }
//            }
//            RaisePropertyChanged(String.Empty);
//            Debug.WriteLine("a config collection has changed");
//        }
//    }
//}
