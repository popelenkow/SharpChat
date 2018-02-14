﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Requests
{
    [Serializable]
    public abstract class PacketRequestBase : IPacketRequest
    {
        public int InnerId { get; set; }
    }
}