using DVLD.Applications.InternationalLicense;
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

namespace DVLD_WinForms_Presentation_Layer.Drivers
{
    public partial class frmListDrivers : Form
    {

        private DataTable _dtAllDrivers;

        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {

            _dtAllDrivers = clsDriver.GetAllDrivers();
            dgvListDrivers.DataSource = _dtAllDrivers;

            lblRecordsCount.Text = dgvListDrivers.Rows.Count.ToString();

            cbFilterBy.SelectedIndex = 0;
            cbFilterBy.Focus();

            if(dgvListDrivers.Rows.Count > 0)
            {

                dgvListDrivers.Columns[0].HeaderText = "Driver ID";
                dgvListDrivers.Columns[0].Width = 120;

                dgvListDrivers.Columns[1].HeaderText = "Person ID";
                dgvListDrivers.Columns[1].Width = 120;

                dgvListDrivers.Columns[2].HeaderText = "National No.";
                dgvListDrivers.Columns[2].Width = 140;

                dgvListDrivers.Columns[3].HeaderText = "Full Name";
                dgvListDrivers.Columns[3].Width = 320;

                dgvListDrivers.Columns[4].HeaderText = "Date";
                dgvListDrivers.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy h:mm tt";
                dgvListDrivers.Columns[4].Width = 180;

                dgvListDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvListDrivers.Columns[5].Width = 150;

            }

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");


            if (cbFilterBy.Text == "None")
                txtFilterValue.Enabled = false;
            else
                txtFilterValue.Enabled = true;


             txtFilterValue.Text = "";
            txtFilterValue.Focus();
            
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            
            }

            if(FilterColumn == "None" || txtFilterValue.Text == "")
            {
                _dtAllDrivers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvListDrivers.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "DriverID" || FilterColumn == "PersonID")
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilterValue.Text.Trim());


            lblRecordsCount.Text = dgvListDrivers.Rows.Count.ToString();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvListDrivers.CurrentRow.Cells[1].Value;

            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
            //Refresh
            frmListDrivers_Load(null, null);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
               e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvListDrivers.CurrentRow.Cells[0].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
