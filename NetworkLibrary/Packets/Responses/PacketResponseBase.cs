﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Responses
{
    [Serializable]
    public abstract class PacketResponseBase : IPacketResponse
    {
        public int InnerId { get; set; }
    }
}