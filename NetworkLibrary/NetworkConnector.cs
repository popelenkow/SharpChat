using SharpChat.Network.InnerConnectors;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SharpChat.Network
{
    public static class NetworkConnector
    { 
        static private IPEndPoint _adressServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13000);
        static private Task _taskClientConnect;
        static private TcpClient _tcpClient;
        public static INetworkClientConnector GetClientConnector()
        {
            NetworkClientConnector nc = null;
            try
            {
                if (_taskClientConnect != null)
                {
                    if (_taskClientConnect.IsFaulted)
                    {
                        _taskClientConnect = null;
                    }
                    else if (_taskClientConnect.IsCompleted)
                    {
                        nc = new NetworkClientConnector(_tcpClient);
                        _taskClientConnect = null;
                        _tcpClient = null;
                    }
                }
                
                if (nc == null && _taskClientConnect == null)
                {
                    _tcpClient = new TcpClient();
                    _taskClientConnect = _tcpClient.ConnectAsync(_adressServer.Address, _adressServer.Port);
                }
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
        public static INetworkServerConnector GetServerConnector(TcpClient tcp)
        {
            INetworkServerConnector nc = null;
            try
            {
                nc = new NetworkServerConnector(tcp);
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
     
    }
}
