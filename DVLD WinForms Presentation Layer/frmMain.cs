using DVLD.Classes;
using DVLD.Login;
using DVLD.People;
using DVLD.User;
using DVLD.Applications;
using DVLD.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Tests;
using DVLD.Applications;
using DVLD.Applications.InternationalLicense;
using DVLD.Applications.Renew_Local_License;
using DVLD.Applications.ReplaceLostOrDamagedLicense;
using DVLD.Licenses.Detain_License;
using DVLD.Applications.Release_Detained_License;
using DVLD_WinForms_Presentation_Layer.Drivers;
namespace DVLD_WinForms_Presentation_Layer
{
    public partial class frmMain : Form
    {
        private frmLogin _frmLogin;
        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;
        }

        private void tsmiPeople_Click(object sender, EventArgs e)
        {
            frmListPeople frm = new frmListPeople();
            frm.ShowDialog();
        }

        private void tsmUsers_Click(object sender, EventArgs e)
        {
            frmListUsers frm = new frmListUsers();
            frm.ShowDialog();
        }

        private void SignOuttoolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            this.Close();
            _frmLogin.Show();
        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void CurrentUserInfotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo frm = new frmShowUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void ManageApplicationTypestoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm = new frmListApplicationTypes();
            frm.ShowDialog();
        }

        private void ManageTestTypestoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes frm = new frmListTestTypes();
            frm.ShowDialog();
        }

        private void newDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications frm = new frmListLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void ManageApplicationstoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications frm = new frmListLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void InternationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenseApplications frm = new frmListInternationalLicenseApplications();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalLicenseApplication frm = new frmRenewLocalLicenseApplication();
            frm.ShowDialog();
        }

        private void replacementForALostDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicenseApplication frm = new frmReplaceLostOrDamagedLicenseApplication();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();
        }

        private void tsmDrivers_Click(object sender, EventArgs e)
        {
            frmListDrivers frm = new frmListDrivers();
            frm.ShowDialog();
        }
    }
}
