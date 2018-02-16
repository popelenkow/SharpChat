using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Responses
{
    [Serializable]
    public class ChatInfoResponse : PacketResponseBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] IdProfiles { get; set; }
        public int[] IdMessages { get; set; }
    }
}
