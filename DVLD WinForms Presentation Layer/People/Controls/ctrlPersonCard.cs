using DVLD_Business_Layer;
using DVLD_WinForms_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DVLD.People;

namespace DVLD.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _Person;

        private int _PersonID=-1;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if(_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with personID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with NationalNo = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;


            string ImagePath = _Person.ImagePath;
            if(ImagePath!="" &&  ImagePath!=null)
            
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image = " + ImagePath,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
           
        }

        private void _FillPersonInfo()
        {
            llUpdatePersonInfo.Enabled = true;
            _PersonID = _Person.ID;
            lblPersonID.Text = _Person.ID.ToString();
            lblName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;
            lblGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountry.Text = clsCountry.Find(_Person.NationalCountryID).CountryName;
            lblAddress.Text = _Person.Address;
            lblPhone.Text = _Person.Phone;
            _LoadPersonImage();
        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblAddress.Text = "[????]";
            lblPhone.Text = "[????]";
            lblEmail.Text = "[????]";
            lblCountry.Text = "[????]";
            lblGendor.Text = "[????]";
            pbGendor.Image = Resources.Man_32;
            pbPersonImage.Image = Resources.Male_512;
           
        }

        private void llUpdatePersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();

            //refresh
            LoadPersonInfo(_PersonID);
        }
    }
    
}
