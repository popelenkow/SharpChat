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
            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                
                // Enter the listening loop.

                Console.WriteLine("Waiting for a connection... ");

                // Perform a blocking call to accept requests.
                // You could also user server.AcceptSocket() here.
                Task<TcpClient> taskClient = server.AcceptTcpClientAsync();
                while (!taskClient.IsCompleted)
                {
                    Thread.Sleep(3000);
                    Console.WriteLine(".");
                }
                client = taskClient.Result;
                Console.WriteLine("Connected!");

                
                
                var manager = new NetworkManager();
                manager.Client = client;
                while (true)
                {
                    Thread.Sleep(1000);
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
                server.Stop();
            }
            
        }
    }
}
