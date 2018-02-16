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

        public ChatModel ChatModel { get; }
       
        private void SubscribeMessagesChanged()
        {
            ChatModel.Messages.CollectionChanged += ((sender, e) =>
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
                        var mb = new MessageBlockViewModel(_manager, it);
                        Messages.Insert(i, mb);
                    }
                }
            });
        }

        private void InitMessages()
        {
            foreach (var model in ChatModel.Messages)
            {
                var view = new MessageBlockViewModel(_manager, model);
                Messages.Add(view);
            }
        }

        public MessagesFeedViewModel(IClientManager manager, ChatModel chatModel)
        {
            _manager = manager;
            ChatModel = chatModel;
            InitMessages();
            SubscribeMessagesChanged();
        }
    }
}
