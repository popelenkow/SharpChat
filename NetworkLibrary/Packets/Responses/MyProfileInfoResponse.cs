using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Responses
{
    [Serializable]
    public class MyProfileInfoResponse : PacketResponseBase
    {
        public int Id { get; set; }
        public int[] IdPersonChats { get; set; }
        public int[] IdGroupChats { get; set; }
    }
}
