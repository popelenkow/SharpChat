using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets
{
    [Serializable]
    public class RequestPacket : IPacket
    {
        public enum RequestInfo
        {
            Empty,
            Online,
            IdPerson,
            IdChatPerson,
            IdChatGroup,
            Messages
        };
        public RequestInfo Info { get; set; }
        public int Id { get; set; }
    }
}
