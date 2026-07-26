using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public class clsApplicationType
    {

        enum enMode {AddNew= 0, Update=1};
        enMode _Mode = enMode.AddNew;
        public int ID { get; set; }
        public string Title { get; set; }
        public float Fees { get; set; }

        public clsApplicationType()
        {
            ID = -1;
            Title = "";
            Fees = 0;

            _Mode = enMode.AddNew;
        }

        public clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, float ApplicationFees)
        {
            this.ID = ApplicationTypeID;
            this.Title = ApplicationTypeTitle;
            this.Fees = ApplicationFees;

            _Mode = enMode.Update;
        }

        private bool _AddNewApplicationType()
        {
            this.ID = clsApplicationTypesData.AddNewApplicationType(this.Title, this.Fees);

            return (this.ID != -1);
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypesData.UpdateApplicationType(this.ID, this.Title, this.Fees);

        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (_AddNewApplicationType())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateApplicationType();

            }

            return false;
        }


        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            float ApplicationFees = 0;

            if (clsApplicationTypesData.GetApplicationTypeInfoByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))

                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            else
                return null;

        }

      
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }
    }
    
}
