using SharpChat.Management;
using SharpChat.Network.Packets.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers.Implementations
{
    class MessageInfoHandler : PacketHandlerBase<MessageInfoResponse>
    {
        public override void Call(MessageInfoResponse packet, IClientManager manager)
        {
            manager.MyProfile?.AddMessageInfo(packet);
        }
    }
}
