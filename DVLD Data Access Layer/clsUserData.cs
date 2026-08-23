
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DVLD_Data_Access_Layer 
{   
    public class clsUserData
    {

        public static bool GetUserInfoByUserID(int UserID,ref int PersonID,ref string UserName,ref string Password, 
                              ref bool isActive)
        {
          
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    isActive = (bool)reader["IsActive"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                string SourceName = "DVLDApp";

                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                EventLog.WriteEntry(SourceName, ex.Message, EventLogEntryType.Error);

                throw;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }

        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName, ref string Password,
                         ref bool isActive)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT * FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    UserID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    isActive = (bool)reader["IsActive"];
                }
            }
            catch(Exception ex)
            {
                string SourceName = "DVLDApp";

                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                EventLog.WriteEntry(SourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }


        public static bool GetUserInfoByUserNameAndPassword(string UserName, string Password ,ref int UserID, ref int PersonID,
                            ref bool isActive)
        {

            
            bool isFound = false;

            
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            
            string query = @"SELECT * FROM Users 
                                         WHERE UserName = @UserName AND Password = @Password;";



            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    
                    isFound= true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    isActive = (bool)reader["IsActive"];
                }

                reader.Close();
            
            }
            catch (Exception ex)
            {
                string SourceName = "DVLDApp";

                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                EventLog.WriteEntry(SourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return isFound;        
        }

        public static int AddNewUser(int PersonID,string UserName,string Password, bool isActive)
        {

            int UserID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string Query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive) 
                               VALUES (@PersonID, @UserName, @Password, @IsActive);
                            SELECT SCOPE_IDENTITY();";

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));

                Password = BitConverter.ToString(hashPassword).Replace("-", "").ToLower();
            }


            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", isActive);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    UserID = InsertedID;
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
            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }

        public static bool DeleteUser(int UserID)
        {
            int rowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string Query = @"DELETE Users 
                                   WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("UserID", UserID);

            try
            {
                connection.Open();

                rowAffected = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                string SourceName = "DVLDApp";

                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                EventLog.WriteEntry(SourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return (rowAffected > 0);

        }

        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string Query = @"Update Users 
                               SET PersonID = @PersonID,
                                   UserName = @UserName,
                                   Password = @Password,
                                   IsActive = @IsActive
                             WHERE UserID = @UserID;";

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));

                Password = BitConverter.ToString(hashPassword).Replace("-", "").ToLower();
            }

            SqlCommand command  = new SqlCommand(Query,connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string SourceName = "DVLDApp";

                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                EventLog.WriteEntry(SourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string Query = @"SELECT Users.UserID, People.PersonID,
                              FullName = People.FirstName + ' ' + People.SecondName + ' ' +
                              ISNULL(People.ThirdName,'') + ' ' + People.LastName, Users.UserName, Users.IsActive 
	                             FROM Users INNER JOIN 
	                                         People  ON Users.PersonID = People.PersonID;";

            SqlCommand command = new SqlCommand(Query,connection);

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                string SourceName = "DVLDApp";

                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                EventLog.WriteEntry(SourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close(); 
            }

            return dt;
        }

        public static bool IsUserExist(string Username)
        {
            bool IsFound;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT Found = 1 FROM Users WHERE Username = @Username";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                string SourceName = "DVLDApp";

                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                EventLog.WriteEntry(SourceName, ex.Message, EventLogEntryType.Error);

                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool IsUserExist(int UserID)
        {
            bool IsFound;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT Found = 1 FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                string SourceName = "DVLDApp";

                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                EventLog.WriteEntry(SourceName, ex.Message, EventLogEntryType.Error);

                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool IsUserExistForPersonID(int PersonID)
        {
            bool IsFound;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT Found = 1 FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                string SourceName = "DVLDApp";

                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                EventLog.WriteEntry(SourceName, ex.Message, EventLogEntryType.Error);

                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string Query = @"Update Users 
                               SET Password = @Password
                             WHERE UserID = @UserID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Password", NewPassword);

             try
             {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
             }
             catch (Exception ex)
             {
                string SourceName = "DVLDApp";

                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                EventLog.WriteEntry(SourceName, ex.Message, EventLogEntryType.Error);

                return false;
             }
             finally
             {
                connection.Close();
             }

            return (rowsAffected > 0);
        }
    }
}
