using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public class clsDriver
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public clsPerson PersonInfo { get; set; }
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }


        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;
        }

        public clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {

            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            Mode = enMode.Update;
        }

        private bool _AddNewDriver()
        {
            this.DriverID = clsDriverData.AddNewDriver(this.PersonID, this.CreatedByUserID);

            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            return clsDriverData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreatedDate);
        }

        public static clsDriver FindByDriverID(int DriverID)
        {

            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            bool IsFound = clsDriverData.GetDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate);

            if (IsFound)
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
            {
                return null;
            }
        }

        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            bool IsFound = clsDriverData.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate);

            if (IsFound)
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDriver();

            }

            return false;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }

        public static bool IsDriverExist(int DriverID)
        {
           return  clsDriverData.IsDriverExist(DriverID);
        }

        public static bool IsPersonDriver(int PersonID)
        {
            return clsDriverData.IsPersonDriver(PersonID);
        }

        public static DataTable GetLicenses(int DriverID)
        {
            return clsLicense.GetDriverLicenses(DriverID);
        }

        public static DataTable GetInternationalLicenses(int DriverID)
        {
            return clsInternationalLicense.GetDriverInternationalLicenses(DriverID);
        }
    }
}
