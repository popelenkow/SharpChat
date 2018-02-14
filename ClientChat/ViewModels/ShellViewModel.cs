using Caliburn.Micro;
using SharpChat.Extentions;
using SharpChat.Network.Packets;
using SharpChat.Network.Packets.Requests;
using SharpChat.ViewModels.Authorization;
using SharpChat.ViewModels.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SharpChat.ViewModels
{
    partial class  ShellViewModel : Screen
    {
        public PropertyChangedBase Content
        {
            get { return EventContent == null ? MainContent : EventContent; }
        }
        private PropertyChangedBase _mainContent;
        public PropertyChangedBase MainContent
        {
            get { return _mainContent; }
            set
            {
                if (value != null && value.GetType().IsOneOf(typeof(ChatGridViewModel), typeof(AuthorizationViewModel)))
                {
                    _mainContent = value;
                    NotifyOfPropertyChange(() => Content);
                }
            }
        }
        private PropertyChangedBase _eventContent;
        public PropertyChangedBase EventContent
        {
            get { return _eventContent; }
            set
            {
                if (value == null || value.GetType().IsOneOf(typeof(WindowBoxViewModel)))
                {
                    _eventContent = value;
                    NotifyOfPropertyChange(() => Content);
                }
            }
        }
    }
}
