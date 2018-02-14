using Caliburn.Micro;
using SharpChat.Extentions;
using SharpChat.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ViewModels.Server
{
    class ServerStateLineViewModel : PropertyChangedBase
    {
        private IClientManager _manager;

        public string State
        {
            get
            {
                return _manager.ConnectionInspector.IsConnected ? "Server online" : "Server offline";
            }
        }
        public void SubscribeStateChanged()
        {
            _manager.ConnectionInspector.PropertyChanged += ((sender, e) =>
            {
                if (e.PropertyName.IsEqualsOf("IsConnected"))
                {
                    NotifyOfPropertyChange(() => State);
                }
            });
        }
        public ServerStateLineViewModel(IClientManager manager)
        {
            _manager = manager;
            SubscribeStateChanged();
        }
    }
}
