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
    class EmptyHandler : PacketHandlerBase<EmptyRequest, IUser>
    {
        public override void Call(EmptyRequest packet, IUser sender, INetworkServerConnector connector, Server state)
        {
            var p = new EmptyResponse
            {
                InnerId = packet.InnerId
            };
            sender.Send(p);
        }
    }
}
