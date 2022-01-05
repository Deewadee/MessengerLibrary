using System;
using System.Text;
using MessengerLibrary.Models;

namespace MessengerLibrary
{
    internal class MessageFormatter
    {
        public static string GetFormattedMessageText(Message message, string messageFormat)
        {
            if (messageFormat == null) throw new ArgumentNullException(nameof(messageFormat));
            if (message == null) throw new ArgumentNullException(nameof(message));

            StringBuilder builder = new StringBuilder();

            builder.AppendFormat(messageFormat, message.Date, message.Time, message.Text, message.MessageObject, message.Priority.ToString().ToUpper());
            builder.Append("\n");

            return builder.ToString();
        }
    }
}
