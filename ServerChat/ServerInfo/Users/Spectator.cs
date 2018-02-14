using SharpChat.Network;
using SharpChat.Network.Packets;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.ServerInfo.Users
{
    class Spectator : IUser
    {
        public INetworkServerConnector Connector { get; set; }

       

        public (IPacketRequest Packet, INetworkServerConnector Connector) Receive()
        {
            return (Connector.Receive(), Connector);
        }
        public void Send(IPacketResponse packet)
        {
            Connector.Send(packet);
        }
        public void Close()
        {
            Connector.Close();
        }
    }
}
