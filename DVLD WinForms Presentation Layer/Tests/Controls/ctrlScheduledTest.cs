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
    public partial class ctrlScheduledTest : UserControl
    {

  
        int _LocalDrivingLicenseApplicationID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        clsTestType.enTestType _TestType;

        int _TestAppointmentID = -1;
        clsTestAppointment _TestAppointment;

        int _TestID = -1;
        clsTest _Test;

        public clsTestType.enTestType TestType
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

        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }

        public int TestID
        {
            get
            {
                return _TestID;
            }
        }

        public ctrlScheduledTest()
        {
            InitializeComponent();
          
        }

        public void LoadInfo(int TestAppointmentID)
        {

            _TestAppointment = clsTestAppointment.Find(TestAppointmentID);
            if(_TestAppointment == null)
            {
                MessageBox.Show("Test Appointment not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestAppointmentID = TestAppointmentID;
            _TestID = _TestAppointment.TestID;

            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseAppID(_LocalDrivingLicenseApplicationID);

            if(_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Local Driving License Application not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDrivingApplicationID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblClassName.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.LicenseClassName;
            lblPersonName.Text = _LocalDrivingLicenseApplication.PersonFullName;
            lblTrials.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTestType(_TestType).ToString();
            lblAppointmentDate.Text = clsFormat.DateToShort(_TestAppointment.AppointmentDate);
            lblFees.Text = _TestAppointment.PaidFees.ToString();

            lblTestID.Text = (_TestAppointment.TestID == -1)? "Not Taken Yet" : _TestAppointment.TestID.ToString();
        }


    }
}
