using SharpChat.Network;
using SharpChat.Network.Packets;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Management.Users
{
    class User : IUser
    {
        public int Id { get; set; }
        public bool IsLogIn { get; set; }
        public INetworkServerConnector Connector { get; }
        public User(INetworkServerConnector connector)
        {
            Connector = connector;
        }
    }
}
