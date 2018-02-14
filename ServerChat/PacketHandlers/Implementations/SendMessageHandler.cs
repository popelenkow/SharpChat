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

namespace SharpChat.PacketHandlers.Implementations
{
    class SendMessageHandler : PacketHandlerBase<SendMessageRequest>
    {
        public override void Call(SendMessageRequest packet, IUser sender, IServerManager manager)
        {
            var p = new SendMessageResponseLuck
            {
                IdChat = packet.IdChat,
                IsPersonChat = packet.IsPersonChat,
                //IdMessage = id++,
                Text = packet.Text,
                IdProfile = sender.Id
            };
            sender.Connector.Send(p);
        }
    }
}
