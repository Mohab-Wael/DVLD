using DVLD;
using DVLD.Classes;
using DVLD_Business_Layer;
using DVLD_WinForms_Presentation_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD.Login
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            string Username = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref Username, ref Password))
            {
                txtUserName.Text = Username;
                txtPassword.Text = Password;
                cbRememberMe.Checked = true;
            }
            else
                cbRememberMe.Checked = false;
           

        }

   
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are Not valide!, put mouse over icon(s) to see error!", "Validation Error");
                return;
            }

            string HashedPassword = null;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashbytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(txtPassword.Text));

                 HashedPassword = BitConverter.ToString(hashbytes).Replace("-", "").ToLower();
            }

            clsUser User = clsUser.FindUsernameAndPassword(txtUserName.Text.Trim(), HashedPassword);

            if(User!=null)
            {

                if(cbRememberMe.Checked)
                {

                    clsGlobal.RememberUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                }
                else
                {
                    clsGlobal.RememberUserNameAndPassword("", "");
                }

                if(!User.IsActive)
                {
                    MessageBox.Show("User account is Not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                clsGlobal.CurrentUser = User;
                clsGlobal.StoreLoginRegister(User.UserName, User.IsActive);

                this.Hide();
                frmMain frm = new frmMain(this);
                frm.Show();

            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/password!", "Wrong credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {

            if(string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                errorProvider1.SetError(txtUserName, "Username cannot be blank!");
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtPassword, "Password cannot be blank!");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }
    }
}
