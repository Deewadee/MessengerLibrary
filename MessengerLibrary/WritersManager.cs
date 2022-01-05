using System;
using System.Linq;
using MessengerLibrary.DataAccessLayer;
using MessengerLibrary.DataAccessSettings;
using MessengerLibrary.Models;
using System.Collections.Generic;
using MessengerLibrary.Common;

namespace MessengerLibrary
{
    internal class WritersManager
    {
        private List<IWriter> _writers = new List<IWriter>();

        public WritersManager()
        {
            _writers.Add(new SqlServerWriter());
            _writers.Add(new FileWriter());
            _writers.Add(new ConsoleWriter());
        }

        public void AddSettings(IWriterSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            foreach (IWriter writer in _writers)
            {
                if (writer.Settings.GetType() == settings.GetType())
                {
                    writer.Settings = settings;
                }
            }
        }

        public void Write(Message message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            try
            {
                List<IWriter> writers = _writers.Where(writer => writer.Settings.Priority == message.Priority && message.Priority != Priority.No).ToList();

                writers.ForEach(writer => writer.Write(message.Text));
            }
            catch
            {
                throw;
            }
        }

    }
}
