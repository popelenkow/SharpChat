using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.InnerConnectors
{
    class NetworkClientConnector : NetworkConnectorBase<IPacketRequest, IPacketResponse>, INetworkClientConnector
    {
        public NetworkClientConnector(TcpClient tcp) : base(tcp)
        {
        }
    }
}
