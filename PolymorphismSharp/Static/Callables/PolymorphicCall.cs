using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PolymorphismSharp.Static.Methods;

namespace PolymorphismSharp.Static.Callables
{
    class PolymorphicCall : IPolymorphicCall
    {
        public List<(Type Interface, Type Implementation)> Pairs { get; set; }

        private int _it { get; set; }
        private object[] _args;

        public void Call(params object[] args)
        {
            _it = 0;
            CallNextMethod(args);
        }

        public void CallNextMethod()
        {
            CallNextMethod(_args);
        }

        public void CallNextMethod(params object[] args)
        {
            if (_it == Pairs.Count) return;
            var pair = Pairs[_it];
            _it++;
            var instance = Activator.CreateInstance(pair.Implementation) as IPolymorphicMethod;
            instance.PolymorphicCall = this;
            _args = args;
            pair.Interface.GetMethod("Call").Invoke(instance, args);
        }
    }

    class PolymorphicCall<TResult> : IPolymorphicCall<TResult>

    {
        public List<(Type Interface, Type Implementation)> Pairs { get; set; }

        private int _it { get; set; }
        private object[] _args;

        public TResult Call(params object[] args)
        {
            _it = 0;
            return CallNextMethod(args);
        }

        public TResult CallNextMethod()
        {
            return CallNextMethod(_args);
        }

        public TResult CallNextMethod(params object[] args)
        {
            if (_it == Pairs.Count) return default(TResult);
            var pair = Pairs[_it];
            _it++;
            var instance = Activator.CreateInstance(pair.Implementation) as IPolymorphicMethod<TResult>;
            instance.PolymorphicCall = this;
            _args = args;
            return (TResult)pair.Interface.GetMethod("Call").Invoke(instance, args);
        }
      
    }
}
