using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsLicense
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement= 3, LostReplacement = 4 };
  
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public clsDriver DriverInfo { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        public clsDetainedLicense DetainedInfo { get; set; }

        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }

        }

        public bool IsDetained
        {
            get { return clsDetainedLicense.IsLicenseDetained(this.LicenseID); }
        }

        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            IsActive = false;
            IssueReason = enIssueReason.FirstTime;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        public clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate, string Notes,
                                           float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID= DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            this.DriverInfo = clsDriver.FindByDriverID(DriverID);
            this.DetainedInfo = clsDetainedLicense.FindByLicenseID(this.LicenseID);

            Mode = enMode.Update;
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Notes,
                                           this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Notes,
                                           this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }

        public static clsLicense FindByLicenseID(int LicenseID)
        {

            int ApplicationID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;

            bool IsFound = clsLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate,
                ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);


            if (IsFound)
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive,
                    (enIssueReason)IssueReason, CreatedByUserID);
            else
                return null; 

        }

        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            int LicenseID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;

            if (clsLicenseData.GetLicenseInfoByApplicationID(ApplicationID, ref LicenseID, ref DriverID,
                ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {

                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate,
                    Notes, PaidFees, IsActive, (clsLicense.enIssueReason)IssueReason, CreatedByUserID);

            }
            else
                return null;

        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:

                    if(_AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateLicense();

            }

            return false;
        }
        public static DataTable GetAllLicenses()
        {
            return clsLicenseData.GetAllLicenses();
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicenseData.GetDriverLicenses(DriverID);
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {

                case enIssueReason.FirstTime:
                    return "First time";

                case enIssueReason.Renew:
                    return "Renew";

                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";

                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";

                default:
                    return "First time";

            }
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }

        public static bool IsLicenseExistByPersonID(int PersonID,int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }

        public Boolean IsLicenseExpired()
        {
            return (this.ExpirationDate < DateTime.Now);
        }

        public bool DeactivateCurrentLicense()
        {
            return (clsLicenseData.DeactivateLicense(this.LicenseID));
        }

        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {

            clsApplication Application = new clsApplication();

            Application.ApplicationPersonID = DriverInfo.PersonInfo.ID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if(!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.Find(LicenseClassID).DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = clsLicenseClass.Find(LicenseClassID).ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
            {
                return null;
            }

            DeactivateCurrentLicense();

            return NewLicense;

        }

        public clsLicense Replace(enIssueReason issueReason, int CreatedByUserID)
        {

            clsApplication Application = new clsApplication();

            Application.ApplicationPersonID = DriverInfo.PersonInfo.ID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ? 
                (int)clsApplication.enApplicationType.ReplacementforDamagedDrivingLicense :
                (int)clsApplication.enApplicationType.ReplacementforLostDrivingLicense;

            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find(Application.ApplicationTypeID).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.Find(LicenseClassID).DefaultValidityLength);
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = clsLicenseClass.Find(LicenseClassID).ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = issueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
            {
                return null;
            }

            DeactivateCurrentLicense();

            return NewLicense;

        }

        public int Detain(float FineFees, int CreatedByUserID)
        {

            clsDetainedLicense detainedLicense = new clsDetainedLicense();
            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = FineFees;
            detainedLicense.CreatedByUserID = CreatedByUserID;
            detainedLicense.IsReleased = false;

            if (detainedLicense.Save())
            {
                return detainedLicense.DetainID;
            }
            else
            {
                return -1;
            }
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {

            clsApplication Application = new clsApplication();

            Application.ApplicationPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees;
            Application.CreatedByUserID = ReleasedByUserID;

            if(!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = Application.ApplicationID;

            return this.DetainedInfo.ReleasedDetainedLicense(ReleasedByUserID, Application.ApplicationID);
        }
    }
}
