using DVLD.Classes;
using DVLD.DriverLicense;
using DVLD.Licenses;
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

namespace DVLD.Applications.ReplaceLostOrDamagedLicense
{
    public partial class frmReplaceLostOrDamagedLicenseApplication : Form
    {
        private int _NewLicenseID = -1;

        public frmReplaceLostOrDamagedLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int _GetApplicationTypeID()
        {

            if (rbDamagedLicense.Checked)
                return (int)clsApplication.enApplicationType.ReplacementforDamagedDrivingLicense;
            else
                return (int)clsApplication.enApplicationType.ReplacementforLostDrivingLicense;

        }

        private clsLicense.enIssueReason _GetIssueReason()
        {

            if (rbDamagedLicense.Checked)
                return clsLicense.enIssueReason.DamagedReplacement;
            else
                return clsLicense.enIssueReason.LostReplacement;

        }
        private void frmReplaceLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            this.Text = "Replacement For Damaged License";
            lblTitle.Text = this.Text;
            rbDamagedLicense.Checked = true;
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
          
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {

            int SelectedLicenseID = obj;

            llShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            if(SelectedLicenseID == -1)
            {
                return;
            }

            lblOldLicenseID.Text = SelectedLicenseID.ToString();

            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }

            btnIssueReplacement.Enabled = true; 
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {

            clsLicense NewLicense = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Replace(_GetIssueReason(), clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Failed to Replacement License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _NewLicenseID = NewLicense.LicenseID;
            lblNewLicenseID.Text = NewLicense.LicenseID.ToString();
            MessageBox.Show("Licensed Replaced Successfully with ID = " + NewLicense.LicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblApplicationID.Text = NewLicense.ApplicationID.ToString();

            llShowNewLicenseInfo.Enabled = true;
            btnIssueReplacement.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
           lblApplicationFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).Fees.ToString();
           lblTitle.Text = "Replacement For Damaged License";
           this.Text = lblTitle.Text;
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblApplicationFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).Fees.ToString();
            lblTitle.Text = "Replacement For Lost License";
            this.Text = lblTitle.Text;
        }

        private void frmReplaceLostOrDamagedLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
