using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.DB
{
    class DataBase
    {
        public List<Profile> Profiles { get; set; } = new List<Profile>();
        public List<Chat> Chats { get; set; } = new List<Chat>();
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
