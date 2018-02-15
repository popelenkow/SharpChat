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
    class ChatLineViewModel : PropertyChangedBase
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

        public void ChangeTarget()
        {
            var content = (ChatGridViewModel)_manager.MainContent;
            if (content == null) return;
            content.Target = new TargetChatViewModel(_manager)
            {
                ChatModel = ChatModel
            };
            content.HeadChatLine = new ChatLineViewModel(_manager)
            {
                ChatModel = ChatModel
            };
            content.MessagesFeed.ChatModel = ChatModel;
            content.EditChatLine.ChatModel = ChatModel;
        }

        public ChatLineViewModel(IClientManager manager)
        {
            _manager = manager;
        }
    }
}
