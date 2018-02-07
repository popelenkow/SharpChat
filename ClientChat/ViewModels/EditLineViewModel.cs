using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ViewModels
{
    class EditLineViewModel : PropertyChangedBase
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
        public bool CanSend
        {
            get { return !string.IsNullOrWhiteSpace(Edit); }
        }
        public void Send()
        {
            Edit = string.Empty;
        }
    }
}
