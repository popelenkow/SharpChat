using System;
using System.Collections.Generic;
using System.Text;
using PolymorphismSharp.Static.Callables;

namespace PolymorphismSharp.Static.Methods
{
    public abstract class PolymorphicMethod : IPolymorphicMethod
    {
        public IPolymorphicCall PolymorphicCall { get; set; }

        public void CallNextMethod()
        {
            PolymorphicCall.CallNextMethod();
        }

        public void CallNextMethod(params object[] args)
        {
            PolymorphicCall.CallNextMethod(args);
        }

    }
    public abstract class PolymorphicMethod<TResult> : IPolymorphicMethod<TResult>
    {
        public IPolymorphicCall<TResult> PolymorphicCall { get; set; }

        public TResult CallNextMethod()
        {
            return PolymorphicCall.CallNextMethod();
        }

        public TResult CallNextMethod(params object[] args)
        {
            return PolymorphicCall.CallNextMethod(args);
        }
    }
}
