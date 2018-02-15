using SharpChat.Management;
using SharpChat.Models;
using SharpChat.Network;
using SharpChat.Network.Packets;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using SharpChat.ViewModels;
using SharpChat.ViewModels.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers.Implementations
{
    class SendMessageHandler : PacketHandlerBase<SendMessageResponseLuck>
    {
        public override void Call(SendMessageResponseLuck packet, IClientManager manager)
        {
            var content = (ChatGridViewModel)manager.MainContent;
            if (content == null) return;
            var chat = content.ChatCollection.Chats.Where(x => x.ChatModel.Id == packet.IdChat).FirstOrDefault().ChatModel;
            var ms = chat.Messages;
            var profile = content.Profiles.Where(x => x.Id == packet.IdProfile).FirstOrDefault();
            if (profile == null)
            {
                profile = new ProfileModel
                {
                    Id = packet.IdProfile
                };
                content.Profiles.Add(profile);
                var p = new ProfileInfoRequest
                {
                    Id = packet.IdProfile
                };
                manager.ConnectionInspector.Send(p);
            }
            var vm = new MessageModel
            {
                Id = packet.IdMessage,
                Profile = profile,
                Text = packet.Text
            };
            ms.Add(vm);
        }
    }
}
