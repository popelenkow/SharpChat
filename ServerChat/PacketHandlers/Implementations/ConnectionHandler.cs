using SharpChat.Network;
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
    class ConnectionHandler : PacketHandlerBase<ConnectionRequest, IUser>
    {
        public override void Call(ConnectionRequest packet, IUser sender, INetworkServerConnector connector, Server state)
        {
            var p = new ConnectionResponse
            {
                InnerId = packet.InnerId,
                IsConnected = packet.IsConnect
            };
            connector.Send(p);
        }
    }
}
