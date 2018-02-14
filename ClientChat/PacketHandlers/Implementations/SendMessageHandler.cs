using SharpChat.Management;
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
            var content = (ChatGridViewModel)manager.MainContent;
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
