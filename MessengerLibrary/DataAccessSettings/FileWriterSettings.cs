using MessengerLibrary.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerLibrary.DataAccessSettings
{
    public class FileWriterSettings : IWriterSettings
    {
        private string _pathToFile;
        private string _fileName;

        public Priority Priority { get; set; }
        public string PathToFile
        { 
            get
            {
                return _pathToFile;
            }
        }
        public string FileName
        {
            get
            {
                return _fileName;
            }
        }

        public FileWriterSettings()
        {
            _pathToFile = Directory.GetCurrentDirectory();
            _fileName = "Messages.txt";

            Priority = Priority.No;
        }

        public FileWriterSettings(string path)
        {
            _pathToFile = path;
            _fileName = "Messages.txt";

            Priority = Priority.No;
        }

        public FileWriterSettings(string path, string fileName)
        {
            _pathToFile = path;
            _fileName = fileName;

            Priority = Priority.No;
        }

        public void SetPath(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            _pathToFile = path;
        }

        public void SetFileName(string fileName)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));

            _fileName = fileName;
        }
    }
}
