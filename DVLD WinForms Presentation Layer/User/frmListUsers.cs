using DVLD_Business_Layer;
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

namespace DVLD.User
{
    public partial class frmListUsers : Form
    {

        private static DataTable _dtAllUsers ;

        public frmListUsers()
        {
            InitializeComponent();
        }
        
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(cbFilterBy.Text == "Is Active")
            {

                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;

                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text!="None");
                cbIsActive.Visible = false;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtAllUsers;
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;
        

            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 110;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 120;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 350;

                dgvUsers.Columns[3].HeaderText = "User Name";
                dgvUsers.Columns[3].Width = 120;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 120;
            }

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumnName = "";

            switch (cbFilterBy.Text)
            {

                case "User ID":
                    FilterColumnName = "UserID";
                    break;

                case "Person ID":
                    FilterColumnName = "PersonID";
                    break;

                case "User Name":
                    FilterColumnName = "UserName";
                    break;

                case "Full Name":
                    FilterColumnName = "FullName";
                    break;

                case "Is Active":
                    FilterColumnName = "IsActive";
                    break;

                default:
                    FilterColumnName = "None";
                    break;

            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumnName == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
                return;
            }


            if (FilterColumnName != "FullName" || FilterColumnName != "UserName")
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumnName, txtFilterValue.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%' ",FilterColumnName, txtFilterValue.Text.Trim());


            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }


        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void cbFilterByActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumnName = "IsActive";
            string FilterValue = cbIsActive.Text;

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

            if (cbIsActive.Text == "All")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();
            }
            else
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumnName, FilterValue);
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
            }

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmShowUserInfo frm = new frmShowUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm  = new frmAddUpdateUser();
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete User with ID = " + (dgvUsers.CurrentRow.Cells[0].Value).ToString(),"Confirm Delete",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (clsUser.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Seccessfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListUsers_Load(null, null);
                }
                else
                {
                    MessageBox.Show("User Not Deleted because it has data linked do it ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }

            
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
