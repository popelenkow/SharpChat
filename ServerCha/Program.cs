﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharpChat.Network.Packets;

namespace SharpChat
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ServerManager sm = new ServerManager();
            sm.Run();
        }
    }
}