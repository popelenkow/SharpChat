using SharpChat.Packets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharpChat
{
    public class NetworkManager
    {
        public TcpClient Client { get; set; }
        public byte[] MemoryReceive { get; set; } = new byte[100];
        public MemoryStream StreamReceive { get; set; } = new MemoryStream();
        public BinaryFormatter Formatter { get; set; } = new BinaryFormatter();
        public void Send(IPacket packet)
        {
            
            NetworkStream stream = null;
            try
            {
                MemoryStream ms = new MemoryStream();
                Formatter.Serialize(ms, packet);
                byte[] arr = ms.ToArray();
                stream = Client.GetStream();
                stream.Write(arr, 0, arr.Length);
            }
            catch(Exception ex)
            {

            }

        }
        public IPacket Receive()
        {
            IPacket packet = null;
            try
            {
                var stream = Client.GetStream();
                stream.ReadTimeout = 10;
                int size = MemoryReceive.Length;
                StreamReceive.Position = StreamReceive.Length;
                while (size == MemoryReceive.Length)
                {
                    size = stream.Read(MemoryReceive, 0, MemoryReceive.Length);
                    StreamReceive.Write(MemoryReceive, 0, size);
                }
                StreamReceive.Position = 0;
                var obj = Formatter.Deserialize(StreamReceive);
                //ms.Position changes here
                //...
                byte[] data = StreamReceive.ToArray().Skip((int)StreamReceive.Position).ToArray();
                StreamReceive = new MemoryStream();
                StreamReceive.Write(data, 0, data.Length);
                if (obj is IPacket)
                {
                    packet = obj as IPacket;
                }
            }
            catch (SerializationException ex)
            {

            }
            catch (Exception ex)
            {

            }

            return packet;
        }


    }
}
