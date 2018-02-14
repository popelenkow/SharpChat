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

namespace SharpChat.Manager
{
    class ConnectionInspector : PropertyChangedBase, IConnectionInspector
    {
        private IClientManager _manager;
        private ConnectionResponse _connectionInfo;

        private bool _isConnected;
        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                if (_isConnected != value)
                {
                    _isConnected = value;
                    if (value == false)
                    {
                        _connector?.Close();
                        _connector = null;
                    }
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
            _timerUpdate.Tick += InitConnectorHandler;

            _timerConnectionPacket = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 1),
                IsEnabled = true
            };
            _timerConnectionPacket.Tick += ConnectionPacketHandler;
        }

        private void ReceivePacketHandler(object sender, EventArgs e)
        {
            _connector?.Receive()?.Handle(_connector, _manager);
        }
        private void InitConnectorHandler(object sender, EventArgs e)
        {
            if (_connector == null)
            {
                _connector = NetworkConnector.GetClientConnector();
            }
        }

        private void ConnectionPacketHandler(object sender, EventArgs e)
        {
            if (_connectionInfo != null && _connectionInfo.IsConnected)
            {
                IsConnected = true;
            }
            else
            {
                IsConnected = false;
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

        public void Close()
        {
            _connector?.Close();
        }

        public void Send(IPacketRequest packet)
        {
            _connector?.Send(packet);
        }

        
    }
}
