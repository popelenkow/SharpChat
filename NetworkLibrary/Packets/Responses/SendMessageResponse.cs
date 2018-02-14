using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Responses
{
    [Serializable]
    public abstract class SendMessageResponseBase : PacketResponseBase
    {
    }
    [Serializable]
    public class SendMessageResponseLuck : SendMessageResponseBase
    {
        public int IdChat { get; set; }
        public bool IsPersonChat { get; set; }
        public int IdMessage { get; set; }
        public int IdProfile { get; set; }
        public string Text { get; set; }
    }
    [Serializable]
    public class SendMessageResponseFail : SendMessageResponseBase
    {
        
    }
}
