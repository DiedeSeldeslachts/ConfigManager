using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace ConfigManager.Model
{
    [Serializable]
    public class Domain : ObservableObject
    {
        private string _name;
        public string Name {
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
        public ObservableCollection<Protocol> ProtocolSubdevisions { get; set; }
    }
}
