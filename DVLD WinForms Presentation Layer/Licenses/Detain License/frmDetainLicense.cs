using DVLD.Classes;
using DVLD.DriverLicense;
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

namespace DVLD.Licenses.Detain_License
{
    public partial class frmDetainLicense : Form
    {
        private int _DetainID = -1;
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            txtFineFees.Text = "";
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void frmDetainLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            llShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            lblLicenseID.Text = SelectedLicenseID.ToString();

            if(SelectedLicenseID == -1)
            {
                return;
            }

            if(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is already detained, choose another one.", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is Not Active, choose another one.", "Not Allowed",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtFineFees.Focus();
            btnDetainLicense.Enabled = true;

            
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(ctrlDriverLicenseInfoWithFilter1.LicenseID);
            frm.ShowDialog();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Are you sure you want to Detain this license?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _DetainID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text.Trim()), clsGlobal.CurrentUser.UserID);

            if (_DetainID == -1)
            {
                MessageBox.Show("Failed to Detain License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID = " + _DetainID.ToString(), "Detained License", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnDetainLicense.Enabled = false;
            txtFineFees.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;

          


        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
           
            if(string.IsNullOrEmpty(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fees cannot be empty !");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFineFees, null);
            }

            if(!clsValidation.IsNumber(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Invalide Number.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFineFees, null);
            }
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
