using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public static class clsApplicationData
    {

        public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicationPersonID, ref DateTime ApplicationDate,
                   ref int ApplicationTypeID, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref float PaidFees,
                       ref int CreatedByUserID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string Query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ApplicationPersonID = (int)reader["ApplicationPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = Convert.ToSingle( reader["PaidFees"] );
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                else
                {
                    IsFound = false;
                }

                    reader.Close();
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

        public static int AddNewApplication( int ApplicationPersonID,  DateTime ApplicationDate,
                    int ApplicationTypeID,  byte ApplicationStatus,  DateTime LastStatusDate,  float PaidFees,
                        int CreatedByUserID)
        {

            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string Query = @"INSERT INTO Applications (ApplicationPersonID, ApplicationDate, ApplicationTypeID,
                                            ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                                 VALUES (@ApplicationPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus,
                                                 @LastStatusDate, @PaidFees, @CreatedByUserID);

                                       SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID); 
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {

                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ApplicationID = InsertedID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return ApplicationID;
        }

        public static bool UpdateApplication(int ApplicationID,int ApplicationPersonID, DateTime ApplicationDate,
                    int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, float PaidFees,
                        int CreatedByUserID)

        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"Update Applications 
                                    set ApplicationPersonID = @ApplicationPersonID,
                                        ApplicationDate = @ApplicationDate,
                                        ApplicationTypeID = @ApplicationTypeID,
                                        ApplicationStatus = @ApplicationStatus,
                                        LastStatusDate = @LastStatusDate,
                                        PaidFees = @PaidFees,
                                        CreatedByUserID = @CreatedByUserID
                                     WHERE ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) 
            {
                
            }
            finally
            {
                connection.Close();
            }

           return (rowsAffected > 0);

        }


        public static bool DeleteApplication(int ApplicationID)

        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"DELETE FROM Applications 
                                           WHERE ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);


            try
            {
                connection.Open();

                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);

        }


        public static bool IsApplicationExist(int ApplicationID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT Found = 1 FROM Application WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {

            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"SELECT ActiveApplicationID = ApplicationID FROM Applications
                                                 WHERE ApplicationPersonID = @ApplicationPersonID
                                                   AND ApplicationTypeID = @ApplicationTypeID 
                                                   AND ApplicationStatus = 1";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.Add("@ApplicationPersonID", PersonID);
            cmd.Parameters.Add("@ApplicationTypeID", ApplicationTypeID);

            try
            {

                connection.Open();

                object result = cmd.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ActiveApplicationID = InsertedID;
                }


            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;

        }
         
        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return ((GetActiveApplicationID(PersonID, ApplicationTypeID) != -1));
        }

        public static int GetActiveApplicationIDForLicenseClass(int Person, int ApplicationTypeID, int LicenseClassID)
        {

            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"SELECT ActiveApplicationID= Applications.ApplicationID
                            From
                            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE ApplicationPersonID = @ApplictiontPersonID 
                            and ApplicationTypeID=@ApplicationTypeID 
							and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                            and ApplicationStatus = 1";


            SqlCommand cmd = new SqlCommand(@query, connection);

            cmd.Parameters.AddWithValue("@ApplictiontPersonID", Person);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ActiveApplicationID = InsertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;

        }

        public static bool UpdateStatus(int ApplicationID, short NewStatus)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"Update Applications
                                 set ApplicationStatus = @NewApplicationStatus,
                                     LastStatusDate = @LastStatusDate
                                 WHERE ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@NewApplicationStatus", NewStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

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

            }

            return (rowsAffected > 0);
        }

    }
}
