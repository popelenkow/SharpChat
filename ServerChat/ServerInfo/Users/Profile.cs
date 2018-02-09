using SharpChat.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ServerInfo.Users
{
    class Profile : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<NetworkConnector> Connections { get; set; }
    }
}
