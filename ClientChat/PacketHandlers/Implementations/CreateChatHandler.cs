using SharpChat.Management;
using SharpChat.Models;
using SharpChat.Network.Packets.Responses;
using SharpChat.ViewModels.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers.Implementations
{
    class CreateChatHandler : PacketHandlerBase<CreateChatResponse>
    {
        public override void Call(CreateChatResponse packet, IClientManager manager)
        {
            var content = (ChatGridViewModel)manager.MainContent;
            if (content == null) return;
            var model = new ChatModel
            {
                Id = packet.Id,
                Name = packet.Name,
                
            };
            model.Profiles.Add(content.Profiles.Where(x => x.Id == packet.IdProfiles.First()).First());
            content.Chats.Add(model);
        }
    }
}
