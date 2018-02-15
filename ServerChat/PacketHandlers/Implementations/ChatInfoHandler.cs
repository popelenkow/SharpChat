using SharpChat.Management;
using SharpChat.Management.Users;
using SharpChat.Network.Packets.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers.Implementations
{
    class ChatInfoHandler : PacketHandlerBase<ChatInfoRequest>
    {
        public override void Call(ChatInfoRequest packet, IUser sender, IServerManager manager)
        {
            //var chat = manager.Data.Chats.Where(x => x.Id == packet.Id).First();
        }
    }
}
