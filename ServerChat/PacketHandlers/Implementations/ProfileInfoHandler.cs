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
    class ProfileInfoHandler : PacketHandlerBase<ProfileInfoRequest>
    {
        public override void Call(ProfileInfoRequest packet, IUser sender, IServerManager manager)
        {
            var profile = manager.Data.Profiles.Where(x => x.Id == packet.Id).FirstOrDefault();
            var p = new ProfileInfoResponse
            {
               Id = profile.Id,
               Name = profile.Name
            };
            sender.Connector.Send(p);
        }
    }
}
