using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmAddUpdateUser : Form
    {
        enum enMode { AddNew=0,Update=1};
        enMode _Mode;

        private int _UserID = -1;
        private clsUser _User;

        public frmAddUpdateUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;

            _Mode = enMode.Update;
        }


        private void _ResetDefaultValues()
        {

            if(_Mode == enMode.AddNew)
            {

                lblTitle.Text = "Add New User";
                this.Text = "Add New User";

                _User = new clsUser();

                tpLoginInfo.Enabled = false;
                btnSave.Enabled = false;

                ctrlPersonCardWithFilter1.FilterFocus();

            }
            else
            {
                lblTitle.Text = "Update User";
                this.Text = "Update User";


                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }

            lblUserID.Text = "???";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cbIsActive.Checked = true;
        }


        private void _LoadData()
        {

            _User = clsUser.FindByUserID(_UserID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show("No user with user ID = " + _UserID, "User Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;
            }


            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName.ToString();
            txtPassword.Text = _User.Password.ToString();
            txtConfirmPassword.Text = _User.Password.ToString();
            cbIsActive.Checked = _User.IsActive;
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
        }


        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {

            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valide!, put mouse over the red icon(s) to see error", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.IsActive = cbIsActive.Checked;

            if (_User.Save())
            {
                lblTitle.Text = "Update User";
                lblUserID.Text = _User.UserID.ToString();
                this.Text = "Update User";

                _Mode = enMode.Update;

                MessageBox.Show("Data saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnNext_Click(object sender, EventArgs e)
        {

            if(_Mode == enMode.Update)
            {
                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                return;
            }



            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                if (clsUser.IsUserExistForPersonID(ctrlPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.FilterFocus();
                }


                else
                {
                    tpLoginInfo.Enabled = true;
                    btnSave.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                }

            }


            else
            {
                MessageBox.Show("Please select a person", "Selected a person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }

          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation Does Not Match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }

            if (_Mode == enMode.AddNew)
            {
                if (clsUser.IsUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "Username is used by another user!");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }
            }
            else
            {

                if (_User.UserName != txtUserName.Text.Trim())
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "Username is used by another user!");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }

            }



        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank!");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }

        }

        private void frmAddUpdateUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }

    
    }
}

