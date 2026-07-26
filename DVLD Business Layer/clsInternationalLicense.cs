using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsInternationalLicense : clsApplication
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode;

        public int InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public clsDriver DriverInfo {  get; set; }
        public int IssueUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }

        public clsInternationalLicense ()
        {
            ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;

            InternationalLicenseID = -1;
            DriverID = -1;
            IssueUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = true;
            Mode = enMode.AddNew;
        }

        public clsInternationalLicense(int ApplicationID, int ApplicationPersonID, DateTime ApplicationDate, 
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID, 
            int InternationalLicenseID, int DriverID, int IssueUsingLocalLicenseID, DateTime IssueDate, 
            DateTime ExpirationDate, bool IsActive) 
        {

            base.ApplicationID = ApplicationID;
            base.ApplicationPersonID = ApplicationPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUserID;


            this.InternationalLicenseID = InternationalLicenseID;
            this.DriverID = DriverID;
            this.DriverInfo = clsDriver.FindByDriverID(DriverID);
            this.ApplicationID = ApplicationID;
            this.IssueUsingLocalLicenseID = IssueUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            this.DriverInfo = clsDriver.FindByDriverID(DriverID);

            Mode = enMode.Update;
        }
        
        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.AddNewInternationalLicense(this.ApplicationID, this.DriverID, this.IssueUsingLocalLicenseID,
                this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
            return (this.InternationalLicenseID != -1);
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(this.InternationalLicenseID, this.ApplicationID,
                this.DriverID, this.IssueUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
        }
        
        public bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;
            if(!base.Save())
                return false;


            switch (Mode)
            {
                case enMode.AddNew:
                    if(_AddNewInternationalLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            
                    case enMode.Update:
                     return _UpdateInternationalLicense();
            
            }

            return false;
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1, DriverID = -1, IssueUsingLocalLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false;

            if(clsInternationalLicenseData.GetInternationalLicenseInfoByID(InternationalLicenseID, ref ApplicationID, ref DriverID,
                ref IssueUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {

                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsInternationalLicense(Application.ApplicationID, Application.ApplicationPersonID, Application.ApplicationDate,
                    Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID,
                    InternationalLicenseID, DriverID, IssueUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive);

            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalLicenseData.GetDriverInternationalLicenses(DriverID);
        }


        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            return clsInternationalLicenseData.GetActiveInternationalLicenseIDByDriverID(DriverID);
        }


    }
}
