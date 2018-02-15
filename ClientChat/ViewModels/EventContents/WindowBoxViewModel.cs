using Caliburn.Micro;
using SharpChat.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ViewModels.EventContents
{
    class WindowBoxViewModel : PropertyChangedBase
    {
        private IClientManager _manager;

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                NotifyOfPropertyChange(() => Text);
            }
        }
        public void Ok()
        {
            _manager.EventContent = null;
        }
        public WindowBoxViewModel(IClientManager manager)
        {
            _manager = manager;
        }
    }
}
