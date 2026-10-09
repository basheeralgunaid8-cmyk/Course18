
using System;
using Microsoft.Data.SqlClient;


namespace UpdateSqlC_
{
    internal class Program
    {
        static string connectionstring = "Server=.;Database=ContactsDB;User Id=sa;Password=Admin@123456;Encrypt=True;TrustServerCertificate=True;";
       
        static bool UpdateContactById(int ContactID)
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            string query = @"Delete Contacts  
                                           WHERE ContactID=@ContactID ";


           using  SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@ContactID", System.Data.SqlDbType.Int).Value= ContactID;
        

            try
            {
                connection.Open();
                return command.ExecuteNonQuery() > 0;

            }
            catch (SqlException ex) 
            {
                Console.WriteLine("Error: " + ex.Message);
                
            }
            return false;

        }
        static void Main(string[] args)
        {

          

            if (UpdateContactById(100))
                Console.WriteLine("Deleted");
            else
                Console.WriteLine("Not found");
            Console.ReadKey();

        }
    }
}
