using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFormulario5
{
    public static class CustomDependecyService
    {
        private static Dictionary<Type, object> instances =new Dictionary<Type, object>();
        public static void register(Type type)
        {
            var instance = Activator.CreateInstance(type);
            var implementationType = type.GetInterfaces().FirstOrDefault();
            if (instances.ContainsKey(type))
            {
                instances[implementationType] = instance;
            }
            else
            {
                instances.Add(implementationType,instance);
            }
        }
        
        public static void register<T>()
        {
            register(typeof(T));
        }
        public static T get<T>()
        {
            return (T)get(typeof(T));
        }
        public static object get(Type type)
        {
            var implementation=type.GetInterfaces().FirstOrDefault();
            if (instances.ContainsKey(implementation))
            {
                return instances[implementation];
            }
            else
            {
                return null;
            }
		}
    }
}
