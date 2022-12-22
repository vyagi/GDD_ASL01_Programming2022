//ADO.NET - is not much popular these days
//you need lots of ceremony to do simple things
using System.Data;
using System.Data.SqlClient;

var connectionString = "Data Source=localhost,1433;Initial Catalog=AdventureWorks;User ID=sa;Password=password-1234";

var queryString = @"SELECT * FROM SalesLT.Product";

using (var connection = new SqlConnection(connectionString))
{
    connection.Open();
    using (var command = new SqlCommand(queryString, connection))
    {
        command.CommandType = CommandType.Text;
        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            Console.WriteLine(reader.GetString("Name"));
        }
    }
}