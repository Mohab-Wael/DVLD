using DVLD.Classes;
using DVLD.DriverLicense;
using DVLD_Business_Layer;
using DVLD.International_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Licenses;

namespace DVLD.Applications.InternationalLicense
{
    public partial class frmNewInternationalLicenseApplication : Form
    {

        private int _InternationalLicenseID = -1;
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees.ToString();
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {

            int SelectedLicenseID = obj;

            lblLocalLicenseID.Text = SelectedLicenseID.ToString();

            llShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                return;
            }

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassID != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("This license is Not Active, cannot issue international license.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int InternationalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if(InternationalLicenseID != -1)
            {
                MessageBox.Show("Person already has an active international license.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llShowLicensesInfo.Enabled = true;
                _InternationalLicenseID = InternationalLicenseID;
                btnIssueLicense.Enabled = false;
                return;
            }

            btnIssueLicense.Enabled = true;
        }

            
   

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Are you sure you want to issue the license?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsInternationalLicense InternationalLicense = new clsInternationalLicense();

            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationPersonID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees;
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            InternationalLicense.DriverID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            InternationalLicense.IsActive = true;
            InternationalLicense.IssueUsingLocalLicenseID = ctrlDriverLicenseInfoWithFilter1.LicenseID;
           
            if(!InternationalLicense.Save())
            {
                MessageBox.Show("Failed to issue international license.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            lblInternationalLicenseApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully With ID = " + InternationalLicense.InternationalLicenseID.ToString(), "License Issued",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssueLicense.Enabled = false;
            llShowLicensesInfo.Enabled = true;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
        }

        private void frmNewInternationalLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void llShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.Show();
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
