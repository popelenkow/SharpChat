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

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ipServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13000);
            TcpClient client = new TcpClient();
            client.Connect(ipServer);
            var p1 = new EmptyPacket();
            var p2 = new RequestPacket();

            byte[] userDataBytes;
            MemoryStream ms = new MemoryStream();

            BinaryFormatter bf1 = new BinaryFormatter();

            bf1.Serialize(ms, p1);
            bf1.Serialize(ms, p2);

            userDataBytes = ms.ToArray();

            var s = client.GetStream();
            s.Write(userDataBytes, 0, userDataBytes.Length);

            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
