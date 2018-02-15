using SharpChat.DB;
using SharpChat.Management;
using SharpChat.Management.Users;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers.Implementations
{
    class CreateChatHandler : PacketHandlerBase<CreateChatRequest>
    {
        public override void Call(CreateChatRequest packet, IUser sender, IServerManager manager)
        {
            if (!sender.IsLogIn) return;
            var chat = new Chat
            {
                Id = manager.Data.Chats.Count + 1,
                Name = packet.Name
            };
            chat.Profiles.Add(manager.Data.Profiles.Where(x => x.Id == sender.Id).First());
            var p = new CreateChatResponse
            {
                Id = chat.Id,
                Name = chat.Name
            };
            p.IdProfiles = new int[]
            {
                sender.Id
            };
            manager.Data.Chats.Add(chat);
            sender.Connector.Send(p);
        }
    }
}
