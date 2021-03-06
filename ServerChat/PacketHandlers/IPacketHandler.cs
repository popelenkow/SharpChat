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
    interface IPacketHandler<TPacket> : IMultiMethod
        where TPacket : IPacketRequest
    {
        void Call(TPacket packet, IUser sender, IServerManager manager);
    }
}
