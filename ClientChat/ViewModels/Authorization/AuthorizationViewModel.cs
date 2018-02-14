using Caliburn.Micro;
using SharpChat.Management;
using SharpChat.ViewModels.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ViewModels.Authorization
{
    class AuthorizationViewModel : PropertyChangedBase
    {
        private IClientManager _manager;

        private LoginViewModel _login;
        public LoginViewModel Login
        {
            get { return _login; }
            set
            {
                _login = value;
                NotifyOfPropertyChange(() => Login);
            }
        }
        private SignupViewModel _signup;
        public SignupViewModel Signup
        {
            get { return _signup; }
            set
            {
                _signup = value;
                NotifyOfPropertyChange(() => Signup);
            }
        }
        private ServerStateLineViewModel _serverStateLine;
        public ServerStateLineViewModel ServerStateLine
        {
            get { return _serverStateLine; }
            set
            {
                _serverStateLine = value;
                NotifyOfPropertyChange(() => ServerStateLine);
            }
        }

        public AuthorizationViewModel(IClientManager manager)
        {
            _manager = manager;
            Login = new LoginViewModel(manager);
            Signup = new SignupViewModel(manager);
            ServerStateLine = new ServerStateLineViewModel(manager);
        }
    }
}
