using SharpChat.Management;
using SharpChat.Network;
using SharpChat.Network.Packets.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using SharpChat.PacketHandlers;
using System.ComponentModel;
using Caliburn.Micro;
using System.Windows;
using SharpChat.ViewModels.Chat;
using SharpChat.ViewModels.Authorization;
using SharpChat.Models;
using SharpChat.ViewModels.EventContents;

namespace SharpChat.ViewModels
{
    partial class ShellViewModel : IClientManager
    {
        public IConnectionInspector ConnectionInspector { get; private set; }

        public ShellViewModel()
        {
            ConnectionInspector = new ConnectionInspector(this);
            MainContent = new AuthorizationViewModel(this);
            ConnectionInspector.PropertyChanged += this.OnServerPropertyChanged;
            
        }
       
        protected override void OnDeactivate(bool close)
        {

        }
        public TViewModel GetContent<TViewModel>()
           where TViewModel : PropertyChangedBase
        {
            if (Content.GetType() == typeof(ChatGridViewModel))
            {
                return Content as TViewModel;
            }
            return null;
        }

        public void SendMessage(string text)
        {
            var p = new SendMessageRequest
            {
                IdChat = 1,
                Text = text
            };
            ConnectionInspector.Send(p);
        }

        private void OnServerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsConnected")
            {
                if (!ConnectionInspector.IsConnected && Content.GetType() == typeof(ChatGridViewModel))
                {
                    EventContent = new WindowBoxViewModel(this)
                    {
                        Text = "Sorry! Server disconnect."
                    };
                    MainContent = new AuthorizationViewModel(this);
                }
            }
        }



    }
}
