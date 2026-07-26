using DVLD.Classes;
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

namespace DVLD.Applications {

    public partial class frmEditApplicationType : Form
    {

        private int _ApplicationTypeID = -1;
        private clsApplicationType _ApplicationType;

        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;

        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
              lblApplicationTypeID.Text = _ApplicationTypeID.ToString();
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);
        
            if (_ApplicationType != null)
            {

              txtTitle.Text = _ApplicationType.Title;
              txtFees.Text = _ApplicationType.Fees.ToString();
               
            }

           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationType.Title = txtTitle.Text.Trim();
            _ApplicationType.Fees = float.Parse(txtFees.Text.Trim());

            if (_ApplicationType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Does Not saved Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

     
        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {

            if(string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be blank!");
            }
            else
            {
              errorProvider1.SetError(txtTitle, null);
                
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Fees cannot be blank!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);

            }

            if (!clsValidation.IsNumber(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid number!");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
        }

        
    }
}
