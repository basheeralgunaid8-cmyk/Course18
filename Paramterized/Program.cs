using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using Microsoft.Data.SqlClient;

namespace Paramterized
{
    internal class Program
    {
        static string connectionstring= "Server=.;Database=ContactsDB;User Id=sa;Password=Admin@123456;Encrypt=True;TrustServerCertificate=True;";


        static void PrintAllContactsWithName(string FirstName)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "select *from Contacts where FirstName=@FirstName \r\n";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);

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
                    Console.WriteLine($"Country: {country}");

                    Console.WriteLine();
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:  " + ex.Message);
            }
        }
        static void PrintALLContactWithNameAndCountry(string FirstName ,int CountryID)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "select *from Contacts where FirstName=@FirstName and CountryID=@CountryID  \r\n";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@CountryID", CountryID);

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
                    Console.WriteLine($"Country: {country}");

                    Console.WriteLine();
                }
                reader.Close();
                connection.Close();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error  :", ex.Message);
            }


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Parameterized Query with one Parameter\n");
            PrintAllContactsWithName("John");

            Console.WriteLine("Parameterized Query with two Parameters\n");

            PrintALLContactWithNameAndCountry("John", 1);
            Console.ReadKey();


        }
    }
}
