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

namespace SharpChat.PacketHandlers.Implementations
{
    class EmptyHandler : PacketHandlerBase<EmptyResponse>
    {
        public override void Call(EmptyResponse packet, INetworkClientConnector connector, IClientManager manager)
        {
        }
    }
}
