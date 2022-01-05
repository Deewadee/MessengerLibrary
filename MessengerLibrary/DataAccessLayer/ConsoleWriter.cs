using System;
using MessengerLibrary.DataAccessSettings;

namespace MessengerLibrary.DataAccessLayer
{
    internal class ConsoleWriter : IWriter
    {
        private static ConsoleWriterSettings _settings;

        public IWriterSettings Settings
        {
            get
            {
                return _settings;
            }
            set
            {
                _settings = (ConsoleWriterSettings)value;
            }
        }

        public ConsoleWriter()
        {
            _settings = new ConsoleWriterSettings();
        }

        public ConsoleWriter(ConsoleWriterSettings settings)
        {
            if (settings == null)
            {
                _settings = new ConsoleWriterSettings();
                
                return;
            }

            _settings = settings;
        }

        public void Write(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            Console.WriteLine(message);
        }
    }
}
