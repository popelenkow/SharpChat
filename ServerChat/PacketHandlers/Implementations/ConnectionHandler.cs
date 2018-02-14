using SharpChat.Network;
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
    class ConnectionHandler : PacketHandlerBase<ConnectionRequest>
    {
        public override void Call(ConnectionRequest packet, IUser sender, IServerManager manager)
        {
            var p = new ConnectionResponse
            {
                IsConnected = packet.IsConnect
            };
            sender.Connector.Send(p);
        }
    }
}
