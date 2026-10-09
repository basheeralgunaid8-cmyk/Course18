using CountryBusinessAccessLayer;
using System.Data;
namespace CountryConsoleApp
{
    internal class Program
    {
        static void testFind(int ID)
        {

            ClsCountries Country = ClsCountries.Find(ID);

            if (Country != null)
            {
                Console.WriteLine("CountryID: "+Country.CountryID);
                Console.WriteLine("CountryName: "+Country.CountryName);

                Console.WriteLine("Code : " + Country.Code);
                Console.WriteLine("PhoneCode : " + Country.PhoneCode);


            }
            else
            {
                Console.WriteLine("The Country ID is not found!!");
            }
        }

        static void TestAddNewCountry()
        {
            ClsCountries country = new ClsCountries();
            country.CountryName = "Spain";
            country.Code = "00";
            country.PhoneCode = "23";
            if (country.Save())
                Console.WriteLine("the Country was added successfully with ID= " + country.CountryID);
            else
                Console.WriteLine("failed to add");
        }

        static void TestDeleteCountry(int ID)
        {

            if (ClsCountries.DeleteCountry(ID))
                Console.WriteLine("Country deleted successfully!");
            else
                Console.WriteLine("Failed to delete!");
        }

        static void TestUpdateCountry(int ID)
        {
            ClsCountries country = ClsCountries.Find(ID);

            if(country !=null)
            {
                country.CountryName = "China";
                country.Code = "CN";
                country.PhoneCode = "86";

                if (country.Save())
                    Console.WriteLine("Country Updated successfully!");
                else
                    Console.WriteLine("Country was failed to  Update successfully!");
            }
        }

        static void TestGetAllCountries()
        {
            DataTable table = ClsCountries.GetAllCountries();

            foreach(DataRow row in table.Rows)
            {

                Console.WriteLine($"{row["CountryID"]}, {row["CountryName"]}");
            }
        }
        static void IsContactExist(int ID)
        {

            if (ClsCountries.IsCountryExist(ID))
                Console.WriteLine("The Country is existied!");
            else
                Console.WriteLine("The Country not is found!");
        }
        static void Main(string[] args)
        {
            //testFind(1);

           //TestAddNewCountry();

            //TestDeleteCountry(9);

           // TestUpdateCountry(13);

            //TestGetAllCountries();
            //IsContactExist(10);
        }
    }
}
