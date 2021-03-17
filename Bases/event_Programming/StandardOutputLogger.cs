using System;

namespace Event_Programming

{
    class StandardOutputLogger
    {
        public void Subscribe(Program program)
        {
            program.OnSendLog += OnLogSent;
        }
        public void OnLogSent(object sender, SendLogEventArgs args)
        {
            Write(args.Message, args.DateTime);
        }
        public void Write(String message, DateTime? dateTime = null)
        {
            if (dateTime == null)
            {
                dateTime = DateTime.Now;
            }
            String formattedMessage = String.Format("{0} - {1}", dateTime, message);
            Console.WriteLine(formattedMessage);
        }
    }
}
