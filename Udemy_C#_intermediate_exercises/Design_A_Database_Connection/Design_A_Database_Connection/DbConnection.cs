using System;

namespace Design_A_Database_Connection
{
    public abstract class DbConnection
    {
        private string ConnectionString;
        private TimeSpan Timeout;

        public DbConnection(string connectionString)
        {
            if (String.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException();

            ConnectionString = connectionString;
        }

        public abstract void OpenConnection();
        public abstract void CloseConnection();
    }
}
