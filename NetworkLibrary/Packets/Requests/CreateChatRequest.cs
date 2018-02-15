using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Requests
{
    [Serializable]
    public class CreateChatRequest : PacketRequestBase
    {
        public string Name { get; set; }
    }
}
