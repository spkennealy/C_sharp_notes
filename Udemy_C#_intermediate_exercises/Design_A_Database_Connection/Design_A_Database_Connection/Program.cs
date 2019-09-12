using System;

namespace Design_A_Database_Connection
{
    class Program
    {
        public static void Main(string[] args)
        {
            var sqlConnection = new SqlConnection("alk2lf");
            //sqlConnection.OpenConnection();
            //sqlConnection.CloseConnection();
            var sqlInstructions = "SQL instructions are here!";
            var dbCommandSQL = new DbCommand(sqlConnection, sqlInstructions);
            dbCommandSQL.Execute();

            var oracleConnection = new OracleConnection("jkwuek");
            //oracleConnection.OpenConnection();
            //oracleConnection.CloseConnection();
            var oracleInstructions = "Oracle instructions are here!";
            var dbCommandOracle = new DbCommand(oracleConnection, oracleInstructions);
            dbCommandOracle.Execute();
        }
    }
}
