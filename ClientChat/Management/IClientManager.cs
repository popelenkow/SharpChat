using Caliburn.Micro;
using SharpChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Management
{
    interface IClientManager
    {
        void SendMessage(string text);
        PropertyChangedBase MainContent { get; set; }
        PropertyChangedBase EventContent { get; set; }
        IConnectionInspector ConnectionInspector { get; }
    }
}
