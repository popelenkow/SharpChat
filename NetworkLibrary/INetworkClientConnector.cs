using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;

namespace SharpChat.Network
{
    public interface INetworkClientConnector
    {
        void Send(IPacketRequest packet);
        IPacketResponse Receive();
        void Close();
        bool IsClosed { get; }
    }
}
