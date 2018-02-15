using Caliburn.Micro;
using SharpChat.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpChat.Extentions;
using SharpChat.Network.Packets.Requests;

namespace SharpChat.ViewModels.EventContents
{
    class CreateChatViewModel : PropertyChangedBase
    {
        private IClientManager _manager;

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public bool CanCreate
        {
            get { return !string.IsNullOrWhiteSpace(Name); }
        }
        public void Create()
        {
            var p = new CreateChatRequest
            {
                Name = Name
            };
            _manager.ConnectionInspector.Send(p);
            _manager.EventContent = null;
        }
        public void Cancel()
        {
            _manager.EventContent = null;
        }

        private void SubscribeCanCreateChanged()
        {
            this.PropertyChanged += ((sender, e) =>
            {
                if (e.PropertyName.IsEqualsOf("Name"))
                {
                    NotifyOfPropertyChange(() => CanCreate);
                }
            });
        }
        public CreateChatViewModel(IClientManager manager)
        {
            _manager = manager;
            SubscribeCanCreateChanged();
        }
    }
}
