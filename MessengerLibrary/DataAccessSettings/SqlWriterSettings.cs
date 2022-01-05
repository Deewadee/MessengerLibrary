using System;
using MessengerLibrary.Common;

namespace MessengerLibrary.DataAccessSettings
{
    public class SqlWriterSettings : IWriterSettings
    {
        private string _connection;
        private string _table;
        private string _column;

        public Priority Priority { get; set; }
        public string Connection
        {
            get
            {
                return string.IsNullOrEmpty(_connection) ? "" : _connection;
            }
        }
        public string Table
        {
            get
            {
                return string.IsNullOrEmpty(_table) ? "" : _table;
            }
        }
        public string Column
        {
            get
            {
                return string.IsNullOrEmpty(_column) ? "" : _column;
            }
        }

        public SqlWriterSettings()
        {
            _connection = "";
            _table = "";
            _column = "";

            Priority = Priority.No;
        }

        public SqlWriterSettings(string connection, string table, string column)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            if (table == null) throw new ArgumentNullException(nameof(table));
            if (column == null) throw new ArgumentNullException(nameof(column));

            _connection = connection;
            _table = table;
            _column = column;

            Priority = Priority.No;
        }
    }
}
