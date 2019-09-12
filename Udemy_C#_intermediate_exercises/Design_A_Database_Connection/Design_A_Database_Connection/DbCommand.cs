using System;

namespace Design_A_Database_Connection
{
    public class DbCommand
    {
        private readonly DbConnection _dbConnection;
        private readonly string _instructions;

        public DbCommand(DbConnection dbConnection, string instructions)
        {
            if (dbConnection is null)
                throw new ArgumentException("There must be a DbConnection to run a command");
            if (String.IsNullOrWhiteSpace(instructions))
                throw new ArgumentException("There must be instructions provided with the DbConnection");

            _dbConnection = dbConnection;
            _instructions = instructions;
        }
    }
}
