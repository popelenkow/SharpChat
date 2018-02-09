using System;
using System.Collections.Generic;
using System.Text;
using PolymorphismSharp.Static.Callables;

namespace PolymorphismSharp.Static.Methods
{
    public interface IPolymorphicMethod : IGeneralizedMethod
    {
        IPolymorphicCall PolymorphicCall { get; set; }
        void CallNextMethod();
        void CallNextMethod(params object[] args);
    }
    public interface IPolymorphicMethod<TResult> : IGeneralizedMethod
    {
        IPolymorphicCall<TResult> PolymorphicCall { get; set; }
        TResult CallNextMethod();
        TResult CallNextMethod(params object[] args);
    }
}
