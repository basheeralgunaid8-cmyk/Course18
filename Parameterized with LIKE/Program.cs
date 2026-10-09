using System;
using Microsoft.Data.SqlClient;


namespace Parameterized_with_LIKE
{
    
    internal class Program
    {
        static string connectionstring = "Server=.;Database=ContactsDB;User Id=sa;Password=Admin@123456;Encrypt=True;TrustServerCertificate=True;";

        static void PrintAllContactWithQueryParameterizedWithLike(string StartWith)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "Select *from Contacts  where FirstName Like +@StartWith+'%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StartWith", StartWith);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    int contactId = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int country = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {contactId}");
                    Console.WriteLine($"Name   : {firstName}{lastName}");
                    Console.WriteLine($"Email  : {email}");
                    Console.WriteLine($"Phone  : {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country: {country}\n");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : ", ex.Message);
            }

        }
        static void Main(string[] args)
        {
            PrintAllContactWithQueryParameterizedWithLike("j");


            Console.ReadKey();
        }
    }
}
