using SharpChat.Network.Packets;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
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
using System.Threading.Tasks;

namespace SharpChat.Network.InnerConnectors
{
    class NetworkConnectorBase<TPacketSend, TPacketReceive>
        where TPacketSend : class, IPacket
        where TPacketReceive : class, IPacket
    {
        private byte[] _memoryReceive = new byte[100];
        private MemoryStream _streamReceive = new MemoryStream();
        private BinaryFormatter _formatter = new BinaryFormatter();
        private TcpClient _tcp;

        public NetworkConnectorBase(TcpClient tcp)
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
        public void Send(TPacketSend packet)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                _formatter.Serialize(ms, packet);
                byte[] arr = ms.ToArray();
                var stream = _tcp.GetStream();
                stream.Write(arr, 0, arr.Length);
            }
            catch (Exception ex)
            {

            }

        }
        public TPacketReceive Receive()
        {
            TPacketReceive packet = null;
            try
            {
                var stream = _tcp.GetStream();
                stream.ReadTimeout = 1;
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
                if (obj is TPacketReceive)
                {
                    packet = obj as TPacketReceive;
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
