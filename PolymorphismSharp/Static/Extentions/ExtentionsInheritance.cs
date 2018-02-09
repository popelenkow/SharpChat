using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolymorphismSharp.Static.Extentions
{
    public static class ExtentionsInheritance
    {
        public static IEnumerable<Type> GetInheritedMethods(this Type typeImplementation, Type typeBase)
        {
            var types = typeImplementation.GetBaseClassesAndInterfaces();
            return types.Where(x => x.IsDerivedMethod(typeBase));
        }
        public static bool IsInheritedMethod(this Type typeImplementation, Type typeBase)
        {
            var types = typeImplementation.GetBaseClassesAndInterfaces();
            return types.Any(x => x.IsDerivedMethod(typeBase));
        }

        public static bool IsDerivedMethod(this Type typeMethod, Type typeBase)
        {
            return typeMethod.EqualsName(typeBase)
                && typeMethod.EqualsNamespace(typeBase)
                && typeMethod.IsInheritedGenerics(typeBase);
        }

        public static bool IsInheritedGenerics(this Type typeDerived, Type typeBase)
        {
            var g = typeDerived.GetGenericArguments();
            var gBase = typeBase.GetGenericArguments();
            return g.IsInheritedGenerics(gBase);
        }
        public static bool IsInheritedGenerics(this Type typeDerived, IEnumerable<Type> genericsBase)
        {
            var g = typeDerived.GetGenericArguments();
            var gBase = genericsBase;
            return g.IsInheritedGenerics(gBase);
        }
        public static bool IsInheritedGenerics(this IEnumerable<Type> genericsDerived, Type typeBase)
        {
            var g = genericsDerived;
            var gBase = typeBase.GetGenericArguments();
            return g.IsInheritedGenerics(gBase);
        }
        public static bool IsInheritedGenerics(this IEnumerable<Type> genericsDerived, IEnumerable<Type> genericsBase)
        {
            var g = genericsDerived.ToList();
            var gBase = genericsBase.ToList();

            if (g.Count != gBase.Count) return false;


            for (int i = 0; i < g.Count; i++)
            {
                if (!gBase[i].IsAssignableFrom(g[i])) return false;
                i++;
            }
            return true;
        }

    }
}

