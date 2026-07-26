using DVLD.Classes;
using DVLD_Business_Layer;
using DVLD_WinForms_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.IO;

namespace DVLD.DriverLicense
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        private int _LicenseID = -1;
        private clsLicense _License;

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        { 
            get { return _License; } 
        }

        private void _LoadPersonImage()
        {

            if (_License.DriverInfo.PersonInfo.Gendor == 0)
            {
                pbPersonImage.Image = Resources.Male_512;
                pbGendor.Image = Resources.Man_32;
            }
            else
            {
                pbPersonImage.Image = Resources.Female_512;
                pbGendor.Image = Resources.Woman_32;
            }

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if(ImagePath!="" && ImagePath!= null)
            {
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not found this image = " + ImagePath,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.FindByLicenseID(LicenseID);
            if (_License == null)
            {
                MessageBox.Show("No License with ID = " + LicenseID, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            lblClass.Text = _License.LicenseClassInfo.LicenseClassName;
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblIssueDate.Text = clsFormat.DateToShort(_License.IssueDate);
            lblGendor.Text = _License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            lblIsActive.Text = (_License.IsActive) ? "Yes" : "No";
            lblDateOfBirth.Text = clsFormat.DateToShort(_License.DriverInfo.PersonInfo.DateOfBirth);
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
            _LoadPersonImage();

        }
    }
}
