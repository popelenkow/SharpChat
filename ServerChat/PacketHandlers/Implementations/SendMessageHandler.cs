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
using SharpChat.DB;

namespace SharpChat.PacketHandlers.Implementations
{
    class SendMessageHandler : PacketHandlerBase<SendMessageRequest>
    {
        public override void Call(SendMessageRequest packet, IUser sender, IServerManager manager)
        {
            var ms = manager.Data.Messages;
            var chat = manager.Data.Chats.Where(x => x.Id == packet.IdChat).First();
            
            var message = new Message
            {
                Id = ms.Count() + 1,
                IdProfile = sender.Id,
                Text = packet.Text
            };

            ms.Add(message);
            chat.Messages.Add(message);


            var response = new SendMessageResponseLuck
            {
                Id = message.Id
            };
            sender.Connector.Send(response);



            var users = manager.Users.Where(x => x.IsLogIn && chat.Profiles.Any(y => y.Id == x.Id));
            foreach (var user in users)
            {
                var p = new MessageInfoResponse
                {
                    Id = message.Id,
                    Text = message.Text,
                    IdChat = chat.Id,
                    IdProfile = message.IdProfile
                };
                user.Connector.Send(p);
            }
        }
    }
}
