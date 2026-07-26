using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmChangePassword : Form
    {
        private int _UserID = -1;
        private clsUser _User;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;

          
        }

        private void _ResetDefaultValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }


        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            _User = clsUser.FindByUserID(_UserID);

            if(_User == null)
            {
                MessageBox.Show("Could not Find User with id = " + _UserID,
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            ctrlUserCard1.LoadUserInfo(_UserID);
        }
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
        
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current Password cannot be blank!");
                return;
              
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }


            if (txtCurrentPassword.Text.Trim() != _User.Password.Trim())
            {
                e.Cancel= true;
                errorProvider1.SetError(txtCurrentPassword, "Current Password is wrong!");
                return;
               
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }


           
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New Password cannot be blank!");
                return;
            }
            else
            {
               errorProvider1.SetError(txtNewPassword, null);

            }

            if(txtNewPassword.Text.Trim() == _User.Password.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New Password cannot be Current Password!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);

            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Confrimation Password cannot be blank!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);

            }


            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match New Password!");
                return;

            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("some fields are not valid!, put mouse over red icon(s) to see error!",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = txtNewPassword.Text.Trim();

            if(_User.Save())
            {
                MessageBox.Show("Password Changed Successfully.", "Saved", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
               _ResetDefaultValues();
            }
            else
            {
                MessageBox.Show("An Error Occurred, Password did not Change", "Error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Activated(object sender, EventArgs e)
        {
            txtCurrentPassword.Focus();
        }
    }
}
