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
    class EmptyPacketHandler : PacketHandlerBase<EmptyPacket, IUser>
    {
        public override void Call(EmptyPacket packet, IUser sender, NetworkConnector connection, Server state)
        {
        }
    }
}
