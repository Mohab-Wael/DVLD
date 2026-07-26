using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsApplication
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        public enum enApplicationType
        {
            NewLocalDrivingLicense = 1, RenewDrivingLicense=2, ReplacementforLostDrivingLicense=3,
            ReplacementforDamagedDrivingLicense=4, ReleaseDetainedDrivingLicsense=5, NewInternationalLicense=6, RetakeTest=7
        };

        public int ApplicationID { get; set; }
        public int ApplicationPersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationTypeInfo { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { get; set; }

        public string StatusText
        {

            get
            {

                switch(ApplicationStatus)
                {

                    case enApplicationStatus.New:
                        return "New";

                    case enApplicationStatus.Cancelled:
                        return "Cancelled";

                    case enApplicationStatus.Completed:
                        return "Completed";

                    default:
                        return "Unknown";


                }

            }

        }
        public clsApplication()
        {
            ApplicationID = -1;
            ApplicationPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationStatus = enApplicationStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            ApplicationTypeID = -1;

            Mode = enMode.AddNew;
        }

        public clsApplication(int ApplicationID, int ApplicationPersonID, DateTime ApplicationDate, int ApplicationTypeID,
                                 enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {

            this.ApplicationID = ApplicationID;
            this.ApplicationPersonID = ApplicationPersonID;
            this.PersonInfo = clsPerson.Find(ApplicationPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationType.Find(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);

            this.Mode = enMode.Update;

        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(this.ApplicationPersonID, this.ApplicationDate, this.ApplicationTypeID, 
                (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(this.ApplicationID, this.ApplicationPersonID, this.ApplicationDate, this.ApplicationTypeID,
                (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public bool Save()
        {

            switch (this.Mode)
            {

                case enMode.AddNew:

                    if (_AddNewApplication())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplication();

            }

            return false;
        }

        public static clsApplication FindBaseApplication(int ApplicationID)
        {

            int ApplicationPersonID = -1, ApplicationTypeID = -1, CreatedByUserID = -1;
            float PaidFees = 0;

            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            byte ApplicationStatus = 0;

            bool IsFound = clsApplicationData.GetApplicationInfoByID(ApplicationID, ref ApplicationPersonID, ref ApplicationDate
                       , ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID);
            

             if(IsFound)
             {   

                return new clsApplication(ApplicationID, ApplicationPersonID, ApplicationDate
                       , ApplicationTypeID, (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
             }
             else
             {
                return null;
             }

        }

        public bool Delete()
        {
            return clsApplicationData.DeleteApplication(this.ApplicationID);
        }

        public bool Cancel()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, 2);
        }

  
        public bool SetComplete()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, 3);
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsApplicationData.IsApplicationExist(ApplicationID);
        }

        public static bool DoesPersonHaveActiveApplicationORCompletedApplication(int PersonID, int ApplicationTypeID)
        {
            return clsApplicationData.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }

        public bool DoesPersonHaveActiveApplicationORCompletedApplication(int ApplicationTypeID)
        {
            return clsApplicationData.DoesPersonHaveActiveApplication(this.ApplicationPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, clsApplication.enApplicationType applicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(PersonID, (int)applicationTypeID);
        }

        public  int GetActiveApplicationID(clsApplication.enApplicationType applicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(this.ApplicationPersonID, (int)applicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplication.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }
    }
}
