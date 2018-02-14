using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Responses
{
    [Serializable]
    public abstract class SignUpResponseBase : PacketResponseBase
    {

    }
    [Serializable]
    public class SignUpResponseLuck : SignUpResponseBase
    {

    }
    [Serializable]
    public class SignUpResponseFail : SignUpResponseBase
    {
        public enum FailInfo
        {
            NotSpectator,
            ExistsEmail
        }
        public FailInfo Info { get; set; }
    }
}
