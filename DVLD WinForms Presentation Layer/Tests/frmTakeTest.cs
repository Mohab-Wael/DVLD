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

namespace DVLD.Tests
{
    public partial class frmTakeTest : Form
    {
        private int _TestAppointmentID;
        private clsTestAppointment _TestAppointment;

        private clsTestType.enTestType _TestType;

        private int _TestID = -1;
        private clsTest _Test;

        public frmTakeTest(int TestAppointmentID, clsTestType.enTestType TestType)   
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID; 
            _TestType = TestType;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
           ctrlScheduledTest1.TestType = _TestType;
           ctrlScheduledTest1.LoadInfo(_TestAppointmentID);
            
           if(ctrlScheduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
      
           int TestID = ctrlScheduledTest1.TestID;
            if (TestID != -1)
            {
                _Test = clsTest.Find(TestID);

                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;

                txtNotes.Text = _Test.Notes;

                rbPass.Enabled = false;
                rbFail.Enabled = false;
                btnSave.Enabled = false;
                lblUserMassege.Visible = true;
            }
            else
            {
                lblUserMassege.Visible = false;
                rbPass.Enabled = true;
                rbFail.Enabled = true;
                btnSave.Enabled = true;
                _Test = new clsTest();
            }


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
          
            if(MessageBox.Show("Are you sure you want to save the test result?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _Test.TestAppointmentID = ctrlScheduledTest1.TestAppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            
            if(_Test.Save())
            {
                MessageBox.Show("Test result saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Test result Not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
