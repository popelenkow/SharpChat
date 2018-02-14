using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.InnerConnectors
{
    class NetworkServerConnector : NetworkConnectorBase<IPacketResponse, IPacketRequest>, INetworkServerConnector
    {

        public NetworkServerConnector(TcpClient tcp) : base(tcp)
        {
        }
    }
}
