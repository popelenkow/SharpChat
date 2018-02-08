using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpChat.Packets;

namespace SharpChat.ViewModels
{
    class EditChatLineViewModel : PropertyChangedBase
    {
        private string _edit;
        public string Edit
        {
            get { return _edit; }
            set
            {
                _edit = value;
                NotifyOfPropertyChange(() => Edit);
                NotifyOfPropertyChange(() => CanSend);
            }
        }

        public ISender Sender { get; set; }

        public bool CanSend
        {
            get { return !string.IsNullOrWhiteSpace(Edit); }
        }
        public void Send()
        {
            Sender?.Send(Edit);
            Edit = string.Empty;
        }
        
    }
}
