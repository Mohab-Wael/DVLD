using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Controls;
using DVLD_Business_Layer;

namespace DVLD.User
{
    public partial class frmShowUserInfo : Form
    {

        private int _UserID;
      

        public frmShowUserInfo(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            
            ctrlUserCard1.LoadUserInfo(_UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
