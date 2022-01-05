using System;
using MessengerLibrary.DataAccessSettings;
using System.Data.SqlClient;

namespace MessengerLibrary.DataAccessLayer
{
    internal class SqlServerWriter : IWriter
    {
        private SqlWriterSettings _settings;

        public IWriterSettings Settings
        {
            get
            {
                return _settings;
            }
            set
            {
                _settings = (SqlWriterSettings)value;
            }
        }

        public SqlServerWriter()
        {
            _settings = new SqlWriterSettings();
        }

        public SqlServerWriter(SqlWriterSettings settings)
        {
            if (settings == null)
            {
                _settings = new SqlWriterSettings();

                return;
            }

            _settings = settings;
        }

        public async void Write(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            string sqlExpression = $"INSERT INTO {_settings.Table} ({_settings.Column}) VALUES ('{message}')";

            try
            { 
                using(SqlConnection connection = new SqlConnection(_settings.Connection))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    await command.ExecuteNonQueryAsync();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
