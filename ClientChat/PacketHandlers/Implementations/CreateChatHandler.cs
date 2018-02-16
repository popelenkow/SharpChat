using SharpChat.Management;
using SharpChat.Models;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using SharpChat.ViewModels.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers.Implementations
{
    class CreateChatHandler : PacketHandlerBase<CreateChatResponse>
    {
        public override void Call(CreateChatResponse packet, IClientManager manager)
        {
            var request = new ChatInfoRequest { Id = packet.Id };
            manager.ConnectionInspector.Send(request);
        }
    }
}
