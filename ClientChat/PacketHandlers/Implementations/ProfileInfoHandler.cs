using SharpChat.Management;
using SharpChat.Network.Packets.Responses;
using SharpChat.ViewModels.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers.Implementations
{
    class ProfileInfoHandler : PacketHandlerBase<ProfileInfoResponse>
    {
        public override void Call(ProfileInfoResponse packet, IClientManager manager)
        {
            manager.MyProfile?.AddProfileInfo(packet);
        }
    }
}
