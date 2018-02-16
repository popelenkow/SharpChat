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
using SharpChat.Management.Users;
using SharpChat.DB;
using SharpChat.Network.Packets.Requests;

namespace SharpChat.Management
{
    class ServerManager : IServerManager
    {
        public List<IUser> Users { get; } = new List<IUser>();
        public DataBase Data { get; }  = new DataBase();
        private NetworkListener _listener;
        
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
                    Thread.Sleep(10);
                    var nc = _listener.GetServerConnector();
                    if (nc != null)
                    {
                        var s = new User(nc);
                        Users.Add(s);
                        Console.WriteLine("Connected!");
                    }
                    foreach(var user in Users)
                    {
                        IPacketRequest p;
                        do
                        {
                            p = user.Connector.Receive();
                            if (p != null)
                            {
                                Console.WriteLine(p.GetType());
                            }
                            p?.Handle(user, this);
                        } while (p != null);
                    }
                    var arr = Users.Where(x => x.Connector.IsClosed).ToList();
                    foreach (var it in arr)
                    {
                        Users.Remove(it);
                    }
                }

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                foreach(var user in Users)
                {
                    user.Connector.Close();
                }
                // Stop listening for new clients.
                _listener.Close();
            }
        }
    }
}
