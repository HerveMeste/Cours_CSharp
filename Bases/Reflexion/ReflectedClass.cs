using System;

namespace ReflectionTest
{
    class ReflectedClass
    {
        private Int32 _id;
        private String Name { get; set; }

        public ReflectedClass()
        {
            _id = 0;
            Name = String.Empty;
        }

        private void DoSomething()
        {
            Console.WriteLine("I am doing something ...");
        }
    }

}
