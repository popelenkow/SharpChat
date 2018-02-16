using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Responses
{
    [Serializable]
    public class MessageInfoResponse : PacketResponseBase
    {
        public int Id { get; set; }
        public int IdChat { get; set; }
        public int IdProfile { get; set; }
        public string Text { get; set; }
    }
}
