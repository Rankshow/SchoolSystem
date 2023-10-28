using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using Explicit.Model;
namespace Explicit;

class Program
{
    private const string connectionString = "Server=.\\MSSQLSERVER05;Database=SchoolManagement;Trusted_Connection=True;";
    private static void Main(string[] args)
    {
        SqlConnection sqlCon = new SqlConnection(connectionString);

        string insertCommand = "INSERT INTO Institution(Name, Email, State, Country) VALUES (@Name,@Email,@State,@Country)";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlCon;
        cmd.CommandText = insertCommand;

        
        Console.WriteLine("Please provide Name of Institution.");
        SqlParameter parameterName = new SqlParameter();
        parameterName.ParameterName = "@Name";
        parameterName.SqlDbType = System.Data.SqlDbType.VarChar;
        parameterName.Direction = System.Data.ParameterDirection.Input;
        parameterName.SqlValue = Console.ReadLine();
        cmd.Parameters.Add(parameterName);

        Console.WriteLine("Please provide Email of Institution.");
        SqlParameter parameterEmail = new SqlParameter();
        parameterEmail.ParameterName = "@Email";
        parameterEmail.SqlDbType = System.Data.SqlDbType.VarChar;
        parameterEmail.Direction = System.Data.ParameterDirection.Input;
        parameterEmail.SqlValue = Console.ReadLine();
        cmd.Parameters.Add(parameterEmail);

        Console.WriteLine("Please provide State of Institution.");
        SqlParameter parameterState = new SqlParameter();
        parameterState.ParameterName = "@State";
        parameterState.SqlDbType = System.Data.SqlDbType.VarChar;
        parameterState.Direction = System.Data.ParameterDirection.Input;
        parameterState.SqlValue = Console.ReadLine();
        cmd.Parameters.Add(parameterState);

        Console.WriteLine("Please provide Country of Institution.");
        SqlParameter parameterCountry = new SqlParameter();
        parameterCountry.ParameterName = "@Country";
        parameterCountry.SqlDbType = System.Data.SqlDbType.VarChar;
        parameterCountry.Direction = System.Data.ParameterDirection.Input;
        parameterCountry.SqlValue = Console.ReadLine();
        cmd.Parameters.Add(parameterCountry);

        sqlCon.Open();
        int result = cmd.ExecuteNonQuery();
        sqlCon.Close();
    }

}