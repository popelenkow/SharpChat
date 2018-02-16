using Caliburn.Micro;
using SharpChat.Extentions;
using SharpChat.Management;
using SharpChat.Network.Packets.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ViewModels.EventContents
{
    class InviteProfileViewModel : PropertyChangedBase
    {
        private IClientManager _manager;

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        public int IdChat { get; set; }

        public bool CanInvite
        {
            get { return Id != 0; }
        }
        public void Invite()
        {
            var p = new InviteProfileRequest
            {
               Id = Id,
               IdChat = IdChat
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
                if (e.PropertyName.IsEqualsOf("Id"))
                {
                    NotifyOfPropertyChange(() => CanInvite);
                }
            });
        }
        public InviteProfileViewModel(IClientManager manager)
        {
            _manager = manager;
            SubscribeCanCreateChanged();
        }
    }
}
