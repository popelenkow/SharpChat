using SharpChat.Network;
using SharpChat.Network.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ServerInfo.Users
{
    class Spectator : IUser
    {
        public NetworkConnector Connector { get; set; }

       

        public (IPacket Packet, NetworkConnector Connector) Receive()
        {
            return (Connector.Receive(), Connector);
        }
        public void Send(IPacket packet)
        {
            Connector.Send(packet);
        }
        public void Close()
        {
            Connector.Close();
        }
    }
}
