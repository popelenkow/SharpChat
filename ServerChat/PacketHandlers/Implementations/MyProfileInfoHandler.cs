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
    class MyProfileInfoHandler : PacketHandlerBase<MyProfileInfoRequest>
    {
        public override void Call(MyProfileInfoRequest packet, IUser sender, IServerManager manager)
        {
            IPacketResponse p = null;
            if (sender.IsLogIn)
            {
                int[] idChats = manager.Data.Chats.Where(x => x.Profiles.Any(y => y.Id == sender.Id)).Select(x => x.Id).ToArray();
                p = new MyProfileInfoResponseLuck
                {
                    Id = sender.Id,
                    IdChats = idChats
                };
            }
            else
            {
                p = new MyProfileInfoResponseFail
                {
                    Info = MyProfileInfoResponseFail.FailInfo.NotAuthorized
                };
            }
            sender.Connector.Send(p);
        }
    }
}
