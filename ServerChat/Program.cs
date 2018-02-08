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

namespace ServerChat
{
    class Program
    {
        static void Main(string[] args)
        {
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

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    Console.WriteLine("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    Task<TcpClient> taskClient = server.AcceptTcpClientAsync();
                    while (!taskClient.IsCompleted)
                    {
                        Thread.Sleep(3000);
                        Console.WriteLine(".");
                    }
                    TcpClient client = taskClient.Result;
                    Console.WriteLine("Connected!");
                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;
                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        BinaryFormatter bf1 = new BinaryFormatter();
                        MemoryStream ms = new MemoryStream();
                        ms.Write(bytes, 0, bytes.Length);
                        ms.Position = 0;
                        object rawObj = bf1.Deserialize(ms);
                        rawObj = bf1.Deserialize(ms);
                        rawObj = bf1.Deserialize(ms);

                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
            
        }
    }
}
