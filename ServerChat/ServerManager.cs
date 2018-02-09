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
            try
            {

                Console.WriteLine("Open");
                while (true)
                {
                    Thread.Sleep(50);
                    var nc = _listener.GetConnector();
                    if (nc != null)
                    {
                        _users.Add(new Spectator { Connector = nc });
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
