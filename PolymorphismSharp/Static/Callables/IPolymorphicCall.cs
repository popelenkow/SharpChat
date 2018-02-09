using PolymorphismSharp.Static.Methods;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismSharp.Static.Callables
{
    public interface IPolymorphicCall : ICallable
    {
        void CallNextMethod();
        void CallNextMethod(params object[] args);
    }
    public interface IPolymorphicCall<TResult> : ICallable<TResult>
    {
        TResult CallNextMethod();
        TResult CallNextMethod(params object[] args);
    }
}
