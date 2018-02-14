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
    interface IUser
    {
        INetworkServerConnector Connector { get; }
        bool IsLogIn { get; set; }
        int Id { get; set; }
    }
}
