using SharpChat.Management;
using SharpChat.Models;
using SharpChat.Network;
using SharpChat.Network.Packets;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using SharpChat.ViewModels;
using SharpChat.ViewModels.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers.Implementations
{
    class SendMessageHandler : PacketHandlerBase<SendMessageResponseLuck>
    {
        public override void Call(SendMessageResponseLuck packet, IClientManager manager)
        {
            /*
            var request = new MessageInfoRequest { Id = packet.Id };
            manager.ConnectionInspector.Send(request);
            */
        }
    }
}
