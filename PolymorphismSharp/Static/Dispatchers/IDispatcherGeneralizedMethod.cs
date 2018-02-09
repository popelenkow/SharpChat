using System;
using System.Collections.Generic;
using System.Text;
using PolymorphismSharp.Static.Extentions;
using System.Linq;
using PolymorphismSharp.Static.Methods;
using PolymorphismSharp.Static.Callables;


namespace PolymorphismSharp.Static.Dispatchers
{
    public interface IDispatcherGeneralizedMethod<TMethod>
        where TMethod : IGeneralizedMethod
    {
        ICallable GetMethod(params object[] argGenerics);
    }
    public interface IDispatcherGeneralizedMethod<TMethod, TResult> 
        where TMethod : IGeneralizedMethod
    {
        ICallable<TResult> GetMethod(params object[] argGenerics);
    }
}
