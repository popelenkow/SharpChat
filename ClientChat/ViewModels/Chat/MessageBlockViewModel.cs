using Caliburn.Micro;
using SharpChat.Management;
using SharpChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpChat.Extentions;

namespace SharpChat.ViewModels.Chat
{
    class MessageBlockViewModel : PropertyChangedBase
    {
        private IClientManager _manager;

        public MessageModel MessageModel { get; }


        private ProfileLineViewModel _profileLine;
        public ProfileLineViewModel ProfileLine
        {
            get { return _profileLine; }
            set
            {
                _profileLine = value;
                NotifyOfPropertyChange(() => ProfileLine);
            }
        }
        private void SubscribeProfileLineChanged()
        {
            MessageModel.PropertyChanged += ((sender, e) =>
            {
                if (e.PropertyName.IsEqualsOf("Profile"))
                {
                    ProfileLine.ProfileModel = MessageModel.Profile;
                }
            });
        }

        public MessageBlockViewModel(IClientManager manager, MessageModel messageModel)
        {
            _manager = manager;
            MessageModel = messageModel;
            SubscribeProfileLineChanged();
            ProfileLine = new ProfileLineViewModel(manager)
            {
                ProfileModel = messageModel.Profile
            };
        }
    }
}
