using SharpChat.Management;
using SharpChat.Management.Users;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers.Implementations
{
    class InviteProfileHandler : PacketHandlerBase<InviteProfileRequest>
    {
        public override void Call(InviteProfileRequest packet, IUser sender, IServerManager manager)
        {
            if (!manager.Data.Chats.Any(x => x.Id == packet.IdChat))
            {
                var response = new InviteProfileResponseFail { Info = InviteProfileResponseFail.FailInfo.NotFoundChat };
                sender.Connector.Send(response);
            }
            else if (!manager.Data.Profiles.Any(x => x.Id == packet.Id))
            {
                var response = new InviteProfileResponseFail { Info = InviteProfileResponseFail.FailInfo.NotFoundProfile };
                sender.Connector.Send(response);
            }
            else if (manager.Data.Chats.Where(x => x.Id == packet.IdChat).First().Profiles.Any(x => x.Id == packet.Id))
            {
                var response = new InviteProfileResponseFail { Info = InviteProfileResponseFail.FailInfo.Invited };
                sender.Connector.Send(response);
            }
            else
            {
                var chat = manager.Data.Chats.Where(x => x.Id == packet.IdChat).First();
                var profile = manager.Data.Profiles.Where(x => x.Id == packet.Id).First();
                chat.Profiles.Add(profile);

                var response = new InviteProfileResponseLuck { IdChat = packet.IdChat };
                sender.Connector.Send(response);

                var users = manager.Users.Where(x => x.IsLogIn && chat.Profiles.Any(y => y.Id == x.Id));
                foreach (var user in users)
                {
                    var idMessages = chat.Messages.Select(x => x.Id).ToArray();
                    var idProfiles = chat.Profiles.Select(x => x.Id).ToArray();
                    var info = new ChatInfoResponse
                    {
                        Id = chat.Id,
                        Name = chat.Name,
                        IdProfiles = idProfiles,
                        IdMessages = idMessages
                    };
                    user.Connector.Send(info);
                }
                


            }
        }
    }
}
