/*using System;
using System.Threading;

namespace ThreadPoolQuest
{
    public class Program
    {
        private CountdownEvent _countdown;
        private Int32 _threadsCount;

        private static void Main()
        {
            var program = new Program(3);
            program.Run();
        }

        public Program(Int32 threadsCount)
        {
            _threadsCount = threadsCount;
            _countdown = new CountdownEvent(threadsCount); // Set the counter to the number of threads executing
        }

        public void Run()
        {
            for (int i = 0; i < _threadsCount; i++)
            {
                ThreadPool.QueueUserWorkItem(x =>
                {
                    Console.WriteLine("[INFO]: Thread n°{0} has started",
                                      Thread.CurrentThread.ManagedThreadId);

                    Thread.Sleep(500); // Simulate work

                    Console.WriteLine("[INFO]: Thread n°{0} has terminated",
                                      Thread.CurrentThread.ManagedThreadId);
                    _countdown.Signal(); // Decrement the counter of executing threads
                });
            }

            // If there the countdown countdown is greater than zero, there is still work to be done.
            while (_countdown.CurrentCount > 0)
            {
                Console.WriteLine("[INFO]: Waiting for threads to terminate ...");
                Thread.Sleep(100);
            }

            _countdown.Wait(); // Blocks current thread until the CountdownEvent counter is equal to 0

            Console.WriteLine("[SUCESS]: All threads terminated");
            Console.ReadLine();
        }
    }
}*/
