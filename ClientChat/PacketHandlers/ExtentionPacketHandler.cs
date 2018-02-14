using PolymorphismSharp.Static.Dispatchers;
using SharpChat.Manager;
using SharpChat.Network;
using SharpChat.Network.Packets;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers
{
    static class ExtentionPacketHandler
    {
        private static DispatcherMultiMethod<IPacketHandler<IPacketResponse>> _dispatcher { get; set; }
        static ExtentionPacketHandler()
        {
            _dispatcher = new DispatcherMultiMethod<IPacketHandler<IPacketResponse>>();
        }
        public static void Handle(this IPacketResponse packet, INetworkClientConnector connector, IClientManager manager)
        {
            _dispatcher.GetMethod(packet)
                       .Call(packet, connector, manager);
        }
    }
}
