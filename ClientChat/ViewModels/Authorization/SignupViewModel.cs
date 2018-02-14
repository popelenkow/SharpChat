using Caliburn.Micro;
using SharpChat.Extentions;
using SharpChat.Management;
using SharpChat.Network.Packets.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ViewModels.Authorization
{
    class SignupViewModel : PropertyChangedBase
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
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
        public bool CanSignUp
        {
            get
            {
                bool b = true;
                b &= !string.IsNullOrEmpty(Email);
                b &= !string.IsNullOrEmpty(Password);
                b &= !string.IsNullOrEmpty(Name);
                b &= _manager.ConnectionInspector.IsConnected;
                return b;
            }
        }
        private void SubscribeCanSignUpChanged()
        {
            _manager.ConnectionInspector.PropertyChanged += ((sender, e) =>
            {
                if (e.PropertyName.IsEqualsOf("IsConnected"))
                {
                    NotifyOfPropertyChange(() => CanSignUp);
                }
            });
            this.PropertyChanged += ((sender, e) =>
            {
                if (e.PropertyName.IsEqualsOf("Password", "Email", "Name"))
                {
                    NotifyOfPropertyChange(() => CanSignUp);
                }
            });
        }

        public void SignUp()
        {
            var p = new SignUpRequest
            {
                Email = Email,
                Password = Password,
                Name = Name
            };
            Password = string.Empty;
            _manager.ConnectionInspector.Send(p);
        }
        public SignupViewModel(IClientManager manager)
        {
            _manager = manager;
            SubscribeCanSignUpChanged();
        }
    }
}
