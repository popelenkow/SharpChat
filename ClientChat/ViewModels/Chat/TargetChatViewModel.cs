using Caliburn.Micro;
using SharpChat.Extentions;
using SharpChat.Management;
using SharpChat.Models;
using SharpChat.ViewModels.EventContents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ViewModels.Chat
{
    class TargetChatViewModel : PropertyChangedBase
    {
        private IClientManager _manager;

        private ObservableCollection<ProfileLineViewModel> _profiles = new BindableCollection<ProfileLineViewModel>();
        public ObservableCollection<ProfileLineViewModel> Profiles
        {
            get { return _profiles; }
            set
            {
                _profiles = value;
                NotifyOfPropertyChange(() => Profiles);
            }
        }


        public ChatModel ChatModel { get; }

        private void SubscribeProfilesChanged()
        {
            ChatModel.Profiles.CollectionChanged += ((sender, e) =>
            {
                if (e.OldItems != null)
                {
                    foreach (ProfileModel it in e.OldItems)
                    {
                        Profiles.RemoveAt(Profiles.FindIndex(x => x.ProfileModel == it));
                    }
                }
                if (e.NewItems != null)
                {
                    foreach (ProfileModel it in e.NewItems)
                    {
                        int i = 0;
                        for (; i < Profiles.Count; i++)
                        {
                            if (Profiles[i].ProfileModel.Id > it.Id) break;
                        }
                        var mb = new ProfileLineViewModel(_manager)
                        {
                            ProfileModel = it
                        };
                        Profiles.Insert(i, mb);
                    }
                }
            });
        }

        private void InitProfiles()
        {
            foreach (var model in ChatModel.Profiles)
            {
                var view = new ProfileLineViewModel(_manager) { ProfileModel = model };
                Profiles.Add(view);
            }
        }

        public void InviteProfile()
        {
            _manager.EventContent = new InviteProfileViewModel(_manager) { IdChat = ChatModel.Id };
        }

        public TargetChatViewModel(IClientManager manager, ChatModel chatModel)
        {
            _manager = manager;
            ChatModel = chatModel;
            InitProfiles();
            SubscribeProfilesChanged();
        }
    }
}
