using SharpChat.Network;
using SharpChat.Network.Packets;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using SharpChat.Management;
using SharpChat.Management.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpChat.DB;

namespace SharpChat.PacketHandlers.Implementations
{
    class SendMessageHandler : PacketHandlerBase<SendMessageRequest>
    {
        public override void Call(SendMessageRequest packet, IUser sender, IServerManager manager)
        {
            var ms = manager.Data.Messages;
            var p = new SendMessageResponseLuck
            {
                IdChat = packet.IdChat,
                Text = packet.Text,
                IdProfile = sender.Id,
                IdMessage = ms.Count() + 1
            };
            var m = new Message
            {
                Id = ms.Count() + 1,
                IdProfile = sender.Id,
                Text = packet.Text
            };

            ms.Add(m);
            manager.Data.Chats.Where(x => x.Id == packet.IdChat).First().Messages.Add(m);
            sender.Connector.Send(p);
        }
    }
}
