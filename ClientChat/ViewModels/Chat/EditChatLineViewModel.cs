using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpChat.Network.Packets;
using SharpChat.Management;
using SharpChat.Extentions;

namespace SharpChat.ViewModels.Chat
{
    class EditChatLineViewModel : PropertyChangedBase
    {
        private IClientManager _manager;

        private string _edit;
        public string Edit
        {
            get { return _edit; }
            set
            {
                _edit = value;
                NotifyOfPropertyChange(() => Edit);
            }
        }

        public bool CanSend
        {
            get { return !string.IsNullOrWhiteSpace(Edit); }
        }
        private void SubscribeCanSendChanged()
        {
            this.PropertyChanged += ((sender, e) =>
            {
                if (e.PropertyName.IsEqualsOf("Edit"))
                {
                    NotifyOfPropertyChange(() => CanSend);
                }
            });
        }

        public void Send()
        {
            _manager.SendMessage(Edit);
            Edit = string.Empty;
        }
        
        public EditChatLineViewModel(IClientManager manager)
        {
            _manager = manager;
            SubscribeCanSendChanged();
        }
    }
}
