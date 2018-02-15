using Caliburn.Micro;
using SharpChat.Extentions;
using SharpChat.Management;
using SharpChat.Models;
using SharpChat.ViewModels.EventContents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ViewModels.Chat
{
    class ChatCollectionViewModel : PropertyChangedBase
    {
        private IClientManager _manager;
        private ObservableCollection<ChatLineViewModel> _chats = new BindableCollection<ChatLineViewModel>();
        public ObservableCollection<ChatLineViewModel> Chats
        {
            get { return _chats; }
            set
            {
                _chats = value;
                NotifyOfPropertyChange(() => Chats);
            }
        }

        private void SubscribeChatsChanged()
        {
            ChatModels.CollectionChanged += ((sender, e) =>
            {
                if (e.OldItems != null)
                {
                    foreach (ChatModel it in e.OldItems)
                    {
                        Chats.RemoveAt(Chats.FindIndex(x => x.ChatModel == it));
                    }
                }
                if (e.NewItems != null)
                {
                    foreach (ChatModel it in e.NewItems)
                    {
                        int i = 0;
                        for (; i < Chats.Count; i++)
                        {
                            if (Chats[i].ChatModel.Id > it.Id) break;
                        }
                        var mb = new ChatLineViewModel(_manager)
                        {
                            ChatModel = it
                        };
                        Chats.Insert(i, mb);
                    }
                }
            });
        }

        public ObservableCollection<ChatModel> ChatModels { get; set; } = new BindableCollection<ChatModel>();
        
        public void CreateChat()
        {
            _manager.EventContent = new CreateChatViewModel(_manager);
        }
        public ChatCollectionViewModel(IClientManager manager)
        {
            _manager = manager;
            SubscribeChatsChanged();
        }
    }
}
