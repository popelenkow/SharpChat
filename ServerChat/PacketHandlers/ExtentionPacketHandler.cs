using PolymorphismSharp.Static.Dispatchers;
using SharpChat.Network;
using SharpChat.Network.Packets;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using SharpChat.Management;
using SharpChat.Management.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers
{
    static class ExtentionPacketHandler
    {
        private static DispatcherMultiMethod<IPacketHandler<IPacketRequest>> _dispatcher { get; set; }
        static ExtentionPacketHandler()
        {
            _dispatcher = new DispatcherMultiMethod<IPacketHandler<IPacketRequest>>();
        }
        public static void Handle(this IPacketRequest packet, IUser sender, IServerManager manager)
        {
            _dispatcher.GetMethod(packet)
                       .Call(packet, sender, manager);
        }
    }
}
