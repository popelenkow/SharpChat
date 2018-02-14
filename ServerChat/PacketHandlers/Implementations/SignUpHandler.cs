using SharpChat.DB;
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
    class SignUpHandler : PacketHandlerBase<SignUpRequest>
    {
        public override void Call(SignUpRequest packet, IUser sender, IServerManager manager)
        {
            var profiles = manager.Data.Profiles;
            var profile = profiles.Where(x => x.Email.Equals(packet.Email)).FirstOrDefault();
            IPacketResponse p = null;
            if (sender.IsLogIn)
            {
                p = new SignUpResponseFail
                {
                    Info = SignUpResponseFail.FailInfo.NotSpectator
                };
            }
            else if (profile != null)
            {
                p = new SignUpResponseFail
                {
                    Info = SignUpResponseFail.FailInfo.ExistsEmail
                };
            }
            else
            {
                p = new SignUpResponseLuck();
                int id = profiles.Count() + 1;
                var newProfile = new Profile
                {
                    Id = id,
                    Email = packet.Email,
                    Password = packet.Password,
                    Name = packet.Name
                };
                manager.Data.Profiles.Add(newProfile);
            }
            sender.Connector.Send(p);
        }
    }
}
