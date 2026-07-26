using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public class clsPerson
    {

       public enum enMode { AddNew = 0, Update = 1 };
       public enMode Mode = enMode.AddNew;


        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalCountryID { get; set; }

        public clsCountry CountryInfo;

        private string _ImagePath;
        public string ImagePath 
        {
            get {  return _ImagePath; }
            set { _ImagePath = value; }
        }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }

        }


        public clsPerson()
        {
            this.ID = -1;
            this.NationalNo = "";
            this.ImagePath = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Gendor = 0;
            this.NationalCountryID = -1;
            this.Phone = "";
            this.Email = "";
            this.NationalNo = "";

            Mode = enMode.AddNew;
        }


        public clsPerson(int PersonID, string FirstName, string SecondName
            , string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth
            , byte Gendor, string Address, string Phone, string Email, int NationalCountryID, string ImagePath)
        {
            this.ID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalCountryID = NationalCountryID;
            this.CountryInfo = clsCountry.Find(NationalCountryID);
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.ID = clsPersonData.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                 this.NationalNo, this.DateOfBirth, this.Gendor,
                 this.Address, this.Phone, this.Email, this.NationalCountryID, this.ImagePath);

            return (this.ID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.ID, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.NationalNo, this.DateOfBirth, this.Gendor,
                this.Address, this.Phone, this.Email, this.NationalCountryID, this.ImagePath);
        }


        public static clsPerson Find(int PersonID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "", NationalNo = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            int NationalityCountryID = -1;

            bool IsFound = clsPersonData.GetPersonInfoByID
                                (
                                 PersonID,
                                 ref FirstName, ref SecondName, ref ThirdName,
                                 ref LastName, ref NationalNo, ref DateOfBirth,
                                ref Gendor, ref Address, ref Phone, ref Email,
                                ref NationalityCountryID, ref ImagePath
                                );

            if(IsFound)
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo,
                    DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;

        }

        public static clsPerson Find(string NationalNo)
        {
            int PersonID = -1;
             string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            int NationalityCountryID = -1;

            bool IsFound = clsPersonData.GetPersonInfoByNationalNo
                                (
                                 NationalNo,ref PersonID,  ref FirstName, ref SecondName,
                                 ref ThirdName, ref LastName,ref DateOfBirth,
                                ref Gendor, ref Address, ref Phone, ref Email,
                                ref NationalityCountryID, ref ImagePath
                                );

            if (IsFound)
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo,
                    DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();
            }

            return false;
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }

   
    }
}
