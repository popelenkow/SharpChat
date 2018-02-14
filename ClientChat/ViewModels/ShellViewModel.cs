using Caliburn.Micro;
using SharpChat.Extentions;
using SharpChat.Network.Packets;
using SharpChat.Network.Packets.Requests;
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
        private PropertyChangedBase _content;
        public PropertyChangedBase Content
        {
            get { return _content; }
            set
            {
                if (value != null && value.GetType().IsOneOf(typeof(ChatGridViewModel), typeof(StartPageViewModel)))
                {
                    _content = value;
                    NotifyOfPropertyChange(() => Content);
                }
            }
        }
    }
}
