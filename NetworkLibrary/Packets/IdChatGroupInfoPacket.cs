using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets
{
    [Serializable]
    public class IdChatGroupInfoPacket : IPacket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] IdPersons { get; set; }
    }
}
