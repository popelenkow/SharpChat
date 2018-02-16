using Caliburn.Micro;
using SharpChat.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Models
{
    class MessageModel : PropertyChangedBase
    {
        public IClientManager Manager { get; set; }

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
        private ProfileModel _profile;
        public ProfileModel Profile
        {
            get { return _profile; }
            set
            {
                _profile = value;
                NotifyOfPropertyChange(() => Profile);
            }
        }
    }
}
