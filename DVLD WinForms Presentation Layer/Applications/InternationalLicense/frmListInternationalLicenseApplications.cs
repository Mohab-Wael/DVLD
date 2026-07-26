using DVLD.International_License;
using DVLD.Licenses;
using DVLD.People;
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

namespace DVLD.Applications.InternationalLicense
{
    public partial class frmListInternationalLicenseApplications : Form
    {

        private DataTable _dtAllInternationalLicenseApplications;

        public frmListInternationalLicenseApplications()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
            // Refresh
            frmListInternationalLicenseApplications_Load(null, null);
        }

        private void ShowPersonDetailstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicenseApplications.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;

            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }

        private void ShowLicenseDetailstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvInternationalLicenseApplications.CurrentRow.Cells[0].Value;
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(InternationalLicenseID);
            frm.ShowDialog();
        }

        private void frmListInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            _dtAllInternationalLicenseApplications = clsInternationalLicense.GetAllInternationalLicenses();
            cbFilterBy.SelectedIndex = 0;
        
            dgvInternationalLicenseApplications.DataSource = _dtAllInternationalLicenseApplications;
            lblCountRecords.Text = dgvInternationalLicenseApplications.Rows.Count.ToString();

            if(dgvInternationalLicenseApplications.Rows.Count > 0)
            {

                dgvInternationalLicenseApplications.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenseApplications.Columns[0].Width = 160;

                dgvInternationalLicenseApplications.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenseApplications.Columns[1].Width = 150;

                dgvInternationalLicenseApplications.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenseApplications.Columns[2].Width = 130;

                dgvInternationalLicenseApplications.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenseApplications.Columns[3].Width = 130;

                dgvInternationalLicenseApplications.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenseApplications.Columns[4].Width = 180;

                dgvInternationalLicenseApplications.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenseApplications.Columns[5].Width = 180;

                dgvInternationalLicenseApplications.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenseApplications.Columns[6].Width = 120;

            }

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.SelectedIndex = 0;
                cbIsReleased.Focus();
            }
            else
            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsReleased.Visible = false;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {

                case "All":
                    break;

                case "Yes":
                    FilterValue = "1";
                    break;

                case "No":
                    FilterValue = "0";
                    break;

            }

            if(FilterValue == "All")
                _dtAllInternationalLicenseApplications.DefaultView.RowFilter = "";
           else
                _dtAllInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}",FilterColumn, FilterValue);


            lblCountRecords.Text = _dtAllInternationalLicenseApplications.Rows.Count.ToString();

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilterBy.Text;

            switch(FilterColumn)
            {

                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;

                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (FilterColumn == "None" || txtFilterValue.Text == "")
                _dtAllInternationalLicenseApplications.DefaultView.RowFilter = "";
            else
                _dtAllInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());


            lblCountRecords.Text = _dtAllInternationalLicenseApplications.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
        }

        private void ShowPersonLicenseHistorytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicenseApplications.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
