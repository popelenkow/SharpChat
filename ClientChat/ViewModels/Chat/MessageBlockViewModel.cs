using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ViewModels.Chat
{
    class MessageBlockViewModel : PropertyChangedBase
    {
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
        private int _idPerson;
        public int IdPerson
        {
            get { return _idPerson; }
            set
            {
                _idPerson = value;
                NotifyOfPropertyChange(() => IdPerson);
            }
        }
        private string _namePerson;
        public string NamePerson
        {
            get { return _namePerson; }
            set
            {
                _namePerson = value;
                NotifyOfPropertyChange(() => NamePerson);
            }
        }
    }
}
