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
    class ChatInfoHandler : PacketHandlerBase<ChatInfoRequest>
    {
        public override void Call(ChatInfoRequest packet, IUser sender, IServerManager manager)
        {
            var chat = manager.Data.Chats.Where(x => x.Id == packet.Id).First();
            var idMessages = chat.Messages.Select(x => x.Id).ToArray();
            var idProfiles = chat.Profiles.Select(x => x.Id).ToArray();
            var p = new ChatInfoResponse
            {
                Id = chat.Id,
                Name = chat.Name,
                IdProfiles = idProfiles,
                IdMessages = idMessages
            };
            sender.Connector.Send(p);
        }
    }
}
