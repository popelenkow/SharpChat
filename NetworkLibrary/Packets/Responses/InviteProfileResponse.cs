using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Responses
{
    [Serializable]
    public class InviteProfileResponseLuck : PacketResponseBase
    {
        public int IdChat { get; set; }
    }
    [Serializable]
    public class InviteProfileResponseFail : PacketResponseBase
    {
        public enum FailInfo
        {
            NotFoundProfile,
            NotFoundChat,
            Invited
        }
        public FailInfo Info { get; set; }
    }
}
