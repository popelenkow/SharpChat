using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Responses
{
    [Serializable]
    public class ProfileInfoResponse : PacketResponseBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
