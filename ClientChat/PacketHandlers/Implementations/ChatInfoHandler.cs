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
    class ChatInfoHandler : PacketHandlerBase<ChatInfoResponse>
    {
        public override void Call(ChatInfoResponse packet, IClientManager manager)
        {
            manager.MyProfile?.AddChatInfo(packet);
        }
    }
}
