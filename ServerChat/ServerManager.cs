using SharpChat.Network.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharpChat.PacketHandlers;
using SharpChat.Network;
using SharpChat.ServerInfo.Users;

namespace SharpChat
{
    class ServerManager
    {
        private NetworkListener _listener;
        private List<IUser> _users = new List<IUser>();
        public ServerManager()
        {
            _listener = new NetworkListener();
        }
        public void Run()
        {
            int id = 0;
            try
            {
                Console.WriteLine("Open");
                while (true)
                {
                    Thread.Sleep(10);
                    var nc = _listener.GetServerConnector();
                    if (nc != null)
                    {
                        var user = new Profile();
                        user.Connectors.Add(nc);
                        user.Id = id++;
                        _users.Add(user);
                        Console.WriteLine("Connected!");
                    }
                    foreach(var user in _users)
                    {
                        var pc = user.Receive();
                        if (pc.Packet != null)
                        {
                            Console.WriteLine(pc.Packet.GetType());
                        }
                        pc.Packet?.Handle(user, pc.Connector, null);
                    }
                }

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                foreach(var user in _users)
                {
                    user.Close();
                }
                // Stop listening for new clients.
                _listener.Close();
            }
        }
    }
}
