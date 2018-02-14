using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Requests
{
    [Serializable]
    public class SendMessageRequest : PacketRequestBase
    {
        public int IdChat { get; set; }
        public bool IsPersonChat { get; set; }
        public string Text { get; set; }
    }
}
