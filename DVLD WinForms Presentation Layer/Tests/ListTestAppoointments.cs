using DVLD_Business_Layer;
using DVLD_WinForms_Presentation_Layer.Properties;
using DVLD.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Tests
{
    public partial class frmListTestAppoointments : Form
    {

        private DataTable _dtAllTestAppointmentsForApplication;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;

        public frmListTestAppoointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;
        }

        private void _LoadTestTypeImageAndTitle()
        {

            switch (_TestType)
            {

                case clsTestType.enTestType.VisionTest:

                    lblTitle.Text = "Vision Test Appointments";
                    this.Text = lblTitle.Text;
                    pbTestImage.Image = Resources.Vision_512;
                    break;

                case clsTestType.enTestType.WrittenTest:

                    this.Text = lblTitle.Text;
                    pbTestImage.Image = Resources.Written_Test__512;
                    break;

                case clsTestType.enTestType.StreetTest:
           
                    lblTitle.Text = "Street Test Appointments";
                    this.Text = lblTitle.Text;
                    pbTestImage.Image = Resources.driving_test_512;
                    break;

            }

        }

 

        private void ListTestAppoointments_Load(object sender, EventArgs e)
        {
         
            _LoadTestTypeImageAndTitle();

            ctrlLocalDrivingLicenseInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
            _dtAllTestAppointmentsForApplication = clsTestAppointment.GetApplicationTestAppointmentPerTestType(_LocalDrivingLicenseApplicationID,_TestType);
            dgvLicenseTestAppointments.DataSource = _dtAllTestAppointmentsForApplication;

            if (dgvLicenseTestAppointments.Rows.Count > 0)
            {

                dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvLicenseTestAppointments.Columns[0].Width = 150;

                dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvLicenseTestAppointments.Columns[1].Width = 200;
                dgvLicenseTestAppointments.Columns[1].DefaultCellStyle.Format = "M/d/yyyy h:mm tt";

                dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvLicenseTestAppointments.Columns[2].Width = 150;

                dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
                dgvLicenseTestAppointments.Columns[3].Width = 100;
            }

            lblRecordsCount.Text = dgvLicenseTestAppointments.Rows.Count.ToString();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseAppID(_LocalDrivingLicenseApplicationID);

            if(localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person already have an active appointment, You cannot add new appointment for this test.", "Not allowed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTest LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(_TestType);

            if(LastTest == null)
            {
                frmScheduleTest frm1 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
                frm1.ShowDialog();
                ListTestAppoointments_Load(null, null);
                return;
            }

            if(LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake failed test", "Not Allowed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm2 = new frmScheduleTest(LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestType);
            frm2.ShowDialog();
            ListTestAppoointments_Load(null, null);

        }

        private void edittoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            
        }

        private void TakeTesttoolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmTakeTest frm = new frmTakeTest((int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value,_TestType);
            frm.ShowDialog();

            //Refresh the data after taking the test
            ListTestAppoointments_Load(null, null);

        }
    }
}
