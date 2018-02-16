using Caliburn.Micro;
using SharpChat.Extentions;
using SharpChat.Management;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Models
{
    class MyProfileModel
    {
        private IClientManager _manager;
        public ProfileModel MyProfile { get; } = new ProfileModel();
        public ObservableCollection<ChatModel> Chats { get; } = new BindableCollection<ChatModel>();
        private List<ProfileModel> _profiles = new List<ProfileModel>();

        public MyProfileModel(IClientManager manager)
        {
            _manager = manager;
            _profiles.Add(MyProfile);
            var request = new MyProfileInfoRequest();
            _manager.ConnectionInspector.Send(request);
        }

        private ChatModel GetChat(ChatInfoResponse info)
        {
            if (!Chats.Any(x => x.Id == info.Id))
            {
                var model = new ChatModel { Id = info.Id, Manager = _manager };
                Chats.AddSorted(model, x => x.Id);
                return model;
            }
            return Chats.Where(x => x.Id == info.Id).First();
        }
        public void AddChatInfo(ChatInfoResponse info)
        {
            if (!info.IdProfiles.Any(x => x == MyProfile.Id)) return;
            var model = GetChat(info);
            model.Name = info.Name;
            foreach (var id in info.IdProfiles)
            {
                if (!_profiles.Any(x => x.Id == id))
                {
                    var request = new ProfileInfoRequest { Id = id };
                    _manager.ConnectionInspector.Send(request);
                }
                if (!model.Profiles.Any(x => x.Id == id))
                {
                    model.Profiles.AddSorted(GetProfile(id), x => x.Id);
                }
            }
            foreach (var id in info.IdMessages)
            {
                if (!model.Messages.Any(x => x.Id == id))
                {
                    var request = new MessageInfoRequest { Id = id };
                    _manager.ConnectionInspector.Send(request);
                }
            }
        }
        private MessageModel GetMessage(MessageInfoResponse info)
        {
            var chat = Chats.Where(x => x.Id == info.IdChat).First();
            if (!chat.Messages.Any(x => x.Id == info.Id))
            {
                var model = new MessageModel { Id = info.Id, Manager = _manager };
                chat.Messages.AddSorted(model, x => x.Id);
                return model;
            }
            return chat.Messages.Where(x => x.Id == info.Id).First();
        }
        public void AddMessageInfo(MessageInfoResponse info)
        {
            if (!Chats.Any(x => x.Id == info.IdChat)) return;
            var model = GetMessage(info);
            model.Text = info.Text;
            if (!_profiles.Any(x => x.Id == info.Id))
            {
                var request = new ProfileInfoRequest { Id = info.IdProfile };
                _manager.ConnectionInspector.Send(request);
            }
            var profile = GetProfile(info.IdProfile);
            model.Profile = profile;
        }
        private ProfileModel GetProfile(int id)
        {
            if (!_profiles.Any(x => x.Id == id))
            {
                var model = new ProfileModel { Id = id, Manager = _manager };
               _profiles.AddSorted(model, x => x.Id);
                return model;
            }
            return _profiles.Where(x => x.Id == id).First();
        }
        public void AddProfileInfo(ProfileInfoResponse info)
        {
            if (MyProfile.Id == 0) return;
            var model = GetProfile(info.Id);
            model.Name = info.Name;
        }
    }
}
