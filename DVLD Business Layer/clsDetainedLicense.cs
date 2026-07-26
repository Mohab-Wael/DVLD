using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsDetainedLicense 
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public clsUser ReleasedByUserInfo { get; set; }
        public int ReleaseApplicationID { get; set; }
        public clsApplication ReleaseApplicationInfo;

        public clsDetainedLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = DateTime.Now;
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;

            Mode = enMode.AddNew;
        }

        public clsDetainedLicense( int DetainID, int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate,
            int ReleasedByUserID, int ReleaseApplicationID)
        {

            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindByUserID(this.CreatedByUserID);
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleasedByUserInfo = clsUser.FindByUserID(this.ReleasedByUserID);
            this.ReleaseApplicationID = ReleaseApplicationID;

            Mode = enMode.Update;
        }

        private bool _AddNewDetainLicense()
        {
            this.DetainID = clsDetainedLicenseData.AddNewDetainLicense(LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased);

            return (this.DetainID != -1);
        }

        private bool _UpdatedDetainedLicense()
        {
            return clsDetainedLicenseData.UpdateDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased,
                ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdatedDetainedLicense();

            }

            return false;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();
        }

        public static clsDetainedLicense FindByID(int DetainID)
        {
            int LicenseID = -1, CreatedByUserID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.MaxValue, ReleaseDate = DateTime.MaxValue;
            float FineFees = 0;
            bool IsReleased = false;

            if (clsDetainedLicenseData.GetDetainedLicenseInfoByID(DetainID, ref LicenseID, ref DetainDate, ref FineFees,
                ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate,
                    ReleasedByUserID, ReleaseApplicationID);
            }
            else
                return null; 
        }

        public static clsDetainedLicense FindByLicenseID(int LicenseID)
        {
            int DetainID = -1, CreatedByUserID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.MaxValue, ReleaseDate = DateTime.MaxValue;
            float FineFees = 0;
            bool IsReleased = false;

            if (clsDetainedLicenseData.GetDetainedLicenseInfoByLicenseID(LicenseID, ref DetainID, ref DetainDate, ref FineFees,
               ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {

                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased,
                    ReleaseDate, ReleasedByUserID, ReleaseApplicationID);

            }
            else
                return null; 

        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicenseData.IsLicenseDetained(LicenseID);
        }

        public bool ReleasedDetainedLicense(int ReleasedByUserID, int ReleasedApplicationID)
        {
            return clsDetainedLicenseData.ReleaseDetainedLicense(this.DetainID, ReleasedByUserID, ReleasedApplicationID);
        }
    }
}
