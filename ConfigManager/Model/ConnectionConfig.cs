using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigManager.Model
{
    [Serializable]
    public class ConnectionConfig : ObservableObject
    {
        private string _name;
        private string _serverName;
        private string _ipAddress;
        private string _port;
        private string _userName;
        private string _password;
        private string _passwordHint;
        private string _description;

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
        public string ServerName
        {
            get
            {
                return _serverName;
            }
            set
            {
                _serverName = value;
                RaisePropertyChanged("ServerName");
            }
        }
        public string IpAddress
        {
            get
            {
                return _ipAddress;
            }
            set
            {
                _ipAddress = value;
                RaisePropertyChanged("IpAddress");
            }
        }
        public string Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
                RaisePropertyChanged("Port");
            }
        }
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                RaisePropertyChanged("UserName");
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }
        public string PasswordHint
        {
            get
            {
                return _passwordHint;
            }
            set
            {
                _passwordHint = value;
                RaisePropertyChanged("PasswordHint");
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }
    }
}
