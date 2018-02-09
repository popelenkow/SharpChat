using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets
{
    [Serializable]
    public class MessagePacket : IPacket
    {
        public int Id { get; set; }
        public int IdChat { get; set; }
        public int IdPerson { get; set; }
        public string Text { get; set; }
    }
}
