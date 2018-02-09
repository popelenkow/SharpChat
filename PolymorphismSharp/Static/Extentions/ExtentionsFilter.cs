using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolymorphismSharp.Static.Extentions
{
    public static class ExtentionsFilter
    {
        public static IEnumerable<Type> FilterInheritedMethods
           (this IEnumerable<Type> source, Type typeBase)
        {
            return source.Where(x => x.IsInheritedMethod(typeBase));
        }
        public static IEnumerable<Type> FilterDerivedMethods
           (this IEnumerable<Type> source, Type typeBase)
        {
            return source.Where(x => x.IsDerivedMethod(typeBase));
        }
        public static IEnumerable<Type> FilterImplementedMethods
            (this IEnumerable<Type> source, IEnumerable<Type> typeArgs)
        {
            return source.Where(x => typeArgs.IsInheritedGenerics(x));
        }

        public static IEnumerable<TSource> FilterInheritedMethods<TSource>
           (this IEnumerable<TSource> source, Type typeBase, Func<TSource, Type> keySelector)
        {
            return source.Where(x => keySelector(x).IsInheritedMethod(typeBase));
        }
        public static IEnumerable<TSource> FilterDerivedMethods<TSource>
            (this IEnumerable<TSource> source, Type typeBase, Func<TSource, Type> keySelector)
        {
            return source.Where(x => keySelector(x).IsDerivedMethod(typeBase));
        }
        public static IEnumerable<TSource> FilterImplementedMethods<TSource>
            (this IEnumerable<TSource> source, IEnumerable<Type> typeArgs, Func<TSource, Type> keySelector)
        {
            return source.Where(x => typeArgs.IsInheritedGenerics(keySelector(x)));
        }
    }
}
