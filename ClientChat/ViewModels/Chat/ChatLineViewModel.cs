using Caliburn.Micro;
using SharpChat.Management;
using SharpChat.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SharpChat.ViewModels.Chat
{
    public class ChatLineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var model = value as ChatModel;

            if (model == null) return null;

            return new ChatLineViewModel(model.Manager) { ChatModel = model };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
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
            content.Target = new TargetChatViewModel(_manager, ChatModel);
            content.HeadChatLine = new ChatLineViewModel(_manager)
            {
                ChatModel = ChatModel
            };
            content.MessagesFeed = new MessagesFeedViewModel(_manager, ChatModel);
            content.EditChatLine.ChatModel = ChatModel;
        }

        public ChatLineViewModel(IClientManager manager)
        {
            _manager = manager;
        }
    }
}
