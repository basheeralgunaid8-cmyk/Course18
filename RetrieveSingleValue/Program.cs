using System;
using Microsoft.Data.SqlClient;


namespace RetrieveSingleValue
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

        static String GetFirstValue(int ContactID)
        {

            string FirstName = "";

            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "select FirstName from Contacts WHERE ContactID=@ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if(result!=null)
                {
                    FirstName = result.ToString();
                }
                else
                {
                    FirstName = " ";
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : "+ ex.Message);
            }
          
            return FirstName;
        }
        static bool FindContactByID(int ContactID,ref stContact ContactInfo)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "select * from Contacts WHERE ContactID=@ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    isFound = true;
                    ContactInfo.ID = (int)reader["ContactID"];
                    ContactInfo.FirstName = (string)reader["FirstName"];
                    ContactInfo.LastName = (string)reader["LastName"];
                    ContactInfo.Email = (string)reader["Email"];
                    ContactInfo.Phone = (string)reader["Phone"];
                    ContactInfo.Address = (string)reader["Address"];
                    ContactInfo.CountryID = (int)reader["CountryID"];

                }else
                {
                    isFound = false;
                }
                reader.Close();
                connection.Close();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);

            }

            return isFound;
        }
        static void Main(string[] args)
        {
            stContact ContactInfo = new stContact();


            if(FindContactByID(1,ref ContactInfo))
            {
                Console.WriteLine($"\nContact ID   :{ContactInfo.ID}");
                Console.WriteLine($"Name         :{ContactInfo.FirstName}{ContactInfo.LastName}");
                Console.WriteLine($"Email        :{ContactInfo.Email}");
                Console.WriteLine($"Phone        :{ContactInfo.Phone}");
                Console.WriteLine($"Address      :{ContactInfo.Address}");
                Console.WriteLine($"Country ID   :{ContactInfo.CountryID}");

            }
            else
            {
                Console.WriteLine("The contact is not found");
            }
               // Console.WriteLine(GetFirstValue(1));

            Console.ReadKey();
        }
    }
}
