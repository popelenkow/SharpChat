using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Responses
{
    [Serializable]
    public class SignUpResponseBase : PacketResponseBase
    {

    }
    [Serializable]
    class SignUpResponseLuck : SignUpResponseBase
    {

    }
    [Serializable]
    class SignUpResponseFail : SignUpResponseBase
    {

    }
}
