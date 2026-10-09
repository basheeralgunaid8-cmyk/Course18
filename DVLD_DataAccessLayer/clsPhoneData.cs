using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsPhoneData
    {

        public static int AddNewPhone(string Phone, int PersonID)
        {

            int PhoneID = -1;
            using SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"INSERT INTO Phone(Phone,PersonID) VALUES(@Phone,@PersonID);
                      SELECT SCOPE_IDENTITY();  ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@Phone", System.Data.SqlDbType.NVarChar, 50).Value = Phone;
            command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = PersonID;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    PhoneID = InsertID;
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
            return PhoneID;
        }
        public static bool FindPhoneInfoByID(int PhoneID, ref string Phone, ref int PersonID)
        {

            bool IsFound = false;

            using SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT *FROM Phone
                                  WHERE PhoneID=@PhoneID;";


            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@PhoneID", System.Data.SqlDbType.Int).Value = PhoneID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;

                    PhoneID = (int)reader["PhoneID"];
                    Phone = (string)reader["Phone"];
                    PersonID = (int)reader["PersonID"];

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
            return IsFound;
        }
        public static bool DeletePhoneInfo(int ID)
        {
            int rowAfficted = 0;
            using SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Delete from Phone
                  where PhoneID=@PhoneID";

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(@"PhoneID", System.Data.SqlDbType.Int).Value = ID;


            try
            {
                connection.Open();
                rowAfficted = command.ExecuteNonQuery();
                if (rowAfficted > 0)
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
            return (rowAfficted > 0);
        }
        public static DataTable GetAllPhone()

        {
            DataTable dt = new DataTable();
            using SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select*from Phone;";

            using SqlCommand command = new SqlCommand(query, connection);
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
        public static bool IsPhoneExist(int ID)
        {
            bool isFound = false;

            using SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT 1
                                     FROM Phone
                                        WHERE PhoneID=@PhoneID";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@PhoneID", System.Data.SqlDbType.Int).Value = ID;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                return result != null;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return isFound;
        }
        public static bool UpdatePhoneInfo(int PhoneID, string Phone, int PersonID)

        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"Update Phone
                                      SET Phone=@Phone ,
                                             PersonID=@PersonID 
                                               
                                     WHERE PhoneID=@PhoneID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@Phone", System.Data.SqlDbType.NVarChar, 50).Value = Phone;
            command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = PersonID;


            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);

        }
    }
}



