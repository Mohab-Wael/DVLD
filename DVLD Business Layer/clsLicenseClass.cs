using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public class clsLicenseClass
    {
        public enum enMode {AddNew , Update };  
        public enMode Mode;

        public int LicenseClassID { get; set; }
        public string LicenseClassName { get; set; }
        public string LicenseClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength  { get; set; }
        public float ClassFees { get; set; }

        public clsLicenseClass()
        {
            LicenseClassID = -1;
            LicenseClassName = "";
            LicenseClassDescription = "";
            MinimumAllowedAge = 0;
            DefaultValidityLength = 0;
            ClassFees = 0;
            Mode = enMode.AddNew;
        }

        public clsLicenseClass(int LicenseClassID, string LicenseClassName, string LicenseClassDescription,
                                byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {

            this.LicenseClassID = LicenseClassID;
            this.LicenseClassName = LicenseClassName;
            this.LicenseClassDescription = LicenseClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
            Mode = enMode.Update;
        }

        private bool _AddNewLicenseClass()
        {
          
            this.LicenseClassID = clsLicenseClassData.AddNewLicenseClass(this.LicenseClassName, this.LicenseClassDescription,
                this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);


            return (this.LicenseClassID != -1);
        }

        private bool _UpdateLicenseClass()
        {

            return clsLicenseClassData.UpdateLicenseClass(this.LicenseClassID, this.LicenseClassName, this.LicenseClassDescription,
                this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }

        public static clsLicenseClass Find(int LicenseClassID)
        {

            string ClassName = "", ClassDescription = "";
            byte MinimumAllowedAge = 0, DefaultValidityLength = 0;
            float ClassFees = 0;


            bool IsFound = clsLicenseClassData.GetLicenseClassInfoByID(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge,
                ref DefaultValidityLength, ref ClassFees);
            if(IsFound)
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength,
                                                                                          ClassFees);
            }
            else
                return null;

        }

        public static clsLicenseClass Find(string ClassName)
        {
            int LicenseClassID = -1;
            string ClassDescription = "";
            byte MinimumAllowedAge = 0, DefaultValidityLength = 0;
            float ClassFees = 0;


            bool IsFound = clsLicenseClassData.GetLicenseClassInfoByClassName(ClassName,ref LicenseClassID, ref ClassDescription, ref MinimumAllowedAge,
                ref DefaultValidityLength, ref ClassFees);
            if (IsFound)
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength,
                                                                                          ClassFees);
            }
            else
                return null;

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicenseClass();

            }

            return false;
        }
    }
}
