using Caliburn.Micro;
using SharpChat.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpChat.Extentions;
using SharpChat.Network.Packets.Requests;

namespace SharpChat.ViewModels.Authorization
{
    class LoginViewModel : PropertyChangedBase
    {
        private IClientManager _manager;
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }
        public bool CanLogIn
        {
            get
            {
                bool b = true;
                b &= !string.IsNullOrEmpty(Email);
                b &= !string.IsNullOrEmpty(Password);
                b &= _manager.ConnectionInspector.IsConnected;
                return b;
            }
        }
        private void SubscribeCanLogInChanged()
        {
            _manager.ConnectionInspector.PropertyChanged += ((sender, e) =>
            {
                if (e.PropertyName.IsEqualsOf("IsConnected"))
                {
                    NotifyOfPropertyChange(() => CanLogIn);
                }
            });
            this.PropertyChanged += ((sender, e) =>
            {
                if (e.PropertyName.IsEqualsOf("Password", "Email"))
                {
                    NotifyOfPropertyChange(() => CanLogIn);
                }
            });
        }
        public void LogIn()
        {
            var p = new LogInRequest
            {
                Email = Email,
                Password = Password
            };
            Password = string.Empty;
            _manager.ConnectionInspector.Send(p);
        }
        public LoginViewModel(IClientManager manager)
        {
            _manager = manager;
            SubscribeCanLogInChanged();
        }
    }
}
