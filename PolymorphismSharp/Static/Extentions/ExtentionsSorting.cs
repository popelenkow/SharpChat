using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolymorphismSharp.Static.Extentions
{
    public static class ExtentionsSorting
    {
        private class ComparerGeneralizedMethods : IComparer<Type>
        {
            public List<List<Type>> Priority { get; set; }
            public ComparerGeneralizedMethods(List<List<Type>> priority)
            {
                Priority = priority;
            }
            public int Compare(Type x, Type y)
            {
                int i = 0;
                int comp = 0;
                foreach (var p in Priority)
                {
                    var tx = x.GenericTypeArguments[i];
                    var ty = y.GenericTypeArguments[i];
                    var ix = p.IndexOf(tx);
                    var iy = p.IndexOf(ty);
                    if (ix < iy)
                    {
                        comp = 1;
                        break;
                    }
                    if (ix > iy)
                    {
                        comp = -1;
                        break;
                    }
                    i++;
                }
                return comp;
            }
        }
        public static IEnumerable<Type> SortGeneralizedMethods
            (this IEnumerable<Type> source, List<List<Type>> priority)
        {
            var comparer = new ComparerGeneralizedMethods(priority);
            return source.OrderBy(x => x, comparer);
        }
        public static IEnumerable<TSource> SortGeneralizedMethods<TSource>
            (this IEnumerable<TSource> source, List<List<Type>> priority, Func<TSource, Type> keySelector)
        {
            source = source.ToList();
            var comparer = new ComparerGeneralizedMethods(priority);
            return source.OrderBy(keySelector, comparer).ToList();
        }
    }
}
