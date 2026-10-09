
using System;
using Microsoft.Data.SqlClient;


namespace UpdateSqlC_
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
        static bool UpdateContactById(int ContactID, stContact contactInfo)
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            string query = @"Update Contacts  
                                Set FirstName=@FirstName,
                                 LastName=@LastName,
                                   Email=@Email,
                                     Phone=@Phone,
                                       Address=@Address,
                                         CountryID=@CountryID
                                           WHERE ContactID=@ContactID ";


            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@ContactID", System.Data.SqlDbType.Int).Value = ContactID;
            command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar, 50).Value = contactInfo.FirstName;
            command.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar, 50).Value = contactInfo.LastName;
            command.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 50).Value = contactInfo.Email;
            command.Parameters.Add("@Phone", System.Data.SqlDbType.NVarChar, 50).Value = contactInfo.Phone;
            command.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar, 50).Value = contactInfo.Address;
            command.Parameters.Add("@CountryID", System.Data.SqlDbType.Int).Value = contactInfo.CountryID;

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

            stContact UpdatedContact = new stContact
            {

                FirstName = "Salam",
                LastName = "Mosoud ",
                Email = "MDL@gmail.com",
                Phone = "2342343",
                Address = "SE,shanghai",
                CountryID = 1

            };

            if (UpdateContactById(2, UpdatedContact))
                Console.WriteLine("Updated");
            else
                Console.WriteLine("Not found");
            Console.ReadKey();

        }
    }
}
