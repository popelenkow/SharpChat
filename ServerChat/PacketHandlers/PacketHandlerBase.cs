﻿using PolymorphismSharp.Static.Methods;
using SharpChat.Network;
using SharpChat.Network.Packets;
using SharpChat.Network.Packets.Requests;
using SharpChat.Management;
using SharpChat.Management.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers
{
    abstract class PacketHandlerBase<TPacket> : MultiMethod, IPacketHandler<TPacket>
        where TPacket : IPacketRequest
    {
        public abstract void Call(TPacket packet, IUser sender, IServerManager manager);
    }
}
