using SharpChat.DB;
using SharpChat.Management.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Management
{
    interface IServerManager
    {
        DataB Data { get; }
        List<IUser> Users { get; } 
    }
}
