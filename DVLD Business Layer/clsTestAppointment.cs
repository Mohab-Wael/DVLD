using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public class clsTestAppointment
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;



        public int TestAppointmentID { get; set; }
        public clsTestType.enTestType TestTypeID = clsTestType.enTestType.VisionTest;
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public clsApplication RetakeTestApplicationInfo;

        public int TestID
        {
            get { return _GetTestID(); }
        }

        public clsTestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = clsTestType.enTestType.VisionTest;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;
            RetakeTestApplicationID = -1;

            Mode = enMode.AddNew;
        }
        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                 this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
        }


        public clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestTypeID,
            int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees,
            int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.RetakeTestApplicationInfo = clsApplication.FindBaseApplication(RetakeTestApplicationID);

            Mode = enMode.Update;
        }

      
        public bool Save()
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;



                    }

                case enMode.Update:

                    return _UpdateTestAppointment();

            }

            return false;
        }

        public static DataTable GetApplicationTestAppointmentPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID = -1, LocalDrivingLicenseApplicationID = -1, CreatedByUserID = -1, RetakeTestApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            float PaidFees = 0;
            bool IsLocked = false;

            if (clsTestAppointmentData.GetTestAppointmentInfoByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LocalDrivingLicenseApplicationID,
                    AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }
            else
            {
                return null;

            }
        }

        public static clsTestAppointment GetLastTestAppointment(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {

            int TestAppointmentID = -1, CreatedByUserID = -1, RetakeTestApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            float PaidFees = -1;
            bool IsLocked = false;

            if(clsTestAppointmentData.GetLastTestAppointmentInfo(    LocalDrivingLicenseApplicationID,  (int)TestTypeID, ref TestAppointmentID, ref AppointmentDate,
            ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees
                        , CreatedByUserID, IsLocked, RetakeTestApplicationID);

            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentData.GetAllTestAppointments();
        }

        private int _GetTestID()
        {
            return clsTestAppointmentData.GetTestID(TestAppointmentID);
        }

    }
}
