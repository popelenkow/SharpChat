using SharpChat.Management;
using SharpChat.Network.Packets.Responses;
using SharpChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SharpChat.PacketHandlers.Implementations
{
    class SignUpHandler : PacketHandlerBase<SignUpResponseLuck>, IPacketHandler<SignUpResponseFail>
    {
        public override void Call(SignUpResponseLuck packet, IClientManager manager)
        {
            manager.EventContent = new WindowBoxViewModel(manager)
            {
                Text = "Sign Up luck!"
            };
        }
        public void Call(SignUpResponseFail packet, IClientManager manager)
        {
            manager.EventContent = new WindowBoxViewModel(manager)
            {
                Text = "Log In fail: " + packet.Info.ToString()
            };
        }
    }
}
