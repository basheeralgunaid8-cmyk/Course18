using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DVLD_DataAccessLayer
{
    public class clsPersonData
    {

        public static int AddNewPerson(string FirstName,string SecondName ,string ThirdName ,string FourthName,
            string NationalID,DateTime DateOfBirth, string Address,string PassportNo,string Gender, 
            int NationalityCountryID, string ImagePath,string Email)
        {
            int PersonID = -1;
            using SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString) ;

            string query = @"INSERT INTO People (FirstName, SecondName, ThirdName, FourthName,NationalID,
                                            DateOfBirth,Address, PassportNo,Gender,NationalityCountryID,ImagePath,Email)
                             VALUES(@FirstName, @SecondName, @ThirdName, @FourthName, @NationalID,
                                            @DateOfBirth,@Address, @PassportNo,@Gender,@NationalityCountryID,@ImagePath,@Email);
                             SELECT SCOPE_IDENTITY();";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar, 50).Value = FirstName;
               command.Parameters.Add("@SecondName", System.Data.SqlDbType.NVarChar, 50).Value = SecondName;
                 command.Parameters.Add("@ThirdName", System.Data.SqlDbType.NVarChar, 50).Value = ThirdName;
                    command.Parameters.Add("@FourthName", System.Data.SqlDbType.NVarChar, 50).Value = FourthName;
                       command.Parameters.Add("@NationalID", System.Data.SqlDbType.NVarChar, 20).Value = NationalID;
                          command.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.DateTime).Value = DateOfBirth;
                            command.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar, 200).Value = Address;
                    command.Parameters.Add("@PassportNo", System.Data.SqlDbType.NVarChar, 20).Value = PassportNo;
                 command.Parameters.Add("@Gender", System.Data.SqlDbType.NVarChar, 10).Value = Gender;
             command.Parameters.Add("@NationalityCountryID", System.Data.SqlDbType.Int).Value = NationalityCountryID;
          command.Parameters.Add("@ImagePath", SqlDbType.NVarChar, 200).Value =
                string.IsNullOrEmpty(ImagePath) ? (object)DBNull.Value : ImagePath;
            command.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 50).Value = Email;


            try
            {
                connection.Open();
                Console.WriteLine(connection.Database);
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    PersonID = InsertID;
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
            return PersonID;
        }

        //Filter by PersonID
        public static bool FindPersonInfoByID(int ID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string FourthName,
            ref string NationalID, ref DateTime DateOfBirth, ref string Address, ref string PassportNo, ref string Gender,
           ref int NationalityCountryID, ref string ImagePath,ref string Email)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT *FROM People
                                  WHERE PersonID=@PersonID;";
         

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = ID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;

                    ID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    FourthName = (string)reader["FourthName"];
                    NationalID = (string)reader["NationalID"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Address = (string)reader["Address"];
                    PassportNo = (string)reader["PassportNo"];
                    Gender = (string)reader["Gender"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    Email = (string)reader["Email"];

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

        //Filter by National ID
        public static bool FindPersonInfoByNationalID(ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string FourthName,
           string NationalID, ref DateTime DateOfBirth, ref string Address, ref string PassportNo, ref string Gender,
         ref int NationalityCountryID, ref string ImagePath, ref string Email)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT *FROM People
                                  WHERE NationalID=@NationalID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@NationalID", System.Data.SqlDbType.NVarChar,50).Value = NationalID;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int) reader ["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    FourthName = (string)reader["FourthName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Address = (string)reader["Address"];
                    PassportNo = (string)reader["PassportNo"];
                    Gender = (string)reader["Gender"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    Email = (string)reader["Email"];

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

        //Filter by FirstName
        public static bool FindPersonInfoByFirstName(ref int PersonID,  string FirstName, ref string SecondName, ref string ThirdName, ref string FourthName,
         ref string NationalID, ref DateTime DateOfBirth, ref string Address, ref string PassportNo, ref string Gender,
        ref int NationalityCountryID, ref string ImagePath, ref string Email)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"SELECT *FROM People
                                  WHERE FirstName=@FirstName;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar, 50).Value = FirstName;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    FourthName = (string)reader["FourthName"];
                    NationalID = (string)reader["NationalID"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Address = (string)reader["Address"];
                    PassportNo = (string)reader["PassportNo"];
                    Gender = (string)reader["Gender"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    Email = (string)reader["Email"];

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

        public static bool UpdatePersonInfo(int PersonID,string FirstName, string SecondName, string ThirdName, string FourthName,
            string NationalID, DateTime DateOfBirth, string Address, string PassportNo, string Gender,
            int NationalityCountryID, string ImagePath,string Email)

        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = @"Update People
                                      SET FirstName=@FirstName ,
                                             SecondName=@SecondName ,
                                                ThirdName=@ThirdName ,
                                                  FourthName=@FourthName ,
                                                     NationalID=@NationalID ,
                                                        DateOfBirth=@DateOfBirth ,
                                                          Address=@Address ,
                                                              PassportNo=@PassportNo ,
                                                                 Gender=@Gender ,
                                                                     NationalityCountryID=@NationalityCountryID ,
                                                                          ImagePath=@ImagePath ,
                                                                               Email=@Email 
                                     WHERE PersonID=@PersonID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = PersonID;
            command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar, 50).Value = FirstName;
            command.Parameters.Add("@SecondName", System.Data.SqlDbType.NVarChar, 50).Value = SecondName;
            command.Parameters.Add("@ThirdName", System.Data.SqlDbType.NVarChar, 50).Value = ThirdName;
            command.Parameters.Add("@FourthName", System.Data.SqlDbType.NVarChar, 50).Value = FourthName;
            command.Parameters.Add("@NationalID", System.Data.SqlDbType.NVarChar, 20).Value = NationalID;
            command.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.DateTime).Value = DateOfBirth;
            command.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar, 200).Value = Address;
            command.Parameters.Add("@PassportNo", System.Data.SqlDbType.NVarChar, 20).Value = PassportNo;
            command.Parameters.Add("@Gender", System.Data.SqlDbType.NVarChar, 10).Value = Gender;
            command.Parameters.Add("@NationalityCountryID", System.Data.SqlDbType.Int).Value = NationalityCountryID;
            command.Parameters.Add("@ImagePath", SqlDbType.NVarChar, 200).Value =
            string.IsNullOrEmpty(ImagePath) ? (object)DBNull.Value : ImagePath;
            command.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 20).Value = Email;
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


      public static DataTable SearchPeople(string searchText, string filterColumn)
{
    DataTable dt = new DataTable();

    using(SqlConnection connection =
          new SqlConnection(DataAccessSetting.ConnectionString))
    {
        string query = "";

        switch(filterColumn)
        {
            case "All":

                query = @"SELECT *
                          FROM People
                          WHERE FirstName LIKE @Search
                          OR SecondName LIKE @Search
                          OR ThirdName LIKE @Search
                          OR FourthName LIKE @Search
                          OR NationalID LIKE @Search
                          OR Email LIKE @Search";

                break;


            case "FirstName":

                query = @"SELECT *
                          FROM People
                          WHERE FirstName LIKE @Search";

                break;


            case "NationalID":

                query = @"SELECT *
                          FROM People
                          WHERE NationalID LIKE @Search";

                break;


            case "Email":

                query = @"SELECT *
                          FROM People
                          WHERE Email LIKE @Search";

                break;


            default:

                throw new Exception("Invalid search filter");

        }


        using(SqlCommand command =
              new SqlCommand(query, connection))
        {
            command.Parameters.Add("@Search",
                SqlDbType.NVarChar,100)
                .Value = "%" + searchText + "%";


            connection.Open();


            using(SqlDataReader reader =
                  command.ExecuteReader())
            {
                dt.Load(reader);
            }
        }
    }


    return dt;
}

        public static DataTable GetAllPeople()

        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select*from People;";

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


        public static bool IsPersonExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Select Found=1 from People where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(@"PersonID", System.Data.SqlDbType.Int).Value = ID;

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

        public static bool DeletePersonInfo(int ID)
        {
            int rowAfficted = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            string query = @"Delete from People
                  where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(@"PersonID", System.Data.SqlDbType.Int).Value = ID;


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
    }

   
}
