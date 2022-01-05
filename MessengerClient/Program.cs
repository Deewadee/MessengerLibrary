using System;
using MessengerLibrary;
using MessengerLibrary.Common;
using MessengerLibrary.DataAccessSettings;

namespace MessengerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWriterSettings settings = GetFileWriterSettings();

            Messenger messenger = new Messenger(settings);

            messenger.MessageFormat = "{0} {1} | Priority:{4} | {2} | {3}";

            string text = "Test";

            messenger.Send(Priority.Medium, text, new { propertyA = 5 });
        }

        private static FileWriterSettings GetFileWriterSettings()
        {
            FileWriterSettings settings = new FileWriterSettings(@"C:\Users\user\Documents\MyProjects\Messages.txt");

            settings.Priority = Priority.Medium;

            return settings;
        }

        private static SqlWriterSettings GetSqlWriterSettings()
        {
            SqlWriterSettings settings = new SqlWriterSettings("connection", "table", "column");

            return settings;
        }
    }
}
