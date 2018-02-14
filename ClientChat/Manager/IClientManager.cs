using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Manager
{
    interface IClientManager
    {
        void SendMessage(string text);
        TViewModel GetContent<TViewModel>() where TViewModel : PropertyChangedBase;
        PropertyChangedBase Content { get; set; }
        IConnectionInspector ConnectionInspector { get; }
    }
}
