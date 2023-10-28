using System.Data.SqlClient;
// using System.Security.Cryptography.X509Certificates;
using Explicit.Model;
namespace Explicit;

class Program
{
    private const string dbConn = "Server=.\\MSSQLSERVER05;Database=SchoolManagement;Trusted_Connection=True;";
    private static void Main(string[] args)
    {
       List<Institution> institutions = GetInstitutions();
        ShowInstitution(institutions);
    }

    // public void AddInstitution()
    // {
        
    // }
    // * This function get all the institution.
    public static List<Institution> GetInstitutions()
    {
        List<Institution> institutions = new List<Institution>();

        string sql = "SELECT * FROM Institution";


        SqlConnection connection = new SqlConnection(dbConn);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = sql;

        try
        {
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
            Institution institution = new Institution();
            institution.Id = reader.GetInt32(0);
            institution.Name = reader.GetString(1);
            institution.Email = reader.GetString(2);
            institution.State = reader.GetString(3);
            institution.Country = reader.GetString(4);

            institutions.Add(institution);
            }

        }
        catch(SqlException e)
        {
            Console.WriteLine("Data operation failed" + e.Message);
        }
        catch(Exception e)
        {
            Console.WriteLine("Something went wrong fixe it.." + e.Message);
        }
        finally
        {
            connection.Close();
        }
       
            return institutions;
    }

    // * This function show all the institution.
    public static void ShowInstitution(List<Institution> institutions)
    {
        foreach(Institution institution in institutions)
        {
             Console.WriteLine("====================Example=======================");

            Console.WriteLine($"Id: { institution.Id }");
            Console.WriteLine($"Name: { institution.Name }");
            Console.WriteLine($"Email: { institution.Email }");
            Console.WriteLine($"State: { institution.State }");
            Console.WriteLine($"Country: { institution.Country }");

            Console.WriteLine("====================End=======================");
        }

    }
}
