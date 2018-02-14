using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Requests
{
    [Serializable]
    public class LogInRequest : PacketRequestBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
