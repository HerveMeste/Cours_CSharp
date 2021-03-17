using ReflectionTest;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Reflexion
{
    internal class Inspector
    {
        private Type _objectType;
        public Inspector(Type objectType)
        {
            _objectType = objectType;
        }
        internal void GetAllProperties()
        {
            
            PropertyInfo[] properties = _objectType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("Properties");
            foreach (var p in properties)
            {
                Console.WriteLine("\t" + p);
            }
        }

        internal void GetAllFields()
        {
            
            FieldInfo[] fields = _objectType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("Fields");
            foreach (var f in fields)
            {
                Console.WriteLine("\t" + f);
            }
        }

        internal void GetAllConstructors()
        {
            
            ConstructorInfo[] constructors = _objectType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("Constructors");
            foreach (var c in constructors)
            {
                Console.WriteLine("\t" + c);
            }
        }

        internal void GetAllMethods()
        {
            
            MethodInfo[] methods = _objectType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("Methods");
            foreach (var m in methods)
            {
                Console.WriteLine("\t" + m);
            }
        }
    }
}
