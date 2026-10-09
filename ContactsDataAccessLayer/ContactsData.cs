using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq.Expressions;
using System.Management.Instrumentation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;
namespace ContactsDataAccessLayer
{
    public class clsContactDataAccess
    {
        public static DataTable GetAllContacts()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"SELECT *FROM Contacts";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static bool DeleteContact(int ContactID)
        {
            int rowefficted = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Delete from Contacts
                  where ContactID=@ContactID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(@"ContactID", System.Data.SqlDbType.Int).Value = ContactID;


            try
            {
                connection.Open();
                rowefficted = command.ExecuteNonQuery();
                if (rowefficted > 0)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (rowefficted > 0);
        }
        public static bool UpdateContact(int ID, string FirstName, string LastName,
                                       string Email, string Phone,
                               string Address,DateTime DateOfBirth, int CountryID,string ImagePath)
        {
            int rowefficted = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"Update Contacts
                                SET FirstName=@FirstName,
                                    LastName=@LastName,
                                        Email=@Email,
                                            Phone=@Phone,
                                                Address=@Address,
                                                  DateOfBirth==@DateOfBirth,
                                                    CountryID=@CountryID
                                                      ImagePath=@ImagePath
                                                          WHERE ContactID=@ContactID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@ContactID", System.Data.SqlDbType.Int).Value = ID;
            command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar, 50).Value = FirstName;
            command.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar, 50).Value = LastName;
            command.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 50).Value = Email;
            command.Parameters.Add("@Phone", System.Data.SqlDbType.NVarChar, 50).Value = Phone;
            command.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar, 50).Value = Address;
            command.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = DateOfBirth;
            command.Parameters.Add("@CountryID", System.Data.SqlDbType.Int).Value = CountryID;
            command.Parameters.Add("@ImagePath", System.Data.SqlDbType.NVarChar, 50).Value = ImagePath;

            try
            {
                connection.Open();
                rowefficted = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowefficted > 0);

        }
        public static int AddNewContact(string FirstName, string LastName,
                                       string Email, string Phone,
                               string Address, DateTime DateOfBirth, int CountryID,string ImagePath)
        {
            int ContactID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address,DateOfBirth, CountryID,ImagePath)
                             VALUES (@FirstName, @LastName, @Email, @Phone, @Address,@DateOfBirth, @CountryID,@ImagePath);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            if (ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);




            try
            {
                connection.Open();
                  object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int IsertID))
                    {
                        ContactID = IsertID;
                    }
            }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            finally
            {
                connection.Close();

            }
            return ContactID;
        }
        public static bool FindContactInfoByID(int ID, ref string FirstName, ref string LastName,
                                      ref string Email, ref string Phone,
                              ref string Address,ref DateTime DateOfBirth, ref int CountryID,ref string ImagePath)
        {

            bool isFound = false;
                SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

                    string query = @"Select *from Contacts Where ContactID=@ContactID";

                SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@ContactID", System.Data.SqlDbType.Int).Value = ID;
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    int contactId = (int)reader["ContactID"];
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    CountryID = (int)reader["CountryID"];
                    if(reader["ImagePath"] !=DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
           public static bool IsContactExist(int ContactID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select Found=1 from Contacts where ContactID=@ContactID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(@"ContactID", System.Data.SqlDbType.Int).Value = ContactID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();

            }
            catch
            {

                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

    }
    public class clsCountry
    {
        public static bool FindCountryInfoByID(int ID, ref string CountryName, ref string Code, ref string PhoneCode)
        {

            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"select *from Countries where CountryID=@CountryID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@CountryID", System.Data.SqlDbType.Int).Value = ID;
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ID = (int)reader["CountryID"];
                    CountryName = (string)reader["CountryName"];
                    if (reader["Code"] != DBNull.Value)
                        Code = (string)reader["Code"];

                    if (reader["PhoneCode"] != DBNull.Value)
                        PhoneCode = (string)reader["PhoneCode"];


                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static bool GetCountryInfoByName(string CountryName, ref int ID,
                                                ref string Code, ref string PhoneCode)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ID = (int)reader["CountryID"];

                    if (reader["Code"] != DBNull.Value)
                    {
                        Code = (string)reader["Code"];
                    }
                    else
                    {
                        Code = "";
                    }

                    if (reader["PhoneCode"] != DBNull.Value)
                    {
                        PhoneCode = (string)reader["PhoneCode"];
                    }
                    else
                    {
                        PhoneCode = "";
                    }

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewCountry(string CountryName, string Code, string PhoneCode)
        {
            int CountryID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"INSERT INTO Countries(CountryName,Code,PhoneCode)
                               VALUES(@CountryName,@Code,@PhoneCode);
                                 Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@CountryName", System.Data.SqlDbType.NVarChar, 50).Value = CountryName;
            command.Parameters.Add("@Code", System.Data.SqlDbType.NVarChar, 50).Value = Code;
            command.Parameters.Add("@PhoneCode", System.Data.SqlDbType.NVarChar, 50).Value = PhoneCode;


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertID))
                {
                    CountryID = insertID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return CountryID;

        }

        public static bool DeleteCountry(int ID)
        {

            int rowsAffect = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"Delete from Countries
                        where CountryID=@CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@CountryID", System.Data.SqlDbType.Int).Value = ID;

            try
            {
                connection.Open();
                rowsAffect = command.ExecuteNonQuery();
                if (rowsAffect > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffect > 0);
        }

        public static bool UpdateCountry(int CountryID, string CountryName, string Code, string PhoneCode)
        {
            int rowsAffect = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"Update Countries
                           SET CountryName=@CountryName,
                            Code=@Code,
                            PhoneCode=@PhoneCode
                           WHERE CountryID=@CountryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@CountryID", System.Data.SqlDbType.Int).Value = CountryID;
            command.Parameters.Add("@CountryName", System.Data.SqlDbType.NVarChar, 50).Value = CountryName;
            command.Parameters.Add("@Code", System.Data.SqlDbType.NVarChar, 50).Value = Code;
            command.Parameters.Add("@PhoneCode", System.Data.SqlDbType.NVarChar, 50).Value = PhoneCode;

            try
            {
                connection.Open();
                rowsAffect = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffect > 0);
        }

        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select *FROM Countries;";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }
        public static bool IsContactExist(int CountryID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select Found=1 from Countries where CountryID=@CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(@"CountryID", System.Data.SqlDbType.Int).Value = CountryID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();

            }
            catch
            {

                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
    }
}
