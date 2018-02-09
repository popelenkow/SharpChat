using PolymorphismSharp.Static.Callables;
using PolymorphismSharp.Static.Methods;
using System;
using System.Linq;

using System.Collections.Generic;
using System.Text;

namespace PolymorphismSharp.Static.Dispatchers
{
    public class DispatcherMultiMethod<TMethod> : DispatcherGeneralizedMethodBase<TMethod>
        where TMethod : class, IMultiMethod
    {
        public override ICallable GetMethod(params object[] argGenerics)
        {
            var ms = GetMethods(argGenerics);
            var m = (ms.Count() == 0) ? (null, null) : ms.First();
            return new MultiCall(m);
        }
    }
    public class DispatcherMultiMethod<TMethod, TResult> : DispatcherGeneralizedMethodBase<TMethod, TResult>
        where TMethod : class, IMultiMethod<TResult>
    {
        public override ICallable<TResult> GetMethod(params object[] argGenerics)
        {
            var ms = GetMethods(argGenerics);
            var m = (ms.Count() == 0) ? (null, null) : ms.First();
            return new MultiCall<TResult>(m);
        }
    }
}
