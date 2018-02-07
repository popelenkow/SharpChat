using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ViewModels
{
    class MessagesFeedViewModel : PropertyChangedBase
    {
        private ObservableCollection<MessageBlockViewModel> _messages = new BindableCollection<MessageBlockViewModel>();
        public ObservableCollection<MessageBlockViewModel> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                NotifyOfPropertyChange(() => Messages);
            }
        }
    }
}
