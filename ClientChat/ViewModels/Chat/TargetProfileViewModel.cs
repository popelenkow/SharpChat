using Caliburn.Micro;
using SharpChat.Management;
using SharpChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ViewModels.Chat
{
    class TargetProfileViewModel : PropertyChangedBase
    {
        private IClientManager _manager;

        private ProfileModel _profileModel;
        public ProfileModel ProfileModel
        {
            get { return _profileModel; }
            set
            {
                _profileModel = value;
                NotifyOfPropertyChange(() => ProfileModel);
            }
        }

        public TargetProfileViewModel(IClientManager manager)
        {
            _manager = manager;
        }
    }
}
