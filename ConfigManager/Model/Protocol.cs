using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigManager.Model
{
    [Serializable]
    public class Protocol : ObservableObject
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name == value)
                    return;

                _name = value;
                RaisePropertyChanged("Name");
            }
        }
        public ObservableCollection<ConnectionConfig> ConnectionConfigs { get; set; }
    }
}
