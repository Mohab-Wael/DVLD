using DVLD.Classes;
using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DriverLicense
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        private int _LocalDrivingLicenseID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmIssueDriverLicenseFirstTime(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            _LocalDrivingLicenseID = LocalDrivingLicenseID;
        }

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseAppID(_LocalDrivingLicenseID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License with ID = " + _LocalDrivingLicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!_LocalDrivingLicenseApplication.PassedAllTests())
            {
                MessageBox.Show("Person should pass all tests first.", "Not Allowed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
            if (LicenseID!=-1)
            {
                MessageBox.Show("Person already has a license before with ID = " + LicenseID, "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            ctrlLocalDrivingLicenseInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseID);
        }
        
        private void btnIssue_Click(object sender, EventArgs e)
        {

            int LicenseID = _LocalDrivingLicenseApplication.IssueLicenseForTheFirstTime(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (LicenseID!=-1)
            {

                MessageBox.Show("License Issued Successfully with license ID = " + LicenseID,
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was Not Issued !",
                   "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
          
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
