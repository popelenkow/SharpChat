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
    class TargetChatViewModel : PropertyChangedBase
    {
        private IClientManager _manager;

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

        public TargetChatViewModel(IClientManager manager)
        {
            _manager = manager;
        }
    }
}
