using DVLD_Business_Layer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Classes
{
    public static class clsGlobal
    {

        public static clsUser CurrentUser;

        private static string Key = "MMMMMMM!!??OOOOO";

        public static bool RememberUserNameAndPassword( string Username,  string Password)
        {

            string KeyPath = @"HKEY_CURRENT_USER\Software\DVLDLoginData";

            string UsernameValueName = "Username";
            string ValueUsername = Username;

            string PasswordValueName = "Password";
            string ValuePassword = Encrypt( Password,Key);

            try
            {

                Registry.SetValue(KeyPath, UsernameValueName, ValueUsername, RegistryValueKind.String);

                Registry.SetValue(KeyPath, PasswordValueName, ValuePassword, RegistryValueKind.String);
              
            }
            
            catch(Exception ex)
            {
                string SourceName = "DVLDApp";

                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                EventLog.WriteEntry(SourceName, ex.Message, EventLogEntryType.Error);

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
                string PasswordValue = Decrypt(Registry.GetValue(KeyPath,PasswordValueName,null) as string,Key);

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
                string SourceName = "DVLDApp";

                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                EventLog.WriteEntry(SourceName, ex.Message, EventLogEntryType.Error);

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
                string SourceName = "DVLDApp";

                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                EventLog.WriteEntry(SourceName, ex.Message, EventLogEntryType.Error);

                MessageBox.Show($"An occurred error {ex.Message}");
                return false;
           }

        }

        static string Encrypt(string plainText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES encryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                // Encrypt the data
                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }


                    // Return the encrypted data as a Base64-encoded string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        static string Decrypt(string cipherText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {

                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                ICryptoTransform Decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, Decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }

            }
        }
    }
}
