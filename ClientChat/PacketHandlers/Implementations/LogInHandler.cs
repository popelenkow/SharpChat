using SharpChat.Management;
using SharpChat.Network;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using SharpChat.ViewModels;
using SharpChat.ViewModels.Chat;
using SharpChat.ViewModels.EventContents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SharpChat.PacketHandlers.Implementations
{
    class LogInHandler : PacketHandlerBase<LogInResponseLuck>, IPacketHandler<LogInResponseFail>
    {
        public override void Call(LogInResponseLuck  packet, IClientManager manager)
        {
            manager.MainContent = new ChatGridViewModel(manager);
        }
        public void Call(LogInResponseFail packet, IClientManager manager)
        {
            manager.EventContent = new WindowBoxViewModel(manager)
            {
                Text = "Log in fail: " + packet.Info.ToString()
            };
        }
    }
}
