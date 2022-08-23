using CheckConnectionString.Commands;
using CheckConnectionString.SQLconnect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CheckConnectionString.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _ShowConnectionString;
        private string _Serwer { get; set; }
        private string _DataBase { get; set; }
        private string _User { get; set; }
        private string _Password { get; set; }
        public MainViewModel()
        {
            
            ConnectionCommand = new RelayCommand(Connection);
            ClearCommand = new RelayCommand(Clear);
           
        }
        public void Connection(object obj)
        {           
            string connectionString = checkShowConnectionString();
            if (ShowConnectionString.Trim().Length == 0)
            {
                if (Check == false)
                {
                    connectionString = $"Server={Serwer};Database={DataBase};User Id={User};Password={Password};";
                }
                else
                {
                    connectionString = $"Server={Serwer};Database={DataBase};Trusted_Connection=True;";
                }
            }


            SqlConnect.CheckConnect(connectionString);
            ShowConnectionString = connectionString;
        }
        public void Clear(object obj)
        {
            Serwer = "";
            DataBase = "";
            User = "";
            Password = "";
            ShowConnectionString = "";
        }

        
        public string Serwer
        {
            get => _Serwer;
            set
            {
                _Serwer = value;
                OnPropertyChanged();
            }
        }
        public string DataBase
        {
            get => _DataBase;
            set
            {
                _DataBase = value;
                OnPropertyChanged();
            }
        }
        public string User
        {
            get => _User;
            set
            {
                _User = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => _Password;
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }
        public bool Check { get; set; }
        public string ShowConnectionString
        {
            get => _ShowConnectionString;
            set
            {
                _ShowConnectionString = value;
                OnPropertyChanged();
            }
        }
        public ICommand ConnectionCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string checkShowConnectionString()
        {
            if(ShowConnectionString==null)
            {
                return ShowConnectionString = "";
            }
            return ShowConnectionString;

        }
    }
}
