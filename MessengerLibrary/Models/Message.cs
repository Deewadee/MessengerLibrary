using System;
using MessengerLibrary.Common;

namespace MessengerLibrary.Models
{
    internal class Message
    {
        private readonly DateTime _dateTime;

        internal Priority Priority { get; }
        internal string Text { get; set; }
        internal object MessageObject { get; }

        internal string Date
        {
            get
            {
                return _dateTime.ToString("yyyy-MM-dd");
            }
        }
        internal string Time
        {
            get
            {
                return _dateTime.ToString("T");
            }
        }

        public Message(Priority priority, string text = "", object messageObject = null)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            MessageObject = messageObject;
            Text = text;
            Priority = priority;
            _dateTime = DateTime.Now;
        }
    }       
}
