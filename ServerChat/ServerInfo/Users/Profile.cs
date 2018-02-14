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
    class Profile : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<INetworkServerConnector> Connectors { get; set; } = new List<INetworkServerConnector>();

      

        public (IPacketRequest Packet, INetworkServerConnector Connector) Receive()
        {
            foreach(var nc in Connectors)
            {
                var p = nc.Receive();
                if (p != null)
                {
                    return (p, nc);
                }
            }
            return (null, null);
        }

        public void Send(IPacketResponse packet)
        {
            foreach (var nc in Connectors)
            {
                nc.Send(packet);
            }
        }
        public void Close()
        {
            foreach (var nc in Connectors)
            {
                nc.Close();
            }
        }
    }
}
