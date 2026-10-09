using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
namespace DVLD_BusinessLayer
{
    public class ClsPerson
    {

        public enum enPersonFilter
        {
            All,
            FirstName,
            NationalID,
            Email
        }
        public enum enMode
        {
            AddNew = 0,
            updateMode = 1
        }

        public enMode Mode = enMode.AddNew;
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public string NationalID { get; set; }
        public DateTime BirthOfDate { get; set; }
        public string Address { get; set; }
        public string PassportNo { get; set; }
        public string Gender { get; set; }
        public int NationalCountryID { get; set; }
        public string ImagePath { get; set; }
        public string Email { get; set; }

        public string FullName()
        {
            return FirstName + " " + SecondName + " " + ThirdName + " " + FourthName;
        }
        public ClsPerson()
        {
            this.PersonID = -1;
            this.FirstName = " ";
            this.SecondName = " ";
            this.ThirdName = " ";
            this.FourthName = " ";
            this.NationalID = " ";
            this.BirthOfDate = DateTime.Now;
            this.Address = " ";
            this.PassportNo = " ";
            this.Gender = " ";
            this.NationalCountryID = -1;
            this.ImagePath = " ";
            this.Email = " ";
            Mode = enMode.AddNew;
        }


        public ClsPerson(int Person_ID, string Frist_Name, string Second_Name, string Third_Name, string Fourth_Name,
                     string Nationl_ID, DateTime Date_Of_Birthday, string address, string Passport_No,
                          string gender, int National_Country_ID, string Image_Path, string email)
        {
            this.PersonID = Person_ID;
            this.FirstName = Frist_Name;
            this.SecondName = Second_Name;
            this.ThirdName = Third_Name;
            this.NationalID = Nationl_ID;
            this.BirthOfDate = Date_Of_Birthday;
            this.Address = address;
            this.PassportNo = Passport_No;
            this.Gender = gender;
            this.NationalCountryID = National_Country_ID;
            this.ImagePath = Image_Path;
            this.Email = email;
            Mode = enMode.updateMode;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.FourthName,
                                                             this.NationalID, this.BirthOfDate, this.Address, this.PassportNo, this.Gender,
                                                                 this.NationalCountryID, this.ImagePath, this.Email);

            return (this.PersonID != -1);
        }

        public bool _Update()
        {
            return clsPersonData.UpdatePersonInfo(this.PersonID, this.FirstName, this.SecondName, this.ThirdName,
                                                    this.FourthName, this.NationalID, this.BirthOfDate, this.Address,
                                                           this.PassportNo, this.Gender, this.NationalCountryID, this.ImagePath, this.Email);

        }

        //filter by ID
        public static ClsPerson Find(int ID)
        {
            string First_Name = "", Second_Name = " ", Third_Name = " ", Fourth_Name = " ", Nationl_ID = " ",
                address = " ", Passport_No = " ", gender = " ", Image_Path = " ", email = " ";
            DateTime Date_Of_Birthday = DateTime.Now;
            int NationalityCountryID = -1;
            if (clsPersonData.FindPersonInfoByID(ID, ref First_Name, ref Second_Name, ref Third_Name, ref Fourth_Name,
            ref Nationl_ID, ref Date_Of_Birthday, ref address, ref Passport_No, ref gender,
           ref NationalityCountryID, ref Image_Path, ref email))

                return new ClsPerson(ID, First_Name, Second_Name, Third_Name, Fourth_Name,
             Nationl_ID, Date_Of_Birthday, address, Passport_No, gender,
            NationalityCountryID, Image_Path, email);

            else
                return null;
        }

        // filter by National ID
        public static ClsPerson FindbyNationalID(string NationalID)
        {
            string First_Name = "", Second_Name = " ", Third_Name = " ", Fourth_Name = " ",
                address = " ", Passport_No = " ", gender = " ", Image_Path = " ", email = " ";
            DateTime Date_Of_Birthday = DateTime.Now;
            int NationalityCountryID = -1, Person_ID = -1;
            if (clsPersonData.FindPersonInfoByNationalID(ref Person_ID, ref First_Name, ref Second_Name, ref Third_Name, ref Fourth_Name,
             NationalID, ref Date_Of_Birthday, ref address, ref Passport_No, ref gender,
           ref NationalityCountryID, ref Image_Path, ref email))

                return new ClsPerson(Person_ID, First_Name, Second_Name, Third_Name, Fourth_Name,
             NationalID, Date_Of_Birthday, address, Passport_No, gender,
            NationalityCountryID, Image_Path, email);

            else
                return null;
        }

        // filter by FirstName 
        public static ClsPerson FindbyFirst_Name(string FirstName)
        {
            string Second_Name = " ", Third_Name = " ", Fourth_Name = " ",
             NationalID = " ", address = " ", Passport_No = " ", gender = " ", Image_Path = " ", email = " ";
            DateTime Date_Of_Birthday = DateTime.Now;
            int NationalityCountryID = -1, Person_ID = -1;
            if (clsPersonData.FindPersonInfoByFirstName(ref Person_ID, FirstName, ref Second_Name, ref Third_Name, ref Fourth_Name,
             ref NationalID, ref Date_Of_Birthday, ref address, ref Passport_No, ref gender,
           ref NationalityCountryID, ref Image_Path, ref email))

                return new ClsPerson(Person_ID, FirstName, Second_Name, Third_Name, Fourth_Name,
             NationalID, Date_Of_Birthday, address, Passport_No, gender,
            NationalityCountryID, Image_Path, email);

            else
                return null;
        }
        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.updateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.updateMode:
                    return _Update();

            }

            return false;

        }

        public static DataTable GetAllPeopleInfo()
        {
            return clsPersonData.GetAllPeople();
        }


        public static DataTable Search(string search, string filterColumn)
        {
            if (string.IsNullOrEmpty(search))
            {
                return clsPersonData.GetAllPeople();
            }

            return clsPersonData.SearchPeople(search, filterColumn);
        }
        public static bool IsExit(int ID)
        {
            return clsPersonData.IsPersonExist(ID);
        }

        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePersonInfo(ID);
        }
    }

}