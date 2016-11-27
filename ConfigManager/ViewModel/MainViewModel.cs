using ConfigManager.Data;
using ConfigManager.Model;
using ConfigManager.View;
using ConfigManager.View.AddWindows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace ConfigManager.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private DomainCollection _domainManager;
        private Domain _currentDomain;
        private Protocol _currentProtocol;
        private ConnectionConfig _currentConfig;

        public DomainCollection DomainManager
        {
            get
            {
                if (_domainManager == null)
                {
                    _domainManager = SimpleIoc.Default.GetInstance<IXmlRepository<DomainCollection>>().GetContents();
                }
                return _domainManager;
            }
            set
            {
                _domainManager = value;
                RaisePropertyChanged("DomainManager");
            }
        }
        public Domain CurrentDomain
        {
            get
            {
                if (_domainManager == null)
                {
                    return new Domain() { Name = "Domain1" };
                }
                return _currentDomain;
            }
            set
            {
                _currentDomain = value;
                RaisePropertyChanged("CurrentDomain");
            }
        }
        public Protocol CurrentProtocol
        {
            get
            {
                if (_currentProtocol == null)
                {
                    return new Protocol() { Name = "Domain1" };
                }
                return _currentProtocol;
            }
            set
            {
                _currentProtocol = value;
                RaisePropertyChanged("CurrentProtocol");
            }
        }
        public ConnectionConfig CurrentConfig
        {
            get
            {
                return _currentConfig;
            }
            set
            {
                _currentConfig = value;
                RaisePropertyChanged("CurrentConfig");
            }
        }

        #region Commands
        public RelayCommand ShowAddDomainCommand
        {
            get;
            private set;
        }
        public RelayCommand ShowAddProtocolCommand
        {
            get;
            private set;
        }
        public RelayCommand ShowAddConfigCommand
        {
            get;
            private set;
        }
        public RelayCommand<string> AddDomainCommand
        {
            get;
            private set;
        }
        public RelayCommand<string> AddProtocolCommand
        {
            get;
            private set;
        }
        public RelayCommand<ConnectionConfig> AddConfigCommand
        {
            get;
            private set;
        }
        public RelayCommand<string> DeleteDomainCommand
        {
            get;
            private set;
        }
        public RelayCommand<string> DeleteProtocolCommand
        {
            get;
            private set;
        }
        public RelayCommand<ConnectionConfig> DeleteConfigCommand
        {
            get;
            private set;
        }
        public RelayCommand<Domain> ChangeDomainCommand
        {
            get;
            private set;
        }
        public RelayCommand<Protocol> ChangeProtocolCommand
        {
            get;
            private set;
        }
        public RelayCommand<ConnectionConfig> ChangeConfigCommand
        {
            get;
            private set;
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ShowAddDomainCommand = new RelayCommand(ShowAddDomainWindow);
            ShowAddProtocolCommand = new RelayCommand(ShowAddProtocolWindow);
            ShowAddConfigCommand = new RelayCommand(ShowAddConfigWindow);
            AddDomainCommand = new RelayCommand<string>(AddDomain);
            AddProtocolCommand = new RelayCommand<string>(AddProtocol);
            AddConfigCommand = new RelayCommand<ConnectionConfig>(AddConfig);
            DeleteDomainCommand = new RelayCommand<string>(AddDomain);
            DeleteProtocolCommand = new RelayCommand<string>(AddProtocol);
            DeleteConfigCommand = new RelayCommand<ConnectionConfig>(AddConfig);
            ChangeDomainCommand = new RelayCommand<Domain>(ChangeDomain);
            ChangeProtocolCommand = new RelayCommand<Protocol>(ChangeProtocol);
            ChangeConfigCommand = new RelayCommand<ConnectionConfig>(ChangeConfig);
            DomainManager.PropertyChanged += ChangeProperty;
        }

        #region Command methods
        public void ShowAddDomainWindow()
        {
            AddDomainWindow addWindow = new AddDomainWindow();
            addWindow.DataContext = this;
            addWindow.Show();
        }
        public void ShowAddProtocolWindow()
        {
            AddProtocolWindow addWindow = new AddProtocolWindow();
            addWindow.DataContext = this;
            addWindow.Show();
        }
        public void ShowAddConfigWindow()
        {
            AddConfigWindow addWindow = new AddConfigWindow();
            CurrentConfig = new ConnectionConfig();
            addWindow.DataContext = this;
            addWindow.Show();
        }
        public void AddDomain(string name)
        {
            Domain domain = new Domain()
            {
                Name = name
            };
            DomainManager.Domains.Add(domain);
        }
        public void AddProtocol(string name)
        {
            Protocol protocol = new Protocol()
            {
                Name = name
            };
            CurrentDomain.ProtocolSubdevisions.Add(protocol);
        }
        public void AddConfig(ConnectionConfig config)
        {
            CurrentProtocol.ConnectionConfigs.Add(config);
        }

        public void DeleteDomain(Domain domain)
        {
            DomainManager.Domains.Add(domain);
        }
        public void DeleteProtocol(Protocol protocol)
        {
            CurrentDomain.ProtocolSubdevisions.Remove(protocol);
        }
        public void DeleteConfig(ConnectionConfig config)
        {
            CurrentProtocol.ConnectionConfigs.Remove(config);
        }
        public void ChangeDomain(Domain domain)
        {
            CurrentDomain = domain;
        }
        public void ChangeProtocol(Protocol protocol)
        {
            CurrentProtocol = protocol;
        }
        public void ChangeConfig(ConnectionConfig config)
        {
            CurrentConfig = config;
        }
        #endregion

        public void SaveConfig()
        {
            SimpleIoc.Default.GetInstance<IXmlRepository<DomainCollection>>().SaveContents(DomainManager);
        }

        private void ChangeProperty(object sender, EventArgs e)
        {
            //Debug.WriteLine("called!!!! YAAAAAY!");
            SaveConfig();
        }
    }
}