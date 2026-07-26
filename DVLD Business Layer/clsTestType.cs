using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public class clsTestType
    {

        enum enMode { AddNew=0,Update=1};
        enMode _Mode = enMode.AddNew;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };


        public clsTestType.enTestType ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }


        public clsTestType()
        {
            ID = clsTestType.enTestType.VisionTest;
            Title = "";
            Description = "";
            Fees = 0;
            _Mode = enMode.AddNew;
        }

        public clsTestType (enTestType TestTypeID, string TestTypeTitle, string TestTypeDescription, 
            float TestTypeFees)
        {
            this.ID = TestTypeID;
            this.Title = TestTypeTitle;
            this.Description = TestTypeDescription;
            this.Fees = TestTypeFees;
            _Mode = enMode.Update;
        }

        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType((int)this.ID, this.Title,
                this.Description, Fees);
        }

        private bool _AddNewTestType()
        {
            this.ID = (clsTestType.enTestType) clsTestTypeData.AddNewTestType(this.Title, this.Description,this.Fees);

            return (this.Title != "");
        }

        public static clsTestType Find(clsTestType.enTestType TestTypeID)
        {
            string TestTypeTitle = "", TestTypeDescription = "";
            float TestTypeFees = 0;

            if(clsTestTypeData.GetTestTypeInfoByID((int)TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
            {
                return new clsTestType((clsTestType.enTestType) TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            }
            else
            {
                return null;
            }

        }
        public bool Save()
        {

            switch(_Mode)
            {

                case enMode.AddNew:

                    if(_AddNewTestType())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else

                    {
                        return false;
                    }

                    case enMode.Update:

                    return _UpdateTestType();

            }

            return false;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestType();
        }

    }
}
