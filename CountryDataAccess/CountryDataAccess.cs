using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace CountryDataAccess
{
    public class clsCountryDataAccess
    {
        public static bool FindCountryInfoByID(int ID, ref string CountryName,ref string Code, ref string PhoneCode)
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
                    if(reader["Code"] != DBNull.Value)
                    Code = (string)reader["Code"];

                    if(reader["PhoneCode"] != DBNull.Value)
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

        public static int AddNewCountry(string CountryName,string Code,string PhoneCode)
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
                if(result !=null &&int.TryParse(result.ToString(),out int insertID))
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
                if(rowsAffect>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffect > 0);
        }

        public static bool UpdateCountry(int CountryID,string CountryName,string Code, string PhoneCode)
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
                if(reader.HasRows)
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
