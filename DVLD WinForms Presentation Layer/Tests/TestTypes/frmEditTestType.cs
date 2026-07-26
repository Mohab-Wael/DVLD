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
using DVLD.Classes;

namespace DVLD.Tests
{
    public partial class frmEditTestType : Form
    {

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private clsTestType _TestType;

        public frmEditTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.Find(_TestTypeID);

            if (_TestType != null)
            {
                lblID.Text = ((int)_TestType.ID).ToString();
                txtTitle.Text = _TestType.Title;
                txtDescription.Text = _TestType.Description;
                txtFees.Text = _TestType.Fees.ToString();

            }
            else
            {
                MessageBox.Show("No Test Type with ID = " + _TestTypeID.ToString(), "Test Type Not Found!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valide, put mouse over icon(s) to see error.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType.Title = txtTitle.Text.Trim();
            _TestType.Description = txtDescription.Text.Trim();
            _TestType.Fees = Convert.ToSingle(txtFees.Text.Trim());


            if (_TestType.Save())
                MessageBox.Show("Data Saved Successfully.", "Saved",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error: Data is Not saved", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
            ;
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Description cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }
            ;
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFees, null);

            }
            ;


            if (!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
            ;
        }

        
    }
}
