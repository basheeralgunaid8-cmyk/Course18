using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContactsBussinessLayer
{

    public enum Mode
    {
        updateMode = 2,
        AddNew = 1
    }

    public class clsContacts
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryID { get; set; }

        public string ImagePath { get; set; }

        public DateTime DateOfBirth { get; set; }
        public Mode Mode { get; set; }


        public clsContacts()
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.ImagePath = "";
            Mode = Mode.AddNew;
        }


        private clsContacts(int ID, string firstName, string lastName,
          string email, string phone, string address,DateTime dateOfBirth, int countryID,string imagePath)
        {
            this.ID = ID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
            DateOfBirth = dateOfBirth;
            CountryID = countryID;
            ImagePath = imagePath;
            Mode = Mode.updateMode;
        }


        private bool _AddNewContact()
        {
            this.ID = clsContactDataAccess.AddNewContact(this.FirstName, this.LastName, this.Email, this.Phone, this.Address,this.DateOfBirth, this.CountryID,this.ImagePath);
            return (this.ID != -1);
        }
        private bool _UpdateContact()
        {
            return clsContactDataAccess.UpdateContact(this.ID, this.FirstName, this.LastName, this.Email,
                this.Phone, this.Address,this.DateOfBirth, this.CountryID,this.ImagePath);
        }
        public static bool DeleteContact(int ID)
        {
            return clsContactDataAccess.DeleteContact(ID);
        }
        public static clsContacts Find(int ID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "",ImagePath="";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;
            if (clsContactDataAccess.FindContactInfoByID(ID, ref FirstName, ref LastName,
                                      ref Email, ref Phone, ref Address, ref DateOfBirth, ref CountryID,ref ImagePath ))

                return new clsContacts(ID, FirstName, LastName,
                                   Email, Phone,
                           Address, DateOfBirth, CountryID,ImagePath);
            else
                return null;
        }

        public static DataTable GetAllContacts()
        {
            return clsContactDataAccess.GetAllContacts();
        }
    public bool Save()
        {

            switch (Mode)
            {
                case Mode.AddNew:
                    if (_AddNewContact())
                    {
                        Mode = Mode.updateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case Mode.updateMode:
                  return  _UpdateContact();
                
            }

            return false;
           
        }

    public static bool IsContactExist(int ID)
        {
            return clsContactDataAccess.IsContactExist(ID);
        }
    }
    public class ClsCountries
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string Code { get; set; }
        public string PhoneCode { get; set; }


        public ClsCountries()
        {
            this.CountryID = -1;
            this.CountryName = "";

            Mode = enMode.AddNew;
      
        }

        private ClsCountries(int countryID, string CountryName, string code, string phoneCode)

        {
            this.CountryID = countryID;
            this.CountryName = CountryName;
            this.Code = code;
            this.PhoneCode = phoneCode;

            Mode = enMode.Update;
        }

        private bool _AddNewCountry()
        {
            this.CountryID = clsCountry.AddNewCountry(this.CountryName, this.Code, this.PhoneCode);
            return (CountryID != -1);
        }
        public static ClsCountries Find(int CountryID)
        {
            string CountryName = "", Code = "", PhoneCode = "";

            if (clsCountry.FindCountryInfoByID(CountryID, ref CountryName, ref Code, ref PhoneCode))
                return new ClsCountries(CountryID, CountryName, Code, PhoneCode);
            else
                return null;
        }
        public static ClsCountries Find(string CountryName)
        {

            int ID = -1;
            string Code = "";
            string PhoneCode = "";


            if (clsCountry.GetCountryInfoByName(CountryName, ref ID, ref Code, ref PhoneCode))

                return new ClsCountries(ID, CountryName, Code, PhoneCode);
            else
                return null;

        }
     
        public static bool DeleteCountry(int ID)
        {
            return (clsCountry.DeleteCountry(ID));
        }

        private bool _UpdateCountry()
        {
            return clsCountry.UpdateCountry(this.CountryID, this.CountryName, this.Code, this.PhoneCode);
        }

        public bool SaveCountry()
        {

           

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateCountry();
            }

            return false;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountry.GetAllCountries();
        }

        public static bool IsCountryExist(int ID)
        {
            return clsCountry.IsContactExist(ID);
        }


    }

}
