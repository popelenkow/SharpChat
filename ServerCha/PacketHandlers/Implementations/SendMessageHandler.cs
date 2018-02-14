using SharpChat.Network;
using SharpChat.Network.Packets;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using SharpChat.ServerInfo;
using SharpChat.ServerInfo.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers.Implementations
{
    class SendMessageHandler : PacketHandlerBase<SendMessageRequest, Profile>
    {
        static int id { get; set; }
        public override void Call(SendMessageRequest packet, Profile sender, INetworkServerConnector connector, Server state)
        {
            var p = new SendMessageResponseLuck
            {
                InnerId = packet.InnerId,
                IdChat = packet.IdChat,
                IsPersonChat = packet.IsPersonChat,
                IdMessage = id++,
                Text = packet.Text,
                IdProfile = sender.Id
            };
            sender.Send(p);
        }
    }
}
