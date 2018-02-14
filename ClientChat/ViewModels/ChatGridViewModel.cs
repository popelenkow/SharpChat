using Caliburn.Micro;
using SharpChat.Manager;
using SharpChat.Network.Packets.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ViewModels
{
    class ChatGridViewModel : PropertyChangedBase
    {
        private HeadChatLineViewModel _headChatLine = new HeadChatLineViewModel();
        public HeadChatLineViewModel HeadChatLine
        {
            get { return _headChatLine; }
            set
            {
                _headChatLine = value;
                NotifyOfPropertyChange(() => HeadChatLine);
            }
        }

        private MessagesFeedViewModel _messagesFeed = new MessagesFeedViewModel();
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
        private ProfileLineViewModel _myProfileLine = new ProfileLineViewModel();
        public ProfileLineViewModel MyProfileLine
        {
            get { return _myProfileLine; }
            set
            {
                _myProfileLine = value;
                NotifyOfPropertyChange(() => MyProfileLine);
            }
        }


        public ChatGridViewModel(IClientManager manager)
        {
            ServerStateLine = new ServerStateLineViewModel(manager);
            EditChatLine = new EditChatLineViewModel(manager);
        }

    }
}
