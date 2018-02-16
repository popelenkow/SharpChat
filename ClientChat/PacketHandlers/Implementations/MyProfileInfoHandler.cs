using SharpChat.Extentions;
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
    class MyProfileInfoHandler : PacketHandlerBase<MyProfileInfoResponseLuck>
    {
        public override void Call(MyProfileInfoResponseLuck packet, IClientManager manager)
        {
            var myProfile = manager.MyProfile;
            if (myProfile == null) return;
            myProfile.MyProfile.Id = packet.Id;
            {
                var request = new ProfileInfoRequest { Id = packet.Id };
                manager.ConnectionInspector.Send(request);
            }
            foreach (var id in packet.IdChats)
            {
                var request = new ChatInfoRequest { Id = id };
                manager.ConnectionInspector.Send(request);
            }
        }
    }
}
