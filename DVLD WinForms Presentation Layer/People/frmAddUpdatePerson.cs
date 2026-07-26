using DVLD.Classes;
using DVLD_Business_Layer;
using DVLD_WinForms_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmAddUpdatePerson : Form
    {

        public delegate void DataBackEventHandler(object sender,int PersonID);

        public event DataBackEventHandler DataBack;

        enum enMode { AddNew=0,Update=1};
        enum enGendor { Male=0,Female=1};

        private enMode _Mode;
        private int _PersonID=-1;
        private clsPerson _person;

       
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
           _PersonID = PersonID;
        }

        private void _ResetDefaultValues()
        {

            _FillCountriesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                _person = new clsPerson();
            }
            else
            {
                lblTitle.Text = "Update Person";
            }

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;


            llRemovePersonImage.Visible = (pbPersonImage.ImageLocation != null);

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            cbCountries.SelectedIndex = cbCountries.FindString("Egypt");

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true; 
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";

            if(_Mode == enMode.AddNew)
            txtFirstName.Focus();
        }

        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }
        }

       private void _LoadData()
       {
            _person = clsPerson.Find(_PersonID);

            if(_person == null)
            {
                MessageBox.Show("No Person with ID = " +  _PersonID ,"Person Not Found!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblPersonID.Text = _person.ID.ToString();
            txtFirstName.Text = _person.FirstName;
            txtSecondName.Text = _person.SecondName;
            txtThirdName.Text = _person.ThirdName;
            txtLastName.Text = _person.LastName;
            txtNationalNo.Text = _person.NationalNo;

            if (_person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtEmail.Text = _person.Email;
            txtAddress.Text = _person.Address;

            dtpDateOfBirth.Value = _person.DateOfBirth;
            txtPhone.Text = _person.Phone;
            cbCountries.SelectedIndex = cbCountries.FindString(_person.CountryInfo.CountryName);

            if(_person.ImagePath !="")
            {
                pbPersonImage.ImageLocation = _person.ImagePath;
            }

            llRemovePersonImage.Visible = (_person.ImagePath != "");
       }

   
        private void frmAddEdirPersonInfo_Load(object sender, EventArgs e)
        {

            _ResetDefaultValues();
            

            if(_Mode == enMode.Update)
                _LoadData();
        }

  
        private bool _HandlePersonImage()
        {

            if(_person.ImagePath!=pbPersonImage.ImageLocation)
            {

                if(_person.ImagePath!="")
                {
                    try
                    {
                        File.Delete(_person.ImagePath);
                    }
                    catch(IOException iox)
                    {

                    }
                }

                if(pbPersonImage.ImageLocation!=null)
                {

                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if(clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    
                }


            }

            return true;

        }


        private void btnSave_Click_1(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valide!, put mouse over the red icon(s) to see error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandlePersonImage())
                return;

            int NationalCountryID = clsCountry.Find(cbCountries.Text).ID;

            _person.FirstName = txtFirstName.Text.Trim();
            _person.SecondName = txtSecondName.Text.Trim();
            _person.ThirdName = txtThirdName.Text.Trim();
            _person.LastName = txtLastName.Text.Trim();
            _person.NationalNo = txtNationalNo.Text.Trim();
            _person.Gendor = rbMale.Checked ? (byte)enGendor.Male : (byte)enGendor.Female;
            _person.Email = txtEmail.Text.Trim();
            _person.Address= txtAddress.Text.Trim();
            _person.DateOfBirth = dtpDateOfBirth.Value;
            _person.Phone = txtPhone.Text.Trim();
            _person.NationalCountryID = NationalCountryID;
            _person.CountryInfo = clsCountry.Find(NationalCountryID);

            if (pbPersonImage.ImageLocation != null)
                _person.ImagePath = pbPersonImage.ImageLocation.ToString();
            else
                _person.ImagePath = "";

            if(_person.Save())
            {
                lblPersonID.Text = _person.ID.ToString();

                lblTitle.Text = "Update Person";
                _Mode = enMode.Update;

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(sender,_person.ID);
            }
            else
            {
                MessageBox.Show("Error: Data is Not Saved Successfully!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llSetPersonImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files |*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "Select Person Image";
            openFileDialog1.FileName = "";
            openFileDialog1.RestoreDirectory = true;

         

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load (selectedFilePath);
                llRemovePersonImage.Visible = true;
            }
        }

        private void llRemovePersonImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            llRemovePersonImage.Visible = false;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Male_512;

        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Female_512;
        }

        private void ValidateEmptyTextBox(object sender,CancelEventArgs e)
        {

            TextBox Temp = (TextBox)sender;

            if(string.IsNullOrEmpty(Temp.Text.Trim()))
            {
               e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }


        private void txtNationalNo_Validating_1(object sender, CancelEventArgs e)
        {
            
            ValidateEmptyTextBox(sender, e);


            if (txtNationalNo.Text!=_person.NationalNo && clsPerson.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");
       
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, null);
            }
        }


        private void txtEmail_Validating_1(object sender, CancelEventArgs e)
        {

            if (txtEmail.Text.Trim() == "")
                return;

            if (!clsValidation.ValidateEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Please enter a valid email");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, null);
            }

        }
    }
}
