using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network
{
    public class NetworkListener
    {
        private TcpListener _listener;
        public NetworkListener()
        {
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            _listener = new TcpListener(localAddr, port);

            _listener.Server.ReceiveTimeout = 10;
            _listener.Server.SendTimeout = 10;
        }
        public bool IsOpen { get; private set; }
        public void Open()
        {
            try
            {
                if (!IsOpen)
                {
                    IsOpen = true;
                    _listener.Start();
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine("Listener open crash: " + ex.ToString());
            }
}
        public void Close()
        {
            try
            {
                if (IsOpen)
                {
                    IsOpen = false;
                    _listener.Stop();
                }
            }
            catch(SocketException ex)
            {
                Debug.WriteLine("Listener close crash: " + ex.ToString());
            }
           
        }
        public NetworkConnector GetConnector()
        {
            TcpClient client = null;
            try
            {
                if (IsOpen)
                {
                    client = _listener.AcceptTcpClient();
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
            return new NetworkConnector(client);
        }
    }
}
