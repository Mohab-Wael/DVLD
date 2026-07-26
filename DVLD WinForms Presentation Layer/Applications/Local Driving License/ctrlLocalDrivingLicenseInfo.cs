using DVLD_Business_Layer;
using DVLD.DriverLicense;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Controls.ApplicationControls 
{
    public partial class ctrlLocalDrivingLicenseInfo : UserControl
    {

        private int _LocalDrivingLicenseApplicationID = -1;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public int DrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }

        public ctrlLocalDrivingLicenseInfo()
        {
            InitializeComponent();
        }

        public ctrlLocalDrivingLicenseInfo(int DrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = DrivingLicenseApplicationID;
        }

        public void ResetLocalDrivingLicenseApplicationInfo()
        {
            ctrlApplicationBasicInfo1.ResetDefaultValues();
            _LocalDrivingLicenseApplicationID = -1;
            lblDrivingLicenseApplicationID.Text = "[???]";  
            lblAppliedFor.Text = "[???]";
            lblPassedTestsCounter.Text = "0";
        }

        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseAppID(LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("No  application with id = " + LocalDrivingLicenseApplicationID, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();

        }

        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByApplicationID(ApplicationID);

            if(_LocalDrivingLicenseApplication == null)
            {
                ResetLocalDrivingLicenseApplicationInfo();

                MessageBox.Show("No  application with id = " + ApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();

        }


        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);
            lblDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedFor.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.LicenseClassName;
            lblPassedTestsCounter.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString() + "/3";
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int LicenseID = clsLicense.FindByApplicationID(_LocalDrivingLicenseApplication.ApplicationID).LicenseID;

            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }
    }
}
