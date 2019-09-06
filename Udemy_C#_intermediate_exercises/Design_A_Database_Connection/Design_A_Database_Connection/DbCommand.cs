using System;

namespace Design_A_Database_Connection
{
    public class DbCommand
    {
        private DbConnection DbConnection;

        public DbCommand(DbConnection dbConnection)
        {
            if (dbConnection is null)
                throw new InvalidOperationException();

            DbConnection = dbConnection;
        }
    }
}
