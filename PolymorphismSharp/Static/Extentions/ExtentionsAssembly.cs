using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PolymorphismSharp.Static.Extentions
{
    public static class ExtentionsAssembly
    {
        public static Type[] GetGeneralizedMethods(this AppDomain appDomain, Type typeBase, string nameNamespace = null)
        {
            List<Type> typeImplementations = new List<Type>();
            Assembly[] assemblies = appDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var targetMethods = assembly.GetGeneralizedMethods(typeBase, nameNamespace);

                foreach (var type in targetMethods)
                {
                    typeImplementations.Add(type);
                }
            }
            return typeImplementations.ToArray();
        }
        public static Type[] GetGeneralizedMethods(this Assembly assembly, Type typeBase, string nameNamespace = null)
        {
            List<Type> typeImplementations = new List<Type>();

            var types = assembly.GetTypes();
            var targetNamespace = types.Where(x => (nameNamespace == null) || x.Namespace.Equals(nameNamespace));
            var targetImplementations = targetNamespace.Where(x => x.IsClass && !x.IsAbstract).ToList();


            var targetMethods = targetImplementations.FilterInheritedMethods(typeBase);

            foreach (var type in targetMethods)
            {
                typeImplementations.Add(type);
            }

            return typeImplementations.ToArray();
        }
    }
}
