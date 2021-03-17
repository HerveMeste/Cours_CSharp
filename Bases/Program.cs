using System;
using System.Collections.Generic;
using System.Threading;

class Example
{
    // Create a new Mutex. The creating thread does not own the mutex.
    private static Mutex mutex = new Mutex();
    private const int numThreads = 4;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choisis le nombre de chevaux");
            int cheveaux = Convert.ToInt32(Console.ReadLine());
            var newThreadStart = new ThreadStart(OnThreadStart);
            var threads = new List<Thread>();
            for(int i = 0; i < cheveaux; i++)
            {
                threads.Add(new Thread(newThreadStart));
                threads[i].Name = $"{i + 1}";
                threads[i].Start();
            }
            foreach(var thread in threads)
            {
                thread.Join();
            }
            while(Console.ReadKey().Key != ConsoleKey.Enter)
            {

            }
        }
    }
    private static void OnThreadStart()
    {
        var random = new System.Random();
        var executionTime = random.Next(1, 3);
        var timeSpan = TimeSpan.FromSeconds(executionTime);

        Thread.Sleep(timeSpan);// Simulate computing by waiting a random period of time
        UseResource();
    }
    private static void UseResource()
    {
        
        if(mutex.WaitOne(1000))
        {
            Console.WriteLine("{0} Win",
            Thread.CurrentThread.Name);
            Thread.Sleep(4000);
            mutex.ReleaseMutex();
        }
        else
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} Loose");
        }
    }
}

