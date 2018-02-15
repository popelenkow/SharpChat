using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using SharpChat.Management;
using SharpChat.Models;

namespace SharpChat.ViewModels.Chat
{
    class ProfileLineViewModel : PropertyChangedBase
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

        public void ChangeTarget()
        {
            var content = (ChatGridViewModel)_manager.MainContent;
            if (content == null) return;
            content.Target = new TargetProfileViewModel(_manager)
            {
                ProfileModel = ProfileModel
            };
        }

        public ProfileLineViewModel(IClientManager manager)
        {
            _manager = manager;
        }
    }
}
