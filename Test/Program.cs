using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using Microsoft.Data.SqlClient;


namespace Test
{
    internal class Program
    {
        static string connectionString =
     "Server=.;Database=ContactsDB;User Id=sa;Password=Admin@123456;Encrypt=True;TrustServerCertificate=True;";

        static void PrintAllContacts()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Contacts";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
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
                    Console.WriteLine($"Country: {country}");

                    Console.WriteLine();
                }

                reader.Close();
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error:  " + ex.Message);
            }
        }
        static void Main(string[] args)
        {
            PrintAllContacts();
            Console.ReadKey();
        }
    }
}
