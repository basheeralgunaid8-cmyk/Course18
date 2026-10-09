using CountryDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CountryBusinessAccessLayer
{

    public enum Mode
    {
        updateMode = 2,
        AddNew = 1
    }
    public class ClsCountries
    {

        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string Code { get; set; }
        public string PhoneCode { get; set; }



        public Mode Mode { get; set; }


        public ClsCountries()
        {

            this.CountryID = -1;
            this.CountryName = "";
            this.Code = "";
            this.PhoneCode = "";
            Mode = Mode.AddNew;
        }

        private ClsCountries(int countryID,string CountryName,string code, string phoneCode)

        {
            this.CountryID = countryID;
            this.CountryName = CountryName;
            this.Code = code;
            this.PhoneCode = phoneCode;

            Mode = Mode.updateMode;
        }

        private  bool _AddNewCountry()
        {
            this.CountryID = clsCountryDataAccess.AddNewCountry(this.CountryName,this.Code,this.PhoneCode);
                return (CountryID !=-1);
        }
        public static ClsCountries Find(int CountryID)
        {
            string CountryName = "",Code="",PhoneCode="";
         
            if (clsCountryDataAccess.FindCountryInfoByID(CountryID,ref CountryName,ref Code,ref PhoneCode))
                return new ClsCountries(CountryID, CountryName,Code,PhoneCode);
            else
                return null;
        }

        public static bool DeleteCountry(int ID)
        {
            return (clsCountryDataAccess.DeleteCountry(ID));
        }

        private  bool _UpdateCountry()
        {
            return clsCountryDataAccess.UpdateCountry(this.CountryID, this.CountryName,this.Code,this.PhoneCode);
        }
        
        public  bool Save()
        {

            switch(Mode)
            {
                case Mode.AddNew:
                    if(_AddNewCountry())
                    {
                        Mode=Mode.updateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Mode.updateMode:
                    return _UpdateCountry();
            }

            return false;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }

        public static bool IsCountryExist(int ID)
        {
            return clsCountryDataAccess.IsContactExist(ID);
        }


    }
}
