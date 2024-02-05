using Microsoft.Data.SqlClient;

namespace AccessToDatabase_ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-Q2BKQOF\\SQLEXPRESS";
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;
            builder.InitialCatalog = "Test";
            var conStr = builder.ToString();

            using SqlConnection connection = new SqlConnection(conStr);
            connection.Open();

            using var cmd = connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM [User]";
            var reader = cmd.ExecuteReader();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"{reader.GetName(i)}\t");
            }
            Console.WriteLine();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var value = reader.GetValue(i);
                    Console.Write(value.ToString() + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
