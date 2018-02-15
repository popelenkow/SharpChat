using Caliburn.Micro;
using SharpChat.Management;
using SharpChat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpChat.Extentions;
using System.Collections.Specialized;

namespace SharpChat.ViewModels.Chat
{
    class MessagesFeedViewModel : PropertyChangedBase
    {
        private IClientManager _manager;
        private ObservableCollection<MessageBlockViewModel> _messages = new BindableCollection<MessageBlockViewModel>();
        public ObservableCollection<MessageBlockViewModel> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                NotifyOfPropertyChange(() => Messages);
            }
        }
        private ChatModel _chatModel;
        public ChatModel ChatModel
        {
            get { return _chatModel; }
            set
            {
                Messages = new BindableCollection<MessageBlockViewModel>();

                
                if (_chatModel != null)
                {
                    value.Messages.CollectionChanged -= OnMessagesChanged;
                }
                if (value != null)
                {
                    foreach (var it in value.Messages)
                    {
                        var m = new MessageBlockViewModel(_manager)
                        {
                            MessageModel = it
                        };
                        Messages.Add(m);
                    }
                    value.Messages.CollectionChanged += OnMessagesChanged;
                }
                _chatModel = value;
                NotifyOfPropertyChange(() => ChatModel);
            }
        }
        private void OnMessagesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (MessageModel it in e.OldItems)
                {
                    Messages.RemoveAt(Messages.FindIndex(x => x.MessageModel == it));
                }
            }
            if (e.NewItems != null)
            {
                foreach (MessageModel it in e.NewItems)
                {
                    int i = 0;
                    for (; i < Messages.Count; i++)
                    {
                        if (Messages[i].MessageModel.Id > it.Id) break;
                    }
                    var mb = new MessageBlockViewModel(_manager)
                    {
                        MessageModel = it
                    };
                    Messages.Insert(i, mb);
                }
            }
        }
       
        public MessagesFeedViewModel(IClientManager manager)
        {
            _manager = manager;
        }
    }
}
