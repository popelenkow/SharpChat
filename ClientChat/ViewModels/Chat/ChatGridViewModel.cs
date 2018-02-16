using Caliburn.Micro;
using SharpChat.Management;
using SharpChat.Models;
using SharpChat.Network.Packets.Requests;
using SharpChat.ViewModels.Server;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ViewModels.Chat
{
    class ChatGridViewModel : PropertyChangedBase
    {
        private IClientManager _manager;
        private ChatLineViewModel _headChatLine;
        public ChatLineViewModel HeadChatLine
        {
            get { return _headChatLine; }
            set
            {
                _headChatLine = value;
                NotifyOfPropertyChange(() => HeadChatLine);
            }
        }

        private MessagesFeedViewModel _messagesFeed;
        public MessagesFeedViewModel MessagesFeed
        {
            get { return _messagesFeed; }
            set
            {
                _messagesFeed = value;
                NotifyOfPropertyChange(() => MessagesFeed);
            }
        }

        private EditChatLineViewModel _editChatLine;
        public EditChatLineViewModel EditChatLine
        {
            get { return _editChatLine; }
            set
            {
                _editChatLine = value;
                NotifyOfPropertyChange(() => EditChatLine);
            }
        }

        private ServerStateLineViewModel _serverStateLine;
        public ServerStateLineViewModel ServerStateLine
        {
            get { return _serverStateLine; }
            set
            {
                _serverStateLine = value;
                NotifyOfPropertyChange(() => ServerStateLine);
            }
        }

        private ChatCollectionViewModel _chatCollection;
        public ChatCollectionViewModel ChatCollection
        {
            get { return _chatCollection; }
            set
            {
                _chatCollection = value;
                NotifyOfPropertyChange(() => ChatCollection);
            }
        }


        private ProfileLineViewModel _myProfileLine;
        public ProfileLineViewModel MyProfileLine
        {
            get { return _myProfileLine; }
            set
            {
                _myProfileLine = value;
                NotifyOfPropertyChange(() => MyProfileLine);
            }
        }
        private PropertyChangedBase _target;
        public PropertyChangedBase Target
        {
            get { return _target; }
            set
            {
                _target = value;
                NotifyOfPropertyChange(() => Target);
            }
        }

        public MyProfileModel MyProfile { get; }

        public ChatGridViewModel(IClientManager manager)
        {
            _manager = manager;
            MyProfile = new MyProfileModel(manager);
            ServerStateLine = new ServerStateLineViewModel(manager);
            EditChatLine = new EditChatLineViewModel(manager);
            //MessagesFeed = new MessagesFeedViewModel(manager);
            MyProfileLine = new ProfileLineViewModel(manager)
            {
                ProfileModel = MyProfile.MyProfile
            };
            ChatCollection = new ChatCollectionViewModel(manager, MyProfile.Chats);
        }


        
       
    }
}
