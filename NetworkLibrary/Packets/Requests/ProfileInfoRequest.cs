﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Network.Packets.Requests
{
    [Serializable]
    public class ProfileInfoRequest : PacketRequestBase
    {
        public int Id { get; set; }
    }
}
