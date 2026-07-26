using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { set; get; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo;

        public string PersonFullName
        {
            get
            {
                return this.PersonInfo.FullName;
            }
        }

        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;

            Mode = enMode.AddNew;
        }

        public clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int LicenseClassID, int ApplicationID, int ApplicationPersonID,
                                        int ApplicationTypeID, DateTime ApplicationDate, enApplicationStatus ApplicationStatus,
                                        DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicationPersonID = ApplicationPersonID;
            this.PersonInfo = clsPerson.Find(ApplicationPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationType.Find(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            Mode = enMode.Update;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(this.ApplicationID,
                this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID,
                              this.LocalDrivingLicenseApplicationID, this.LicenseClassID);
        }

        public bool Save()
        {

            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
            {
                return false;
            }

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLocalDrivingLicenseApplication();

            }

            return false;


        }

        public static bool IsLocalDrivingLicenseApplicationExist(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.IsLocalDrivingLicenseApplicationExist(LocalDrivingLicenseApplicationID);
        }

        public static clsLocalDrivingLicenseApplication FindByLocalDrivingLicenseAppID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID,
                                              ref ApplicationID, ref LicenseClassID);

            
            
            
            
            
            if (IsFound)
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, LicenseClassID,
                    Application.ApplicationID,
                    Application.ApplicationPersonID,
                    Application.ApplicationTypeID,
                    Application.ApplicationDate,
                    Application.ApplicationStatus,
                    Application.LastStatusDate,
                    Application.PaidFees,
                    Application.CreatedByUserID);
            }
            else
            {
                return null;
            }

        }
        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseByApplicationID(int ApplicationID)
        {

            int LocalDrivingLicenseID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID(ApplicationID,
                ref LocalDrivingLicenseID, ref LicenseClassID);

            if (IsFound)
            {

                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseID, LicenseClassID, ApplicationID,
                    Application.ApplicationPersonID,
                    Application.ApplicationTypeID,
                    Application.ApplicationDate,
                    Application.ApplicationStatus,
                    Application.LastStatusDate,
                    Application.PaidFees,
                    Application.CreatedByUserID
                              );
            }
            else
            {
                return null;
            }


        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GettAllLocalDrivingLicenseApplications();
        }

        public bool Delete()
        {
            bool IsLocalDrivingLicenseApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;

            IsLocalDrivingLicenseApplicationDeleted = clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID);

            if (!IsLocalDrivingLicenseApplicationDeleted)
            { return false; }


            IsBaseApplicationDeleted = base.Delete();
            return IsBaseApplicationDeleted;
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTest.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public byte GetPassedTestCount()
        {
            return clsTest.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }

        public bool PassedAllTests()
        {
            return clsTest.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseID)
        {
            return clsTest.PassedAllTests(LocalDrivingLicenseID);
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestType);
        }

        public  bool DoesAttendTestType(clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestType);
        }

        public static byte TotalTrialsPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTestType(LocalDrivingLicenseApplicationID, (int)TestType);
        }

        public byte TotalTrialsPerTestType(clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTestType(this.LocalDrivingLicenseApplicationID, (int)TestType);
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestType);
        }

        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestType);
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestType);
        }   

        public bool DoesPassTestType(clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestType);
        }

        public clsTest GetLastTestPerTestType(clsTestType.enTestType TestType)
        {
            return clsTest.FindLastTestPerPersonLicenseClassPerTestType(this.ApplicationPersonID, this.LicenseClassID, TestType);
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {
            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicationPersonID, this.LicenseClassID);
        }

        public int IssueLicenseForTheFirstTime(string Notes, int CreatedByUserID)
        {

            int DriverID = -1;

            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicationPersonID);

            if (Driver == null)
            {
                Driver = new clsDriver();

                Driver.PersonID = this.ApplicationPersonID;
                Driver.CreatedDate = DateTime.Now;
                Driver.CreatedByUserID = CreatedByUserID;

                if(Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }

            }
            else
            {
                DriverID = Driver.DriverID;
            }

            clsLicense License = new clsLicense();

            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClassID = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = clsLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if(License.Save())
            {
                this.SetComplete();

                return License.LicenseID;
            }
            else
            {
                return -1;
            }
        }
    }
}
