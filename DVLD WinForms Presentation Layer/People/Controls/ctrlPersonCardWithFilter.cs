using DVLD.People;
using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {

        
        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); 
            }
        }

        private bool _ShowAddPerson = true;

        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAddPerson.Enabled = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get 
            {
                return _FilterEnabled; 
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private int _PersonID = -1;
        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }


        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonCard1.SelectedPersonInfo; }
        }


        private void _DataBackEvent(object sender,int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Focus();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
         
            if(e.KeyChar == (char)Keys.Enter)
            {
                e.Handled=true;
                btnFind.PerformClick();
            }

            if (cbFilterBy.Text == "Person ID")
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            FindNow();

        }

        private void FindNow()
        {

            switch(cbFilterBy.Text)
            {
                case "Person ID":
                    ctrlPersonCard1.LoadPersonInfo(int.Parse(txtFilterValue.Text.Trim()));
                    break;

                case "National No.":
                    ctrlPersonCard1.LoadPersonInfo(txtFilterValue.Text.Trim());
                    break;

                default:
                    break;
            }

            if(OnPersonSelected!=null && FilterEnabled)
            {
                OnPersonSelected (ctrlPersonCard1.PersonID);
            }

        }


        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += _DataBackEvent;
            frm.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put mouse over icon(s) to see error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FindNow();
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
               
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }

        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

       
    }
}
