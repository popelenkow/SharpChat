using SharpChat.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ServerInfo.Users
{
    class Spectator : IUser
    {
        public NetworkConnector Connection { get; set; }
    }
}
