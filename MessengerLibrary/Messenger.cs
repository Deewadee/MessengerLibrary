using System;
using MessengerLibrary.Common;
using MessengerLibrary.DataAccessSettings;
using MessengerLibrary.Models;

namespace MessengerLibrary
{
    public class Messenger
    {
        private const string DEFAULT_FORMAT = "{0} {1} | {2}";
        private readonly WritersManager _manager;
        private string _messageFormat;

        /// <summary>
        /// Enter text in a similar format: "{0} | {1}".
        /// Order of parameters: Date, Time, Text, MessageObject, Priority.
        /// Parameter indexing starts from 0
        /// </summary>
        public string MessageFormat
        {
            get
            {
                return _messageFormat;
            }
            set
            {
                _messageFormat = string.IsNullOrEmpty(value) ? DEFAULT_FORMAT : value;
            }
        }

        public Messenger(IWriterSettings settings)
        {
            _manager = new WritersManager();

            _manager.AddSettings(settings);

            _messageFormat = DEFAULT_FORMAT;
        }

        public void Send(string text, object messageObject = null)
        {
            if (text == null)
            {
                text = "";
            }

            try
            {
                Send(Priority.Low, text, messageObject);
            }
            catch
            {
                throw;
            }
        }

        public void Send(Priority priority, string text = null, object messageObject = null)
        {
            if (text == null)
            {
                text = "";
            }

            try
            {
                Send(priority, messageObject, text);
            }
            catch
            {
                throw;
            }
        }

        public void Send(Priority priority, object messageObject = null, string text = null)
        {
            if (text == null)
            {
                text = "";
            }

            try
            {
                Message message = new Message(priority, text, messageObject);

                message.Text = MessageFormatter.GetFormattedMessageText(message, _messageFormat);

                _manager.Write(message);
            }
            catch
            {
                throw;
            }
        }
    }
}
