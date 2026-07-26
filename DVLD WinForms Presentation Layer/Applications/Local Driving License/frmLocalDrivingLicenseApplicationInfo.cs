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

namespace DVLD.Applications
{
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        private int _ApplicationID = -1;
       
        public frmLocalDrivingLicenseApplicationInfo(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
        }

        private void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        { 
            ctrlLocalDrivingLicenseInfo1.LoadApplicationInfoByLocalDrivingAppID(_ApplicationID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
