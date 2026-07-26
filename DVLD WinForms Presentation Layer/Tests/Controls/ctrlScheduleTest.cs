using DVLD.Classes;
using DVLD_Business_Layer;
using DVLD_WinForms_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class ctrlScheduleTest : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        public enum enCreationMode { FirstTimeTest = 0, RetakeTestSchedule = 1 }
        private enCreationMode _CreationMode;

        private clsTestType.enTestType _TestType;

        private int _LocalDrivingLicenseApplicationID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private int _TestAppointmentID;
        private clsTestAppointment _TestAppointment;

        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestType;
            }
            set
            {
                _TestType = value;

                switch (_TestType)
                {
                    case clsTestType.enTestType.VisionTest:
                        gbTest.Text = "Vision Test";
                        pbTestImage.Image = Resources.Vision_512;
                        break;

                    case clsTestType.enTestType.WrittenTest:
                        gbTest.Text = "Written Test";
                        pbTestImage.Image = Resources.Written_Test__512;
                        break;

                    case clsTestType.enTestType.StreetTest:
                        gbTest.Text = "Street Test";
                        pbTestImage.Image = Resources.driving_test_512;
                        break;

                }
            }
        }


        public ctrlScheduleTest()
        {
            InitializeComponent();
        }


        public void LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {

            if (AppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseAppID(LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Local Driving License Application not found with ID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false; 
                return;
            }

            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestType))
            {
                _CreationMode = enCreationMode.RetakeTestSchedule;
            }
            else
            {
                _CreationMode = enCreationMode.FirstTimeTest;
            }

            if(_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeAppFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).Fees.ToString();
                lblRetakeTestAppID.Text = "0";
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";    
            }

            lblDrivingApplicationID.Text = _LocalDrivingLicenseApplicationID.ToString();    
            lblClassName.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.LicenseClassName;
            lblPersonName.Text = _LocalDrivingLicenseApplication.PersonFullName;
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTestType(_TestType).ToString();
            
            if(_Mode == enMode.AddNew)
            {
                dtpTestDate.MinDate = DateTime.Now;
                dtpTestDate.Value = DateTime.Now;
                lblFees.Text = clsTestType.Find(_TestType).Fees.ToString();
                lblRetakeTestAppID.Text = "N/A";

                _TestAppointment = new clsTestAppointment();
            }
            else
            {

                if (!_LoadTestAppointmentData())
                    return;

            }

            lblTotalFees.Text =( Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeAppFees.Text) ).ToString();


            if(!_HandleActiveTestAppointmentConstraint())
                return;

            if(!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePreviousTestConstraint())
                return;

        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("No Appointment with ID = " + _TestAppointmentID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _TestAppointment.PaidFees.ToString();

            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
            {
                dtpTestDate.MinDate = DateTime.Now;
            }
            else
            {
                dtpTestDate.MinDate = _TestAppointment.AppointmentDate;
            }

            dtpTestDate.Value = _TestAppointment.AppointmentDate;

            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRetakeTestAppID.Text = "N/A";
                lblRetakeAppFees.Text = "0";
                gbRetakeTestInfo.Enabled = false;
            }
            else
            {
                gbRetakeTestInfo.Enabled = true;
                lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
                lblRetakeAppFees.Text = _TestAppointment.RetakeTestApplicationInfo.PaidFees.ToString();
                lblTitle.Text = "Schedule Retake Test";
            }

            return true;
        }

        private bool _HandleActiveTestAppointmentConstraint()
        {

            if(_Mode == enMode.AddNew && _LocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                lblUserMessage.Text = "Person already has an active appointment for this test.";
                dtpTestDate.Enabled = false;
                btnSave.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {

            if(_Mode == enMode.Update && _TestAppointment.IsLocked)
            {
                dtpTestDate.Enabled = false;
                btnSave.Enabled = false;
                lblUserMessage.Text = "Person already sat for the test, appointment is locked.";
                lblUserMessage.Visible = true;
                return false;
            }
            else
                lblUserMessage.Visible = false;

            return true;
        }

        private bool _HandlePreviousTestConstraint()
        {

            switch(_TestType)
            {

                case clsTestType.enTestType.VisionTest:

                    lblUserMessage.Visible = false;

                    return true;

                    case clsTestType.enTestType.WrittenTest:

                      if(!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest))
                      {
                        lblUserMessage.Text = "Cannot Schedule, Vision Test should be passed first.";
                        lblUserMessage.Visible = true;  
                        dtpTestDate.Enabled = false;
                        btnSave.Enabled = false;
                        return false;
                      }
                     else
                     {
                        lblUserMessage.Visible = false;
                        dtpTestDate.Enabled = true;
                        btnSave.Enabled = true;
                     }

                      return true;

                case clsTestType.enTestType.StreetTest:

                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest))
                    {
                       lblUserMessage.Text = "Cannot Schedule, Written Test should be passed first.";
                       lblUserMessage.Visible = true;
                       dtpTestDate.Enabled = false;
                       btnSave.Enabled = false;
                       return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        dtpTestDate.Enabled = true;
                        btnSave.Enabled = true;
                    }

                    return true;
            }

            return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeTestConstraint())
                return;

            _TestAppointment.TestTypeID = _TestType;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblTotalFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _TestAppointment.IsLocked = false;

            if(_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saves", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is Not Saved Successfully.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private bool _HandleRetakeTestConstraint()
        {

            if(_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {

                clsApplication Application = new clsApplication();

                Application.ApplicationStatus = clsApplication.enApplicationStatus.New;
                Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationPersonID = _LocalDrivingLicenseApplication.ApplicationPersonID;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).Fees;
                Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if(!Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;

              return true;  
            }

            return true;

        }
    }
}
