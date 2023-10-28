using System.Data.SqlClient;
namespace SchoolSystem;

class Program
{
    private const string dbConn = "Server=.\\MSSQLSERVER05;Database=SchoolManagement;Trusted_Connection=True;";
    private static void Main(string[] args)
    {
        string sql = "SELECT * FROM Institution";

        SqlConnection connection = new SqlConnection(dbConn);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;

        cmd.CommandText = sql;

        connection.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            Console.WriteLine("====================Example=======================");

            Console.WriteLine($"Id: { reader.GetInt32(0) }");
            Console.WriteLine($"Name: { reader.GetString(1) }");
            Console.WriteLine($"Email: { reader.GetString(2) }");
            Console.WriteLine($"State: { reader.GetString(3) }");
            Console.WriteLine($"Country: { reader.GetString(4) }");

            Console.WriteLine("====================End=======================");
        }

        connection.Close();
    }
}
   