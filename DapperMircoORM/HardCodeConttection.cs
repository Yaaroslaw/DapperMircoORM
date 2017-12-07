using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;

namespace DapperMircoORM
{
    public class HardCodeConttection
    {
        public EntityConnection Create()
        {
            // Specify the provider name, server and database.
            string providerName = "System.Data.SqlClient";
            string serverName = ".";
            string databaseName = "AdventureWorks";

            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();
            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.IntegratedSecurity = true;


            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();
            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/AdventureWorksModel.csdl|
                            res://*/AdventureWorksModel.ssdl|
                            res://*/AdventureWorksModel.msl";

            EntityConnection conection = new EntityConnection(entityBuilder.ToString());
            return conection;
        }
    }

    public class HardCodeConttection2
    {
        public IDbConnection Create()
        {
            IDbConnection connection;

            // First use a SqlClient connection
            connection = new SqlConnection(@"Server=(localdb)\V11.0");
            //Console.WriteLine("SqlClient\r\n{0}", GetServerVersion(connection));
            connection = new SqlConnection(@"Server=(local);Integrated Security=true");
           // Console.WriteLine("SqlClient\r\n{0}", GetServerVersion(connection));

            // Call the same method using ODBC
            // NOTE: LocalDB requires the SQL Server 2012 Native Client ODBC driver
            connection = new System.Data.Odbc.OdbcConnection(@"Driver={SQL Server Native Client 11.0};Server=(localdb)\v11.0");
            //Console.WriteLine("ODBC\r\n{0}", GetServerVersion(connection));
            connection = new System.Data.Odbc.OdbcConnection(@"Driver={SQL Server Native Client 11.0};Server=(local);Trusted_Connection=yes");
            //Console.WriteLine("ODBC\r\n{0}", GetServerVersion(connection));

            // Call the same method using OLE DB
            connection = new System.Data.OleDb.OleDbConnection(@"Provider=SQLNCLI11;Server=(localdb)\v11.0;Trusted_Connection=yes;");
            //Console.WriteLine("OLE DB\r\n{0}", GetServerVersion(connection));
            connection = new System.Data.OleDb.OleDbConnection(@"Provider=SQLNCLI11;Server=(local);Trusted_Connection=yes;");
            // Console.WriteLine("OLE DB\r\n{0}", GetServerVersion(connection));
            return connection;
        }

        public static string GetServerVersion(IDbConnection connection)
        {
            // Ensure that the connection is opened (otherwise executing the command will fail)
            ConnectionState originalState = connection.State;
            if (originalState != ConnectionState.Open)
                connection.Open();
            try
            {
                // Create a command to get the server version
                // NOTE: The query's syntax is SQL Server specific
                IDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT @@version";
                return (string)command.ExecuteScalar();
            }
            finally
            {
                // Close the connection if that's how we got it
                if (originalState == ConnectionState.Closed)
                    connection.Close();
            }
        }
    }
}

