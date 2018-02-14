using Caliburn.Micro;
using SharpChat.Network;
using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Manager
{
    interface IConnectionInspector : INotifyPropertyChangedEx
    {
        bool IsConnected { get; }
        void Close();
        void Send(IPacketRequest packet);
        void UpdateConnection(ConnectionResponse packet);
    }
}
