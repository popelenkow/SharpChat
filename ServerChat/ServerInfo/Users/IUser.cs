using SharpChat.Network;
using SharpChat.Network.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ServerInfo.Users
{
    interface IUser
    {
        void Send(IPacket packet);
        (IPacket Packet, NetworkConnector Connector) Receive();
        void Close();
    }
}
