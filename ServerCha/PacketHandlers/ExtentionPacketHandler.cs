using PolymorphismSharp.Static.Dispatchers;
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

namespace SharpChat.PacketHandlers
{
    static class ExtentionPacketHandler
    {
        private static DispatcherMultiMethod<IPacketHandler<IPacketRequest, IUser>> _dispatcher { get; set; }
        static ExtentionPacketHandler()
        {
            _dispatcher = new DispatcherMultiMethod<IPacketHandler<IPacketRequest, IUser>>();
        }
        public static void Handle(this IPacketRequest packet, IUser sender, INetworkServerConnector connector, Server state)
        {
            _dispatcher.GetMethod(packet, sender)
                       .Call(packet, sender, connector, state);
        }
    }
}
