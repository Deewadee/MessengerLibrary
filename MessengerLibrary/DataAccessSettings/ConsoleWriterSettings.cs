using MessengerLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.DataAccessSettings
{
    public class ConsoleWriterSettings : IWriterSettings
    {
        public Priority Priority { get; set; }

        public ConsoleWriterSettings()
        {
            Priority = Priority.Low;
        }
    }
}
