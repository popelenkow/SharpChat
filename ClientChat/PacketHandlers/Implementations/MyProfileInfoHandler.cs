using SharpChat.Extentions;
using SharpChat.Management;
using SharpChat.Models;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using SharpChat.ViewModels.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers.Implementations
{
    class MyProfileInfoHandler : PacketHandlerBase<MyProfileInfoResponseLuck>
    {
        public override void Call(MyProfileInfoResponseLuck packet, IClientManager manager)
        {
            var content = (ChatGridViewModel)manager.MainContent;
            if (content == null) return;
            var p = new ProfileModel
            {
                Id = packet.Id,
                Name = packet.Name
            };
            content.Profiles.Add(p);
            foreach (var it in packet.IdChats)
            {
                int index = content.Chats.FindIndex(x => x.Id == it);
                if (index == -1)
                {
                    var chat = new ChatModel
                    {
                        Id = it
                    };
                    content.Chats.Add(chat);
                    var pp = new ChatInfoRequest
                    {
                        Id = it
                    };
                    manager.ConnectionInspector.Send(pp);
                }
            }
            content.MyProfileLine.ProfileModel = p;
        }
    }
}
