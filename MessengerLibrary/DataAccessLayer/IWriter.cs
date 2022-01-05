using System;
using MessengerLibrary.DataAccessSettings;

namespace MessengerLibrary.DataAccessLayer
{
    internal interface IWriter
    {
        public IWriterSettings Settings { get; set; }

        void Write(string message);
    }
}
