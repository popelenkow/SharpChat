﻿using SharpChat.Manager;
using SharpChat.Network;
using SharpChat.Network.Packets.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers.Implementations
{
    class ConnectionHandler : PacketHandlerBase<ConnectionResponse>
    {
        public override void Call(ConnectionResponse packet, INetworkClientConnector connector, IClientManager manager)
        {
            manager.ConnectionInspector.UpdateConnection(packet);
        }
    }
}