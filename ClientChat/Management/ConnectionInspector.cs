using SharpChat.Network;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Windows.Threading;
using SharpChat.PacketHandlers;

namespace SharpChat.Management
{
    class ConnectionInspector : PropertyChangedBase, IConnectionInspector
    {
        private IClientManager _manager;
        private ConnectionResponse _connectionInfo;

        private bool _isClosed = false;

        public void Close()
        {
            _isClosed = true;
            _connector?.Close();
            _connector = null;
        }

        private bool _isConnected;
        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                if (_isConnected != value)
                {
                    _isConnected = value;
                    NotifyOfPropertyChange(() => IsConnected);
                }
            }
        }

        private DispatcherTimer _timerUpdate;
        private DispatcherTimer _timerConnectionPacket;

        private INetworkClientConnector _connector = NetworkConnector.GetClientConnector();

        public ConnectionInspector(IClientManager manager)
        {
            _manager = manager;

            _timerUpdate = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 10),
                IsEnabled = true
            };
            _timerUpdate.Tick += ReceivePacketHandler;

            _timerConnectionPacket = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 1),
                IsEnabled = true
            };
            _timerConnectionPacket.Tick += ConnectionHandler;
        }

        private void ReceivePacketHandler(object sender, EventArgs e)
        {
            IPacketResponse p = null;
            do
            {
                p = _connector?.Receive();
                p?.Handle(_manager);
            } while (p != null);
        }
 

        private void ConnectionHandler(object sender, EventArgs e)
        {
            if (_isClosed) return;
            if (_connector == null || _connector?.IsClosed == true)
            {
                _connector = NetworkConnector.GetClientConnector();
                IsConnected = false;
            }
            else if (_connectionInfo == null || !_connectionInfo.IsConnected)
            {
                IsConnected = false;
                _connector.Close();
                _connector = null;
            }
            else
            {
                IsConnected = true;
            }
            _connectionInfo = null;
            var request = new ConnectionRequest
            {
                IsConnect = true
            };
            _connector?.Send(request);
        }

        public void UpdateConnection(ConnectionResponse packet)
        {
            _connectionInfo = packet;
        }


        public void Send(IPacketRequest packet)
        {
            _connector?.Send(packet);
        }

        
    }
}
