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

namespace SharpChat
{
    class ServerManager
    {
        private NetworkListener _listener;
        private List<(bool IsOk, NetworkConnector Manager)> _clients;
        public ServerManager()
        {
            _listener = new NetworkListener();
        }
        public void Run()
        {
            NetworkConnector nc = null;
            try
            {
                _listener.Open();



                // Enter the listening loop.

                Console.WriteLine("Waiting for a connection... ");

                // Perform a blocking call to accept requests.
                // You could also user server.AcceptSocket() here.
                while(nc == null)
                {
                    Thread.Sleep(3000);
                    Console.WriteLine(".");
                    nc = _listener.GetConnector();
                }
                Console.WriteLine("Connected!");



                while (true)
                {
                    Thread.Sleep(1000);
                    nc.Send(new EmptyPacket());
                    IPacket p = nc.Receive();
                    Console.WriteLine(p?.GetType());
                    p?.Handle(null, null, null);
                }

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                nc.Close();
                // Stop listening for new clients.
                _listener.Close();
            }
        }
    }
}
