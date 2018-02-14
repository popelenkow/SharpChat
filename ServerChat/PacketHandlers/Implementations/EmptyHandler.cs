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

namespace SharpChat.PacketHandlers.Implementations
{
    class EmptyHandler : PacketHandlerBase<EmptyRequest>
    {
        public override void Call(EmptyRequest packet, IUser sender, IServerManager manager)
        {
            var p = new EmptyResponse
            {
            };
            sender.Connector.Send(p);
        }
    }
}
