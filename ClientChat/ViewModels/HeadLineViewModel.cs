using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ViewModels
{
    class HeadLineViewModel : PropertyChangedBase
    {
        private string _nameGroup = "Name";
        public string NameGroup
        {
            get { return _nameGroup; }
            set
            {
                _nameGroup = value;
                NotifyOfPropertyChange(() => NameGroup);
            }
        }
    }
}
