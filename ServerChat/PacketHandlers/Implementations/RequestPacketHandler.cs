using SharpChat.Network;
using SharpChat.Network.Packets;
using SharpChat.ServerInfo;
using SharpChat.ServerInfo.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers.Implementations
{
    class RequestPacketHandler : PacketHandlerBase<RequestPacket, Profile>,
                                 IPacketHandler<RequestPacket, IUser>
    {
        public override void Call(RequestPacket packet, Profile sender, NetworkConnector Connector, Server state)
        {
            Call(packet, sender as IUser, Connector, state);
        }
        public void Call(RequestPacket packet, IUser sender, NetworkConnector Connector, Server state)
        {
            if (packet.Info == RequestPacket.RequestInfo.Empty)
            {
                sender.Send(new EmptyPacket());
            }
        }
    }
}
