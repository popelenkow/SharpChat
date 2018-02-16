using SharpChat.Management;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using SharpChat.ViewModels.EventContents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.PacketHandlers.Implementations
{
    class InviteProfileHandler : PacketHandlerBase<InviteProfileResponseLuck>, IPacketHandler<InviteProfileResponseFail>
    {
        public override void Call(InviteProfileResponseLuck packet, IClientManager manager)
        {
            /*
            var request = new ChatInfoRequest { Id = packet.IdChat };
            manager.ConnectionInspector.Send(request);
            */
        }

        public void Call(InviteProfileResponseFail packet, IClientManager manager)
        {
            manager.EventContent = new WindowBoxViewModel(manager)
            {
                Text = "Invite profile fail: " + packet.Info.ToString()
            };
        }
    }
}
