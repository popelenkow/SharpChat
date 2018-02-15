using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpChat.Network.Packets;
using SharpChat.Management;
using SharpChat.Extentions;
using SharpChat.Models;
using SharpChat.Network.Packets.Requests;

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

        private ChatModel _chatModel;
        public ChatModel ChatModel
        {
            get { return _chatModel; }
            set
            {
                _chatModel = value;
                NotifyOfPropertyChange(() => ChatModel);
            }
        }


        public bool CanSend
        {
            get { return !string.IsNullOrWhiteSpace(Edit) && ChatModel != null; }
        }
        private void SubscribeCanSendChanged()
        {
            this.PropertyChanged += ((sender, e) =>
            {
                if (e.PropertyName.IsEqualsOf("Edit", "ChatModel"))
                {
                    NotifyOfPropertyChange(() => CanSend);
                }
            });
        }

        public void Send()
        {
            var p = new SendMessageRequest
            {
                IdChat = ChatModel.Id,
                Text = Edit
            };
            _manager.ConnectionInspector.Send(p);
            Edit = string.Empty;
        }
        
        public EditChatLineViewModel(IClientManager manager)
        {
            _manager = manager;
            SubscribeCanSendChanged();
        }
    }
}
