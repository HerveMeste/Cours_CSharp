using System;

namespace Event_Programming

{
    /// <summary>
    /// Main program
    /// </summary>
    /// <remarks>
    /// This class is the <see cref="LogEvent"/> event publisher
    /// </remarks>
    class Program
    {
        public event EventHandler<SendLogEventArgs> OnSendLog;

        static void Main(string[] args)
        {
            var program = new Program();
            var logger = new StandardOutputLogger();
            var loggerInFiles = new FilesStreamOutPutLogger();
            // Subscribe the logger to OnSendLog event
            logger.Subscribe(program);
            var eventArgs = new SendLogEventArgs("LogEvent published", DateTime.Now);
            // Dispatch OnSendLog subscribed loggers
            if (program.OnSendLog != null)
            {
                program.OnSendLog(program, eventArgs);
            }
        }
    }
}
