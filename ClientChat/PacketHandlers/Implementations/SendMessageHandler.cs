using SharpChat.Manager;
using SharpChat.Network;
using SharpChat.Network.Packets;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using SharpChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers.Implementations
{
    class SendMessageHandler : PacketHandlerBase<SendMessageResponseLuck>
    {
        public override void Call(SendMessageResponseLuck packet, INetworkClientConnector connector, IClientManager manager)
        {
            var content = manager.GetContent<ChatGridViewModel>();
            if (content == null) return;
            var ms = content.MessagesFeed.Messages;
            var vm = new MessageBlockViewModel
            {
                Id = 0,
                IdPerson = 1,
                NamePerson = "2",
                Text = packet.Text
            };
            ms.Add(vm);
        }
    }
}
