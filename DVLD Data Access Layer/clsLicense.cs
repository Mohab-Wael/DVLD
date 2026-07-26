using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
   
    public class clsLicenseData
    {

        public static bool GetLicenseInfoByID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
            ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    IsFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClassID = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Notes = (reader["Notes"] == DBNull.Value) ? "" : (string)reader["Notes"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsActive = (bool) reader["IsActive"];
                    IssueReason = (byte) reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                else
                {
                    IsFound = false;
                }

            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetLicenseInfoByApplicationID(int ApplicationID, ref int LicenseID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
            ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"SELECT * FROM Licenses 
                                     WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    IsFound = true;
                    LicenseID = (int)reader["LicenseID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClassID = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    if (reader["Notes"] != DBNull.Value)
                    {
                        Notes = (string)reader["Notes"];
                    }
                    else
                        Notes = "";
                }

                reader.Close();
            }
            catch(Exception ex)
            {
                IsFound =false;
            }
            finally
            {
                connection.Close();
            }
 
            return IsFound;

        }

        public static DataTable GetAllLicenses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT * FROM Licenses";

            SqlCommand command = new SqlCommand(query, connection);

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
              
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable GetDriverLicenses(int DriverID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"SELECT     
                           Licenses.LicenseID,
                           ApplicationID,
		                   LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN
                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            where DriverID=@DriverID
                            Order By IsActive Desc, ExpirationDate Desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate, 
            string Notes, float PaidFees, bool IsActive, byte IssueReason,int CreatedByUserID)
        {

            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"INSERT INTO Licenses (ApplicationID,
                                                   DriverID,
                                                   LicenseClass,
                                                   IssueDate,
                                                   ExpirationDate,
                                                   Notes,
                                                   PaidFees,
                                                   IsActive,
                                                  IssueReason,
                                                  CreatedByUserID)
                         VALUES (@ApplicationID,@DriverID,@LicenseClassID,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID)

                                   SELECT SCOPE_IDENTITY()";


            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

           if(Notes != "" && Notes!=null)
                cmd.Parameters.AddWithValue("@Notes", Notes);
           else
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);


            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    LicenseID = InsertedID;
                }

            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close(); 
            }

            return LicenseID;
        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"Update Licenses 
                                   set  ApplicationID = @ApplicationID,
                                        DriverID = @DriverID,
                                        LicenseClass = @LicenseClassID,
                                        IssueDate = @IssueDate,
                                        ExpirationDate = @ExpirationDate,
                                        Notes = @Notes,
                                        PaidFees = @PaidFees,
                                        IsActive = @IsActive,
                                        IssueReason = @IssueReason,
                                        CreatedByUserID = @CreatedByUserID
                                 WHERE LicenseID = @LicenseID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClass)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string Query = @"SELECT Licenses.LicenseID 
                                      FROM Licenses INNER JOIN 
		                       Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE
                                 (Drivers.PersonID = @PersonID)
                             AND (Licenses.LicenseClass = @LicenseClass)
                             AND (IsActive = 1);";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    LicenseID = InsertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return LicenseID;
        }

        public static bool DeactivateLicense(int LicenseID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"UPDATE Licenses
                           SET 
                              IsActive = 0
                             
                         WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
   
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
