using DVLD.Applications;
using DVLD.Classes;
using DVLD.People;
using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Controls.ApplicationControls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {

        private int _ApplicationID = -1;
        private clsApplication _Application;


        public int ApplicationID
        {
            get { return _ApplicationID; }
        }

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public ctrlApplicationBasicInfo(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
        }

        public void ResetDefaultValues()
        {
            _ApplicationID = -1;
            lblApplicationID.Text = "[???]";
            lblStatusDate.Text = "[???]";
            lblApplicationFees.Text = "[$$$]";
            lblApplicationType.Text = "[????]";
            lblApplicationType.Text = "[?????]";
            lblApplicationDate.Text = "[??/??/????]";
            lblStatusDate.Text = "[??/??/????]";
            lblCreatedBy.Text = "[?????]";

        }

        public void LoadApplicationInfo(int ApplicationID)
        {

            _Application = clsApplication.FindBaseApplication(ApplicationID);

            if (_Application == null)
            {
                ResetDefaultValues();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                _FillApplicationInfo();
            }
        }



        public void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblApplicationStatus.Text = _Application.ApplicationStatus.ToString();
            lblApplicationFees.Text = _Application.PaidFees.ToString();
            lblApplicationType.Text = _Application.ApplicationTypeInfo.Title;
            lblApplicationBy.Text = _Application.PersonInfo.FullName;
            lblApplicationDate.Text = clsFormat.DateToShort(_Application.ApplicationDate).ToString();
            lblStatusDate.Text = clsFormat.DateToShort(_Application.LastStatusDate).ToString();
            lblCreatedBy.Text = _Application.CreatedByUserInfo.UserName;

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_Application.ApplicationPersonID);
            frm.ShowDialog();

            //Refresh
            LoadApplicationInfo(_ApplicationID);
        }
    }
}
