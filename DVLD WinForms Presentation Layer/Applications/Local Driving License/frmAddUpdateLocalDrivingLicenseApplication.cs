using DVLD.Classes;
using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        enum enMode { AddNew=0,Update=1};
        enMode _Mode;

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _SelectedPersonID = -1;
       
        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
           
        }

        public frmAddUpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _Mode = enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            FillLicenseClassesNameInComboBox();

            if(_Mode == enMode.AddNew)
            {
                this.Text = "New Local Driving License Application";        
                lblTitle.Text = "New Local Driving License Application";
                tpApplicationInfo.Enabled = false;
                btnSave.Enabled = false;
                ctrlPersonCardWithFilter1.Enabled = true;
                ctrlPersonCardWithFilter1.FilterFocus();
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();

                cbLicenseClass.SelectedIndex = 2;
                lblFees.Text = clsApplicationType.Find((int) clsApplication.enApplicationType.NewLocalDrivingLicense).Fees.ToString();
                lblDate.Text = DateTime.Now.ToString("dd/M/yyyy");
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                this.Text = "Update Local Driving License Application";
                lblTitle.Text = "Update Local Driving License Application";
                tpApplicationInfo.Enabled = true;
            }


        }

        private void FillLicenseClassesNameInComboBox()
        {

            DataTable dtAllLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            foreach(DataRow row in dtAllLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }


      

        private void _LoadData()
        {
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseAppID(_LocalDrivingLicenseApplicationID);

            if(_LocalDrivingLicenseApplication == null )
            {
                MessageBox.Show("No Application ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicationPersonID);
            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();
            lblDate.Text = clsFormat.DateToShort(_LocalDrivingLicenseApplication.ApplicationDate);
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString( clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).LicenseClassName );
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedBy.Text = _LocalDrivingLicenseApplication.CreatedByUserInfo.UserName;

        }


        private void frmAddUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {

            _ResetDefaultValues();

            if(_Mode == enMode.Update)
                _LoadData();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

           int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;

           int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewLocalDrivingLicense, LicenseClassID);

           if(ActiveApplicationID!=-1)
           {
                MessageBox.Show("Choose another license class, the selected person have Already an active application for the selected class with ID = " + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
           }

            //check if user already have issued license of the same driving  class.
            //if (clsLicense.IsLicenseExistByPersonID(ctrlPersonCardWithFilter1.PersonID, LicenseClassID))
            //{

            //    MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            _LocalDrivingLicenseApplication.ApplicationPersonID = ctrlPersonCardWithFilter1.PersonID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.NewLocalDrivingLicense;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;
            
            if(_LocalDrivingLicenseApplication.Save())
            {
                lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;

                MessageBox.Show("Data saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Not saved successfully.", "Errpr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
              
        }

        private void btnApplicationInfoNext_Click(object sender, EventArgs e)
        {

            if(_Mode == enMode.Update)
            {

                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];
                return;
            }

            if(ctrlPersonCardWithFilter1.PersonID!=-1)
            {

                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];

            }
            else
            {
                MessageBox.Show("Please select a person", "Select a person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }

        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void frmAddUpdateLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }
    }
}
