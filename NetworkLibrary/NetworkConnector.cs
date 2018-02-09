using SharpChat.Network.Packets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharpChat.Network
{
    public class NetworkConnector
    {
        private byte[] _memoryReceive = new byte[100];
        private MemoryStream _streamReceive = new MemoryStream();
        private BinaryFormatter _formatter = new BinaryFormatter();
        private TcpClient _tcp;

        static private IPEndPoint _adressServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13000);

        public static NetworkConnector GetClientConnector()
        {
            NetworkConnector nc = null;
            try
            {
                var tcp = new TcpClient();
                tcp.Connect(_adressServer);
                nc = new NetworkConnector(tcp);
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Connector null adress connect crash: " + ex.ToString());
            }
            catch (SocketException ex)
            {
                Debug.WriteLine("Connector null adress connect crash: " + ex.ToString());
            }
            catch (ObjectDisposedException ex)
            {
                Debug.WriteLine("Connector socket is closed connect crash: " + ex.ToString());
            }
            return nc;
        }
        public NetworkConnector(TcpClient tcp)
        {
            _tcp = tcp;
        }

        public void Close()
        {
            try
            {
                if (_tcp.Connected)
                {
                    _tcp.Close();
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine("Connector close crash: " + ex.ToString());
            }
        }
        public void Send(IPacket packet)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                _formatter.Serialize(ms, packet);
                byte[] arr = ms.ToArray();
                var stream = _tcp.GetStream();
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
                var stream = _tcp.GetStream();
                stream.ReadTimeout = 10;
                int size = _memoryReceive.Length;
                _streamReceive.Position = _streamReceive.Length;
                while (size == _memoryReceive.Length)
                {
                    size = stream.Read(_memoryReceive, 0, _memoryReceive.Length);
                    _streamReceive.Write(_memoryReceive, 0, size);
                }
                _streamReceive.Position = 0;
                var obj = _formatter.Deserialize(_streamReceive);
                byte[] data = _streamReceive.ToArray().Skip((int)_streamReceive.Position).ToArray();
                _streamReceive = new MemoryStream();
                _streamReceive.Write(data, 0, data.Length);
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
