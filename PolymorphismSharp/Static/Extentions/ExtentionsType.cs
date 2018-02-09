using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolymorphismSharp.Static.Extentions
{
    public static class ExtentionsType
    {
        public static bool EqualsName(this Type type1, Type type2)
        {
            return type1.Name == type2.Name;
        }
        public static bool EqualsNamespace(this Type type1, Type type2)
        {
            return type1.Namespace == type2.Namespace;
        }
        private static List<Type> _GetClassesAndInterfaces(Type type, Type typeBase = null)
        {
            if (type.BaseType == null) return type.GetInterfaces().ToList();

            List<Type> arrClasses = new List<Type>();
            Type typeCur = type;
            while (true)
            {
                arrClasses.Insert(0, typeCur);
                if (typeCur.BaseType == null) break;
                typeCur = typeCur.BaseType;
            }

            List<Type> arrResults = new List<Type>();
            foreach (var t in arrClasses)
            {
                var arrInterfaces = t.GetInterfaces().Where(x => !arrResults.Contains(x)).ToList();
                var arrBuf = new List<Type>();

                foreach (var ti in arrInterfaces)
                {
                    while (arrBuf.Count > 0)
                    {
                        var last = arrBuf.Last();
                        if (!ti.IsAssignableFrom(last))
                        {
                            arrBuf.RemoveAt(arrBuf.Count - 1);
                            arrResults.Add(last);
                        }
                        else
                        {
                            break;
                        }
                    }
                    arrBuf.Add(ti);
                }
                arrBuf.Reverse();
                foreach (var buf in arrBuf)
                {
                    arrResults.Add(buf);
                }
                arrResults.Add(t);
            }
            if (typeBase != null)
            {
                return arrResults.Where(x => typeBase.IsAssignableFrom(x)).ToList();
            }
            return arrResults.ToList();
        }
        public static Type[] GetClassesAndInterfaces(this Type type, Type typeBase = null)
        {
            return _GetClassesAndInterfaces(type, typeBase).ToArray();
        }
        
        public static Type[] GetBaseClassesAndInterfaces(this Type type, Type typeBase = null)
        {
            var r = _GetClassesAndInterfaces(type, typeBase);

            r.Remove(type);
            return r.ToArray();
        }
        
    }
}
