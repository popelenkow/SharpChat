using PolymorphismSharp.Static.Methods;
using SharpChat.Network;
using SharpChat.Network.Packets;
using SharpChat.ServerInfo;
using SharpChat.ServerInfo.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers
{
    abstract class PacketHandlerBase<TPacket, TUser> : MultiMethod, IPacketHandler<TPacket, TUser>
        where TPacket : IPacket
        where TUser : IUser
    {
        public abstract void Call(TPacket packet, TUser sender, NetworkConnector Connector, Server state);
    }
}
