using System;

namespace Design_A_Database_Connection
{
    class Program
    {
        public static void Main(string[] args)
        {
            var sqlConnection = new SqlConnection("alk2lf");
            sqlConnection.OpenConnection();
            sqlConnection.CloseConnection();

            var oracleConnection = new OracleConnection("jkwuek");
            oracleConnection.OpenConnection();
            oracleConnection.CloseConnection();
        }
    }
}
