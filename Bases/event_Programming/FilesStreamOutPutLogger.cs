using System;
using System.IO;
using System.Text;

namespace Event_Programming
{
    internal class FilesStreamOutPutLogger
    {
        public void Subscribe(Program program)
        {
            program.OnSendLog += OnLogSent;
        }
        public void OnLogSent(object sender, SendLogEventArgs args)
        {
            HandlerLogSend(args.Message, args.DateTime);
        }
        public void HandlerLogSend(String message, DateTime? dateTime = null)
        {
            if (dateTime == null)
            {
                dateTime = DateTime.Now;
            }
            String formattedMessage = String.Format("{0} - {1}", dateTime, message);
            string path = @"C:\Users\%Userprofile%\Desktop\fichier.txt";
            using (FileStream filesStream = File.Create(path))
            {
                AddText(filesStream, formattedMessage);
            }
        }

        private void AddText(FileStream fileStream, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fileStream.Write(info, 0, info.Length);
        }
    }
}