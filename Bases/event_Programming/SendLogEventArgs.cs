using System;

namespace Event_Programming

{
    /// <summary>
    /// Arguments of a log
    /// </summary>
    /// <remarks>
    /// This class carries out a log message and the date when the message was sent
    /// </remarks>
    class SendLogEventArgs : EventArgs
    {
        public String Message;
        public DateTime DateTime;

        public SendLogEventArgs(String message, DateTime dateTime)
        {
            Message = message;
            DateTime = dateTime;
        }
    }
}
