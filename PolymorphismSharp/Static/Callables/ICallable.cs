using System;
using System.Collections.Generic;
using System.Text;
using PolymorphismSharp.Static.Methods;

namespace PolymorphismSharp.Static.Callables
{
    public interface ICallable
    {
        void Call(params object[] args);
    }
    public interface ICallable<TResult>
    {
        TResult Call(params object[] args);
    }
}
