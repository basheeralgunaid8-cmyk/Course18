using System;
using Microsoft.Data.SqlClient;

namespace Insert_AddData
{

    internal class Program
    {
        static string connectionstring = "Server=.;Database=ContactsDB;User Id=sa;Password=Admin@123456;Encrypt=True;TrustServerCertificate=True;";
        public struct stContact
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CountryID { get; set; }

        }
        static void AddNewContact(stContact NewContact)
        {
           using SqlConnection connnection = new SqlConnection(connectionstring);

            string query = @"INSERT INTO Contacts( FirstName,LastName,Email,Phone ,Address ,CountryID)
                               VALUES ( @FirstName,@LastName,@Email,@Phone ,@Address ,@CountryID);
                             SELECT SCOPE_IDENTITY();";

           using SqlCommand command = new SqlCommand(query, connnection);

            command.Parameters.AddWithValue("@FirstName", NewContact.FirstName);
            command.Parameters.AddWithValue("@LastName", NewContact.LastName);
            command.Parameters.AddWithValue("@Email", NewContact.Email);
            command.Parameters.AddWithValue("@Phone", NewContact.Phone);
            command.Parameters.AddWithValue("@Address", NewContact.Address);
            command.Parameters.AddWithValue("@CountryID", NewContact.CountryID);

            try
            {
                connnection.Open();
                object result = command.ExecuteScalar();

                if(result!=null && int.TryParse(result.ToString(),out int insertID))
                {
                    Console.WriteLine($"Newly inserted ID:{insertID}");
                }
                else
                {
                    Console.WriteLine("Failed to retrieve the inserted ID");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
          
        }
        static void Main(string[] args)
        {


            stContact NewContact = new stContact
            {

                FirstName = "Ali",
                LastName = "Ahemd ",
                Email="Ahmed@gmail.com",
                Phone="4234243242",
                Address="UK,London",
                CountryID=3

            };

            AddNewContact(NewContact);
            Console.ReadKey();

        }
    }
}
