using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public  class clsUser
    {

       enum enMode { AddNew=0, Update=1}
        enMode _Mode = enMode.AddNew;

        public int UserID {  get; set; }
        public int PersonID { get; set; }

        public clsPerson PersonInfo;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUser ()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = true;
        
            _Mode = enMode.AddNew;
        }

        
        public clsUser ( int UserID, int PersonID, string UserName, string Password, bool IsActive)
        
        {

            this.UserID = UserID;
            this.PersonID = PersonID;
            PersonInfo = clsPerson.Find(PersonID);
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
       
            _Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID,this.UserName,this.Password,this.IsActive);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
           return clsUserData.UpdateUser(this.UserID,this.PersonID,this.UserName,this.Password,IsActive);

        }


        public static clsUser FindByUserID(int UserID)
        {

            int PersonID = -1;
            string UserName = "", Password = "";
            bool IsActive =false;

            if(clsUserData.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }

        }

        public static clsUser FindByPersonID(int PersonID)
        {

            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            if (clsUserData.GetUserInfoByPersonID( PersonID, ref UserID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }

        }


        public static clsUser FindUsernameAndPassword(string UserName, string Password)
        
        {
            
            int UserID = -1,
                PersonID=-1;
            
            bool IsActive = false;

            
            
            if(clsUserData.GetUserInfoByUserNameAndPassword( UserName, Password, ref UserID, ref PersonID, ref IsActive))
            
            {
                
                return new clsUser(UserID , PersonID,UserName, Password, IsActive);
            }
            else
            {
                return null;
            }

        }

        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewUser())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                case enMode.Update:

                    return _UpdateUser();

            }

            return false;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool IsUserExist(string Username)
        {
            return clsUserData.IsUserExist(Username);
        }

        public static bool IsUserExist(int UserID)
        {
               return clsUserData.IsUserExist(UserID);
        }

        public static bool IsUserExistForPersonID(int PersonID)
        {
            return clsUserData.IsUserExistForPersonID(PersonID);
        }

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            return clsUserData.ChangePassword(UserID, NewPassword);
        }

    }
}
