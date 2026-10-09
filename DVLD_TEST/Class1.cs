using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_PresentationLayer
{
    internal class Class1
    {
        static void TestAddNewPerson()
        {
            ClsPerson Person2 = new ClsPerson();                                 // PersonID (new person)
            Person2.FirstName = "Sultan";                       // FirstName
            Person2.SecondName = "Najib";                            // SecondName
            Person2.ThirdName = "Salah";                         // ThirdName
            Person2.FourthName = "Ali";                      // FourthName
            Person2.NationalID = "12339034343";                      // NationalID
            Person2.BirthOfDate = new DateTime(2005, 5, 15);         // DateOfBirth
            Person2.Address = "Sana'a, Yemen";                   // Address
            Person2.PassportNo = "123123";                        // PassportNo
            Person2.Gender = "Male";                                // Gender (0 = Male, 1 = Female)
            Person2.NationalCountryID = 194;                                // NationalityCountryID
            Person2.ImagePath = "klsdkfjlsdf ";                               // ImagePath
            Person2.Email = " Zore@gmail.com";
            if (Person2.Save())
                Console.WriteLine("Person Added Successfully.");
            else
                Console.WriteLine("Failed to Add Person.");
        }
        static void TestFindPerson(int ID)
        {
            ClsPerson Person = ClsPerson.Find(ID);

            if (Person != null)
            {
                Console.WriteLine(" Full Name   :" + Person.FullName());
                Console.WriteLine(" National ID : " + Person.NationalID);
                Console.WriteLine(" Birthday    : " + Person.BirthOfDate);
                Console.WriteLine(" Address     :" + Person.Address);
                Console.WriteLine("Passport No  :" + Person.PassportNo);
                Console.WriteLine("Gender       :" + Person.Gender);
                Console.WriteLine("NationalityCountry ID :" + Person.NationalCountryID);
                Console.WriteLine(" Image Path  :" + Person.ImagePath);
            }
        }
        static void TestFindPersonByNationalID(string ID)
        {
            ClsPerson Person = ClsPerson.FindbyNationalID(ID);

            if (Person != null)
            {
                Console.WriteLine(" Person ID : " + Person.PersonID);
                Console.WriteLine(" Full Name   :" + Person.FullName());
                Console.WriteLine(" Birthday    : " + Person.BirthOfDate);
                Console.WriteLine(" Address     :" + Person.Address);
                Console.WriteLine("Passport No  :" + Person.PassportNo);
                Console.WriteLine("Gender       :" + Person.Gender);
                Console.WriteLine("NationalityCountry ID :" + Person.NationalCountryID);
                Console.WriteLine(" Image Path  :" + Person.ImagePath);
            }
        }

        static void TestUpdatePersonInfo()
        {
            ClsPerson Person = ClsPerson.Find(2);

            if (Person != null)
            {
                Person.FirstName = "Uday";                       // FirstName
                Person.SecondName = "Mohammed";                            // SecondName
                Person.ThirdName = "Salah";                         // ThirdName
                Person.FourthName = "Al-Mhamoudi";                      // FourthName
                Person.NationalID = "12795kdjls80";                      // NationalID
                Person.BirthOfDate = new DateTime(2005, 5, 15);         // DateOfBirth
                Person.Address = "Al Dhale', Yemen";                   // Address
                Person.PassportNo = "1279580";                        // PassportNo
                Person.Gender = "Male";                                // Gender (0 = Male, 1 = Female)
                Person.NationalCountryID = 194;                                // NationalityCountryID
                Person.ImagePath = "nothing";                               // ImagePath

                if (Person.Save())
                    Console.WriteLine("Person Updated Successfully.");
                else
                    Console.WriteLine("Failed to update Person.");

            }
        }

        static void TestGetAllPeopleInfo()
        {
            DataTable dt = ClsPerson.GetAllPeopleInfo();

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["PersonID"]}, {row["FirstName"]},{row["SecondName"]}");
            }


        }
        static void IsPersonInfoist(int ID)
        {

            if (ClsPerson.IsExit(ID))
                Console.WriteLine("The Person is existied!");
            else
                Console.WriteLine("The Person not is found!");
        }

        static void DeletePersonInfo(int ID)
        {

            if (ClsPerson.DeletePerson(ID))
                Console.WriteLine("The Person is Deleted!");
            else
                Console.WriteLine("The Person is not deleted!");
        }







        static void TestAddNewPhone()
        {
            clsPhone Phone = new clsPhone();                                 // PersonID (new person)
            Phone.Phone = "1234566";                       // FirstName
            Phone.PersonID = 5;                            // SecondName

            if (Phone.Save())
                Console.WriteLine("Phone Added Successfully.");
            else
                Console.WriteLine("Failed to Add Phone.");
        }
        static void Main(string[] args)
        {
            //TestAddNewPerson();
            // TestFindPersonByNationalID("12339034343");
            //TestFindPerson()
            // TestUpdatePersonInfo();
            //TestGetAllPeopleInfo();
            //IsPersonInfoist(4);
            //DeletePersonInfo(1006);


            TestAddNewPhone();

        }
    
}
}
