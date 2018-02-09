using System;
using System.Collections.Generic;
using System.Text;
using PolymorphismSharp.Static.Methods;

namespace PolymorphismSharp.Static.Callables
{
    class MultiCall : ICallable
    {
        public (Type Interface, Type Implementation) Pair { get; set; }
        public MultiCall((Type Interface, Type Implementation) pair)
        {
            Pair = pair;
        }
        public void Call(params object[] args)
        {
            if (Pair.Interface != null)
            {
                var instance = Activator.CreateInstance(Pair.Implementation) as IMultiMethod;
                Pair.Interface.GetMethod("Call").Invoke(instance, args);
            }

        }
    }
    class MultiCall<TResult> : ICallable<TResult>
    {
        public (Type Interface, Type Implementation) Pair { get; set; }
        public MultiCall((Type Interface, Type Implementation) pair)
        {
            Pair = pair;
        }
        public TResult Call(params object[] args)
        {
            if (Pair.Interface != null)
            {
                var instance = Activator.CreateInstance(Pair.Implementation) as IMultiMethod<TResult>;
                return (TResult)Pair.Interface.GetMethod("Call").Invoke(instance, args);
            }
            return default(TResult);
        }
    }
}
