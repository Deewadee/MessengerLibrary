using MessengerLibrary.DataAccessSettings;
using System;
using System.IO;
using System.Text;

namespace MessengerLibrary.DataAccessLayer
{
    internal class FileWriter : IWriter
    {
        private FileWriterSettings _settings;

        public IWriterSettings Settings
        {
            get
            {
                return _settings;
            }
            set
            {
                _settings = (FileWriterSettings)value;
            }
        }

        public FileWriter()
        {
            _settings = new FileWriterSettings();
        }

        public FileWriter(FileWriterSettings settings)
        {
            if (settings == null)
            {
                _settings = new FileWriterSettings();

                return;
            }

            _settings = settings;
        }

        public async void Write(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            try
            {
                using (StreamWriter writer = new StreamWriter(_settings.PathToFile, true))
                {
                    await writer.WriteLineAsync(message);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
