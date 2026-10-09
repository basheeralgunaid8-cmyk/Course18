using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsPhone
    {
        public enum enMode
        {
            AddNew = 0,
            updateMode = 1
        }

        public enMode Mode = enMode.AddNew;
        public int PhoneID { get; set; }
        public string Phone { get; set; }
        public int PersonID { get; set; }


        public clsPhone()
        {
            this.PhoneID = -1;
            this.Phone = " ";
            this.PersonID = -1;
        }
        public clsPhone(int phoneID, string phone, int Person_ID)
        {
            this.PhoneID = phoneID;
            this.Phone = phone;
            this.PersonID = Person_ID;

        }

        private bool _AddNewPhone()
        {
            this.PersonID = clsPhoneData.AddNewPhone(this.Phone, this.PersonID);

            return (this.PersonID != -1);
        }

        public bool _UpdatePhone()
        {
            return clsPhoneData.UpdatePhoneInfo(this.PersonID, this.Phone, this.PersonID);

        }

        //filter by ID
        public static clsPhone FindPhone(int ID)
        {
            string Phone = " ";

            int Person_ID = -1;
            if (clsPhoneData.FindPhoneInfoByID(ID, ref Phone, ref Person_ID))
                return new clsPhone(ID, Phone, Person_ID);

            else
                return null;
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPhone())
                    {
                        Mode = enMode.updateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.updateMode:
                    return _UpdatePhone();

            }

            return false;

        }

        public static DataTable GetAllPeopleInfo()
        {
            return clsPhoneData.GetAllPhone();
        }

        public static bool IsExit(int ID)
        {
            return clsPhoneData.IsPhoneExist(ID);
        }
    }
}


