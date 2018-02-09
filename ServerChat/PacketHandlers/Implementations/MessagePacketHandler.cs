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
    class MessagePacketHandler : PacketHandlerBase<MessagePacket, Profile>
    {
        public override void Call(MessagePacket packet, Profile sender, NetworkConnector connection, Server state)
        {
            throw new NotImplementedException();
        }
    }
}
