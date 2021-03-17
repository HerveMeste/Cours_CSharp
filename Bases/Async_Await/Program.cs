using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace async_await
{
    class Program
    {
        static async Task<Int32> Main(string[] args)
        {
            var taskOne = NewMethod();
            var taskTwo = NewMethod();

            await Task.WhenAll(taskOne, taskTwo);
            Console.WriteLine("Finished");
            return 0;
        }

        private static async Task NewMethod()
        {
            Random rng = new Random();
            Int32 waitTime = rng.Next(1000, 5000);
            await Task.Delay(waitTime);
            Console.WriteLine("The task has waited " + waitTime);
        }
    }
}
