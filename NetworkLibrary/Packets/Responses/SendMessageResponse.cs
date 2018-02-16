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
        public int Id { get; set; }
    }
    [Serializable]
    public class SendMessageResponseFail : SendMessageResponseBase
    {
        
    }
}
