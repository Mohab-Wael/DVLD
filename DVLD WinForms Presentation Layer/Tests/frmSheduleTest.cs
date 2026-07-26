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
    public partial class frmScheduleTest : Form
    {
        int LocalDrivingLicenseID = -1;
        clsTestType.enTestType TestType = clsTestType.enTestType.VisionTest;
        int TestAppointmentID = -1;

        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType, int TestAppointmentID = -1)
        {
            InitializeComponent();
            this.LocalDrivingLicenseID = LocalDrivingLicenseApplicationID;
            this.TestType = TestType;
            this.TestAppointmentID = TestAppointmentID;
        }
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = TestType;
            ctrlScheduleTest1.LoadInfo(LocalDrivingLicenseID, TestAppointmentID);
        }
    }
}
