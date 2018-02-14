﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.DB
{
    class Chat
    {
        public int Id { get; set; }
        public List<Profile> Profiles { get; set; } = new List<Profile>();
        public List<Message> Messages { get; set; } = new List<Message>();
        public bool IsPersonChat { get; set; }
    }
}
