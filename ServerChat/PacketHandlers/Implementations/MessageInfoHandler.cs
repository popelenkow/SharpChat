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
    class MessageInfoHandler : PacketHandlerBase<MessageInfoRequest>
    {
        public override void Call(MessageInfoRequest packet, IUser sender, IServerManager manager)
        {
            var message = manager.Data.Messages.Where(x => x.Id == packet.Id).FirstOrDefault();
            var chat = manager.Data.Chats.Where(x => x.Messages.Any(y => y.Id == packet.Id)).First();
            var p = new MessageInfoResponse
            {
                Id = message.Id,
                Text = message.Text,
                IdChat = chat.Id,
                IdProfile = message.IdProfile
            };
            sender.Connector.Send(p);
        }
    }
}
