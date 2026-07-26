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

namespace DVLD.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        private int _UserID = -1;
        private clsUser _User;

        public int UserID 
        {
            get { return _UserID; }
        }

        public ctrlUserCard()
        {
            InitializeComponent();
        }

     
    
        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.FindByUserID(UserID);

            if (_User == null)
            {
                _ResetUserAndPersonInfo();
                MessageBox.Show("No User with ID = " + UserID.ToString(),"User Not Found!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }

      
        private void _FillUserInfo()
        {

            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);

            _UserID = _User.UserID;
            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.UserName;
            lblIsActive.Text = _User.IsActive ? "Yes" : "No";
        }

        private void _ResetUserAndPersonInfo()
        {
            _UserID = -1;
            ctrlPersonCard1.ResetPersonInfo();
            lblUserID.Text = "[???]";
            lblUsername.Text = "[???]";
            lblIsActive.Text = "[???]";
        }
    }
}
