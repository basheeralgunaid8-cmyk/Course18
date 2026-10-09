using ContactsBussinessLayer;
using System.Data;
namespace ContactsConsolApp
{
    internal class Program
    {
        static void testFind(int ID)
        {

            clsContacts Contact = clsContacts.Find(ID);

            if (Contact != null)
            {
                Console.WriteLine(Contact.FirstName + " " + Contact.LastName);
                Console.WriteLine(Contact.Email);
                Console.WriteLine(Contact.Phone);
                Console.WriteLine(Contact.Address);
                Console.WriteLine(Contact.CountryID);
            
            }
            else
            {
                Console.WriteLine("The Contact ID not found!!");
            }
        }
        static void TestAddNewContact()
        {
            clsContacts contact = new clsContacts();
            contact.FirstName = "Basheer";
            contact.LastName = "Mohammed";
            contact.Email = "aslkdfsgmail.com";
            contact.Phone = "43343545";
            contact.Address = "china, xian";

            contact.CountryID = 1;

            if(contact.Save())
            {
                Console.WriteLine("the contact is added successfully with ID=" + contact.ID);
            }
        }
        static void TestDeletContact(int ID)
        {

            if (clsContacts.IsContactExist(ID))
                if (clsContacts.DeleteContact(ID))
                Console.WriteLine("Contact Deleted Successfully!");
            else
                Console.WriteLine("Contact failed !");

            Console.WriteLine("The contact not is found!");

        }
        static void TestUpdateContact()
        {
            clsContacts contact = clsContacts.Find(1);
            if (contact != null)
            {

                contact.FirstName = "Basheer";
                contact.LastName = "Mohammed";
                contact.Email = "aslkdfsgmail.com";
                contact.Phone = "43343545";
                contact.Address = "china, xian";
                contact.CountryID = 1;

                if (contact.Save())
                {
                    Console.WriteLine("Contact Updated Successfully!");
                }
            }
        }
        static void TestGetAllContacts()
        {
            DataTable datatable = clsContacts.GetAllContacts();
            foreach (DataRow row in datatable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]}, {row["FirstName"]},{row["LastName"]}");
            }
        }
        static void IsContactExist(int ID)
        {

            if (clsContacts.IsContactExist(ID))
                Console.WriteLine("The contact is existied!");
            else
                Console.WriteLine("The contact not is found!");
        }

        //Country
        static void testFindCountryByID(int ID)
        {

            ClsCountries Country = ClsCountries.Find(ID);

            if (Country != null)
            {
                Console.WriteLine("CountryID: " + Country.CountryID);
                Console.WriteLine("CountryName: " + Country.CountryName);

                Console.WriteLine("Code : " + Country.Code);
                Console.WriteLine("PhoneCode : " + Country.PhoneCode);


            }
            else
            {
                Console.WriteLine("The Country ID is not found!!");
            }
        }
        static void testFindCountryByName(string Name)
        {

            ClsCountries Country = ClsCountries.FindCountryByName(Name);

            if (Country != null)
            {
                Console.WriteLine("CountryID: " + Country.CountryID);
                Console.WriteLine("CountryName: " + Country.CountryName);

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

            if (country != null)
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

            foreach (DataRow row in table.Rows)
            {

                Console.WriteLine($"{row["CountryID"]}, {row["CountryName"]}");
            }
        }
        static void IsCountryExist(int ID)
        {

            if (ClsCountries.IsCountryExist(ID))
                Console.WriteLine("The Country is existied!");
            else
                Console.WriteLine("The Country not is found!");
        }
        static void Main(string[] args)
        {


            //testFind(1);
            //Console.WriteLine("--------------------------");
            //testFindCountry(1);
            TestGetAllContacts();
            //testFindCountryByName("China");
            Console.ReadKey();

        }
    }
}
