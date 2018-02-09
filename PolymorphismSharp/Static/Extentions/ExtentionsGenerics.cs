using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolymorphismSharp.Static.Extentions
{
    public static class ExtentionsGenerics
    {
        public static List<List<Type>>
            GetGenericsPriority(this Type typeMethod, IEnumerable<Type> arguments)
        {
            List<List<Type>> result = new List<List<Type>>();
            var baseTypes = typeMethod.GenericTypeArguments;
            int i = 0;
            foreach (var t in arguments)
            {
                var r = t.GetClassesAndInterfaces(baseTypes[i]).ToList();
                result.Add(r);
                i++;
            }
            return result;
        }
    }
}
