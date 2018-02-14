using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Responses
{
    [Serializable]
    public abstract class LogInResponseBase : PacketResponseBase
    {

    }
    [Serializable]
    public class LogInResponseLuck : LogInResponseBase
    {

    }
    [Serializable]
    public class LogInResponseFail : LogInResponseBase
    {
        public enum FailInfo
        {
            NotSpectator,
            NotFoundEmail,
            IncorrectPassword,
            AlreadyOnline
        }
        public FailInfo Info { get; set; }
    }
}
