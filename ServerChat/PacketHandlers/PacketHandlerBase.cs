using PolymorphismSharp.Static.Methods;
using SharpChat.Network;
using SharpChat.Network.Packets;
using SharpChat.Network.Packets.Requests;
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
        where TPacket : IPacketRequest
        where TUser : IUser
    {
        public abstract void Call(TPacket packet, TUser sender, INetworkServerConnector connector, Server state);
    }
}
