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

        private MessageModel _messsageModel;
        public MessageModel MessageModel
        {
            get { return _messsageModel; }
            set
            {
                _messsageModel = value;
                NotifyOfPropertyChange(() => MessageModel);
            }
        }

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
            this.PropertyChanged += ((sender, e) =>
            {
                if (e.PropertyName.IsEqualsOf("MessageModel"))
                {
                    ProfileLine.ProfileModel = MessageModel.Profile;
                }
            });
        }

        public MessageBlockViewModel(IClientManager manager)
        {
            _manager = manager;
            SubscribeProfileLineChanged();
            ProfileLine = new ProfileLineViewModel(manager);
        }
    }
}
