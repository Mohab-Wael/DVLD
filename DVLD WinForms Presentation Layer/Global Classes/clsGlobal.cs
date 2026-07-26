using DVLD_Business_Layer;
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
            try
            {

                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                string FilePath = currentDirectory + "\\data.txt";

                if (Username == "" && File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    return false;
                }

                string DataToSaved = Username + "#//#" + Password;

                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    writer.WriteLine(DataToSaved);
                    return true;
                }
            }
            
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {

            try
            {

                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                string FilePath = currentDirectory + "\\data.txt";



                if (File.Exists(FilePath))
                {

                    using (StreamReader reader = new StreamReader(FilePath))
                    {

                        string Line;
                        while((Line = reader.ReadLine()) != null)
                        {
                      
                            string[] result = Line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];

                        }
                            return true;

                    }

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
