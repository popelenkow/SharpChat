using SharpChat.Network;
using SharpChat.Network.Packets;
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
        public List<NetworkConnector> Connectors { get; set; }

      

        public (IPacket Packet, NetworkConnector Connector) Receive()
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

        public void Send(IPacket packet)
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
