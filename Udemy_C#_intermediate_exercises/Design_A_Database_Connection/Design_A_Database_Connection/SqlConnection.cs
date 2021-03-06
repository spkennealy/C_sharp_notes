﻿using System;

namespace Design_A_Database_Connection
{
    public class SqlConnection : DbConnection
    {
        public SqlConnection(string connectionString)
            : base(connectionString)
        {

        }

        public override void OpenConnection()
        {
            Console.WriteLine("Opening the SQL connection.");
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Closing the SQL connection.");
        }
    }
}
