using DVLD_WinForms_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business_Layer;
using System.IO;
using DVLD.Classes;

namespace DVLD.International_License.Controls
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        private int _InternationalLicenseID = -1;
        private clsInternationalLicense _InternationalLicense;

        public int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }

        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {

            if (_InternationalLicense.DriverInfo.PersonInfo.Gendor == 0)
            {
                pbGendor.Image = Resources.Man_32;
                pbPersonImage.Image = Resources.Male_512;
            }
            else
            {
                pbGendor.Image = Resources.Woman_32;
                pbPersonImage.Image = Resources.Female_512;
            }

            if (_InternationalLicense.DriverInfo.PersonInfo.ImagePath != ""
                &&
                _InternationalLicense.DriverInfo.PersonInfo.ImagePath != null)
            {
                if (File.Exists(_InternationalLicense.DriverInfo.PersonInfo.ImagePath))
                {
                    pbPersonImage.Load(_InternationalLicense.DriverInfo.PersonInfo.ImagePath);
                }
                else
                    MessageBox.Show("Could Not Find this image: = " + _InternationalLicense.DriverInfo.PersonInfo.ImagePath,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;
            _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);

            if (_InternationalLicense == null)
            {
                MessageBox.Show("Could Not Found International License With ID = " + _InternationalLicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblPersonFullName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName;
            lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblLocalLicenseID.Text = _InternationalLicense.IssueUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _InternationalLicense.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblIssueDate.Text = clsFormat.DateToShort(_InternationalLicense.IssueDate);
            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lblActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = clsFormat.DateToShort(_InternationalLicense.DriverInfo.PersonInfo.DateOfBirth);
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now);
            _LoadPersonImage();
        }

       
    }
}

