using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SharpChat.Network
{
    public class NetworkListener
    {
        private TcpListener _listener;
        private Task<TcpClient> _task;
        private bool _isOpen;

        public NetworkListener()
        {
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            try
            {
                _listener = new TcpListener(localAddr, port);
                _listener.Start();

                _isOpen = true;
                _task = _listener.AcceptTcpClientAsync();

            }
            catch (SocketException ex)
            {
                _isOpen = false;
                Debug.WriteLine("Listener open crash: " + ex.ToString());
            }

        }
        

        public void Close()
        {
            try
            {
                if (_isOpen)
                {
                    _isOpen = false;
                    _listener.Stop();
                }
            }
            catch(SocketException ex)
            {
                Debug.WriteLine("Listener close crash: " + ex.ToString());
            }
           
        }
        public INetworkServerConnector GetServerConnector()
        {
            TcpClient client = null;
            try
            {
                if (_isOpen)
                {
                    if (_task.IsCompleted)
                    {
                        client = _task.Result;
                        _task = _listener.AcceptTcpClientAsync();
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine("Listener is closed accept crash: " + ex.ToString());
            }
            catch (SocketException ex)
            {
                Debug.WriteLine("Listener accept crash: " + ex.ToString());
            }
            if (client == null) return null; 
            return NetworkConnector.GetServerConnector(client);
        }
    }
}
