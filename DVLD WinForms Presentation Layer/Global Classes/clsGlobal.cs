using DVLD_Business_Layer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Classes
{
    public static class clsGlobal
    {

        public static clsUser CurrentUser;

        public static bool RememberUserNameAndPassword( string Username,  string Password)
        {

            string KeyPath = @"HKEY_CURRENT_USER\Software\DVLDLoginData";

            string UsernameValueName = "Username";
            string ValueUsername = Username;

            string PasswordValueName = "Password";
            string ValuePassword = Password;

            try
            {

                Registry.SetValue(KeyPath, UsernameValueName, ValueUsername, RegistryValueKind.String);

                Registry.SetValue(KeyPath, PasswordValueName, ValuePassword, RegistryValueKind.String);
              
            }
            
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

            return true;
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {

            string KeyPath = @"HKEY_CURRENT_USER\Software\DVLDLoginData";

            string UsernameValueName = "Username";
            string PasswordValueName = "Password";

            try
            {


                string UsernameValue = Registry.GetValue(KeyPath,UsernameValueName,null) as string;
                string PasswordValue = Registry.GetValue(KeyPath,PasswordValueName,null) as string;

                if (UsernameValue != null && PasswordValue != null)
                {
                    Username = UsernameValue;
                    Password = PasswordValue;
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

      
        }
        



        public static bool StoreLoginRegister( string Username, bool IsActive)
        {

           try
           {

                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                string FilePath = currentDirectory + "\\LoginRegisters.txt";

                if(!File.Exists(FilePath))
                {
                    File.Create(FilePath);
                }

                string LoginInfoToSave = Username + "#//#" + IsActive.ToString() + "#//#" + DateTime.Now;

                using (StreamWriter writer = new StreamWriter(FilePath,true))
                {
                    writer.WriteLine(LoginInfoToSave);
                    return true;
                }


           } 
           catch (Exception ex)
           {
                MessageBox.Show($"An occurred error {ex.Message}");
                return false;
           }

        }

    }
}
