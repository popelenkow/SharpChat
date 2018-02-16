using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Responses
{
    [Serializable]
    public class MyProfileInfoResponseLuck : PacketResponseBase
    {
        public int Id { get; set; }
        public int[] IdChats { get; set; }
    }
    [Serializable]
    public class MyProfileInfoResponseFail : PacketResponseBase
    {
        public enum FailInfo
        {
            NotAuthorized
        }
        public FailInfo Info { get; set; }
    }
}
