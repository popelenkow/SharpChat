using Caliburn.Micro;
using SharpChat.Management;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Models
{
    class ChatModel : PropertyChangedBase
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
        private ObservableCollection<MessageModel> _messages = new BindableCollection<MessageModel>();
        public ObservableCollection<MessageModel> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                NotifyOfPropertyChange(() => Messages);
            }
        }
        private ObservableCollection<ProfileModel> _profiles = new BindableCollection<ProfileModel>();
        public ObservableCollection<ProfileModel> Profiles
        {
            get { return _profiles; }
            set
            {
                _profiles = value;
                NotifyOfPropertyChange(() => Profiles);
            }
        }
    }
}
