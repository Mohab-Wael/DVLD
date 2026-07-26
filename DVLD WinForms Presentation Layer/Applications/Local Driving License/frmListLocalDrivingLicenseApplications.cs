using DVLD.Applications;
using DVLD.DriverLicense;
using DVLD.Tests;
using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.DriverLicense;
using DVLD.Licenses;

namespace DVLD.Applications
{

    public partial class frmListLocalDrivingLicenseApplications : Form
    {

        private static DataTable _dtAllLocelDrivingLicenseApplications;


        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _dtAllLocelDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvLocalDrivingLicenseApplications.DataSource = _dtAllLocelDrivingLicenseApplications;
            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

            if (dgvLocalDrivingLicenseApplications.Rows.Count > 0)
            {

                dgvLocalDrivingLicenseApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicenseApplications.Columns[0].Width = 110;

                dgvLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplications.Columns[1].Width = 300;

                dgvLocalDrivingLicenseApplications.Columns[2].HeaderText = "National No.";
                dgvLocalDrivingLicenseApplications.Columns[2].Width = 140;

                dgvLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplications.Columns[3].Width = 440;

                dgvLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplications.Columns[4].Width = 170;

                dgvLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplications.Columns[5].Width = 160;

                dgvLocalDrivingLicenseApplications.Columns[6].HeaderText = "Status";
                dgvLocalDrivingLicenseApplications.Columns[6].Width = 120;
            }


        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
           
            _dtAllLocelDrivingLicenseApplications.DefaultView.RowFilter = "";
            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();

            //Refresh the list after adding new application
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumnName = "";

            switch (cbFilterBy.Text)
            {

                case "L.D.L.AppID":
                    FilterColumnName = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No.":
                    FilterColumnName = "NationalNo";
                    break;

                 case "Full Name":
                    FilterColumnName = "FullName";
                    break;

                case "Status":
                    FilterColumnName = "Status";
                    break;

                default:
                    FilterColumnName = "None";
                    break;
            }

            if (FilterColumnName == "None" || txtFilterValue.Text.Trim() == "")
            {
                _dtAllLocelDrivingLicenseApplications.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }


            if (FilterColumnName == "LocalDrivingLicenseApplicationID")
                _dtAllLocelDrivingLicenseApplications.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumnName, txtFilterValue.Text.Trim());
            else
                _dtAllLocelDrivingLicenseApplications.DefaultView.RowFilter = string.Format("{0} LIKE '%{1}%'", FilterColumnName, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();    
        }


        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            
            //Refresh
            frmListLocalDrivingLicenseApplications_Load(null, null);

        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            //Refresh
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Are you sure you want to cancel this application?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseAppID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            if (localDrivingLicenseApplication != null)
            {

                if(localDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("Application Cancelled successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("could not cancel application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No application with ID = " + dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Refresh
            frmListLocalDrivingLicenseApplications_Load(null, null);

        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this application?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = 
                clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseAppID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            if(localDrivingLicenseApplication!=null)
            {

                if(localDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Deleted Application Seccessfully.", "Deleted ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Refresh
                    frmListLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Local Driving License Application NOT Deleted Seccessfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Could not delete application, other date depends on it." , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "L.D.L.AppID")
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void _ScheduleTest(clsTestType.enTestType TestType)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmListTestAppoointments frm = new frmListTestAppoointments(LocalDrivingLicenseApplicationID, TestType);
            frm.ShowDialog();

            // Refresh Data 
            frmListLocalDrivingLicenseApplications_Load(null, null);


        }


        private void schduleVisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.VisionTest);
        }

        private void schdulewttitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.WrittenTest);
        }

        private void schduleStreetTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.StreetTest);
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDriverLicenseFirstTime frm = new frmIssueDriverLicenseFirstTime((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            //Refresh
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void ShowLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            int LicenseID = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseAppID(
               LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            int PersonID = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseAppID(LocalDrivingLicenseApplicationID).ApplicationPersonID;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = 
                clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseAppID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            int TotalPassedTests = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;
            bool LicenseExist = LocalDrivingLicenseApplication.IsLicenseIssued();

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = !LicenseExist && (TotalPassedTests == 3);

            editApplicationToolStripMenuItem.Enabled = !LicenseExist && LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New;
            deleteApplicationToolStripMenuItem.Enabled = !LicenseExist && LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New;
            cancelApplicationToolStripMenuItem.Enabled = !LicenseExist && LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New;

            ScheduleTestMenueToolStripMenuItem.Enabled = !LicenseExist;

            ShowLicenseToolStripMenuItem.Enabled = LicenseExist;

            bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest);
            bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.StreetTest);

            ScheduleTestMenueToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            if (ScheduleTestMenueToolStripMenuItem.Enabled)
            {
                schduleVisionToolStripMenuItem.Enabled = !PassedVisionTest;

                schdulewttitenToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                scheduleStreetTestsToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;
            }

        }
    }
}
