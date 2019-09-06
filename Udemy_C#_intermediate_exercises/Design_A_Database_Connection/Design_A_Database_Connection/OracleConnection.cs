using System;

namespace Design_A_Database_Connection
{
    public class OracleConnection : DbConnection
    {
        public OracleConnection(string connectionString)
            : base(connectionString)
        {

        }

        public override void OpenConnection()
        {
            Console.WriteLine("Opening the Oracle connection.");
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Closing the Oracle connection.");
        }
    }
}
