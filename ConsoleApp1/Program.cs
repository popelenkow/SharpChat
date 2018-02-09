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
using SharpChat.Network;
using SharpChat.Network.Packets;

namespace SharpChat
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = null;
            try
            {
                var connector = NetworkConnector.GetClientConnector();
                
                while (true)
                {
                    Thread.Sleep(2000);
                    IPacket sp = new RequestPacket
                    {
                        Info = RequestPacket.RequestInfo.Empty
                    };
                    connector.Send(sp);
                    IPacket rp = connector.Receive();
                    Console.WriteLine(rp?.GetType());
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
