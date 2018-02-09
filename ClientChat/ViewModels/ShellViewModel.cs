using Caliburn.Micro;
using SharpChat.Network.Packets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SharpChat.ViewModels
{
    class ShellViewModel : Screen, ISender
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

        private EditChatLineViewModel _editChatLine = new EditChatLineViewModel();
        public EditChatLineViewModel EditChatLine
        {
            get { return _editChatLine; }
            set
            {
                _editChatLine = value;
                NotifyOfPropertyChange(() => EditChatLine);
            }
        }

        public ShellViewModel()
        {
            EditChatLine.Sender = this;
        }

        public void Send(string text)
        {
            var m = new MessagePacket
            {
                Text = text,
                IdChat = HeadChatLine.Id
            };
        }
    }
}
