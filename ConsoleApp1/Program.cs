using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharpChat.Packets;

namespace SharpChat
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = null;
            try
            {
                IPEndPoint ipServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13000);
                client = new TcpClient();
                client.Connect(ipServer);

                var manager = new NetworkManager();
                manager.Client = client;
                
                while (true)
                {
                    Thread.Sleep(2000);
                    manager.Send(new RequestPacket());
                    IPacket p = manager.Receive();
                    Console.WriteLine(p?.GetType());
                }

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                client.Close();
                // Stop listening for new clients.
            }


           
        }
    }
}
