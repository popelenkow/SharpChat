using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets
{
    [Serializable]
    public class ErrorPacket : IPacket
    {
        public enum ErrorInfo
        {

        };
        public ErrorInfo Info { get; set; }
    }
}
