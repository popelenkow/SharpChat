using System;
using System.Collections.Generic;
using System.Text;
using PolymorphismSharp.Static.Extentions;
using System.Linq;
using PolymorphismSharp.Static.Methods;
using PolymorphismSharp.Static.Callables;

namespace PolymorphismSharp.Static.Dispatchers
{
    public class DispatcherPolymorphicMethod<TMethod> : DispatcherGeneralizedMethodBase<TMethod>
        where TMethod : class, IPolymorphicMethod
    {
        public override ICallable GetMethod(params object[] argGenerics)
        {
            return new PolymorphicCall
            {
                Pairs = GetMethods(argGenerics).ToList()
            };
        }
    }
    public class DispatcherPolymorphicMethod<TMethod, TResult> : DispatcherGeneralizedMethodBase<TMethod, TResult>
        where TMethod : class, IPolymorphicMethod<TResult>
    {
        public override ICallable<TResult> GetMethod(params object[] argGenerics)
        {
            return new PolymorphicCall<TResult>
            {
                Pairs = GetMethods(argGenerics).ToList()
            };
        }
    }
}
