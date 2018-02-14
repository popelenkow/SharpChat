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
    class LogInHandler : PacketHandlerBase<LogInRequest>
    {
        public override void Call(LogInRequest packet, IUser sender, IServerManager manager)
        {
            var profile = manager.Data.Profiles.Where(x => x.Email.Equals(packet.Email)).FirstOrDefault();
            IPacketResponse p = null;
            if (sender.IsLogIn)
            {
                p = new LogInResponseFail
                {
                    Info = LogInResponseFail.FailInfo.NotSpectator
                };
            }
            else if (profile == null)
            {
                p = new LogInResponseFail
                {
                    Info = LogInResponseFail.FailInfo.NotFoundEmail
                };
            }
            else if (manager.Users.Any(x => x.IsLogIn && x.Id == profile.Id))
            {
                p = new LogInResponseFail
                {
                    Info = LogInResponseFail.FailInfo.AlreadyOnline
                };
            }
            else if (!profile.Password.Equals(packet.Password))
            {
                p = new LogInResponseFail
                {
                    Info = LogInResponseFail.FailInfo.IncorrectPassword
                };
            }
            else
            {
                p = new LogInResponseLuck();
                sender.IsLogIn = true;
                sender.Id = profile.Id;
            }
            sender.Connector.Send(p);
        }
    }
}
