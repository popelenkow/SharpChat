using SharpChat.Network.Packets.Requests;
using SharpChat.Network.Packets.Responses;

namespace SharpChat.Network
{
    public interface INetworkServerConnector
    {
        void Send(IPacketResponse packet);
        IPacketRequest Receive();
        void Close();
    }
}
