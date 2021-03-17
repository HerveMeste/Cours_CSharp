using Reflexion;
using System;
using System.Reflection;

namespace ReflectionTest
{

    class Program
    {
        static void Main(string[] args)
        {
            var reflected = new ReflectedClass();
            Type objectType = reflected.GetType();
            var inspector = new Inspector(objectType);
            inspector.GetAllProperties();
            inspector.GetAllFields();
            inspector.GetAllMethods();
            inspector.GetAllConstructors();
        }
    }
}
