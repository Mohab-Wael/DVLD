using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public static class clsTestData
    {
        public static bool GetTestInfoByID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes,
            ref int CreatedByUserID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT * FROM Tests WHERE TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];

                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }

                    CreatedByUserID = (int)reader["CreatedByUserID"];
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

        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass(int PersonID, int LicenseClassID,
             int TestTypeID, ref int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes,
             ref int CreatedByUserID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"SELECT   top 1 Tests.TestID, Tests.TestAppointmentID, Tests.TestResult, Tests.Notes, Tests.CreatedByUserID, Applications.ApplicationPersonID 
                             FROM     LocalDrivingLicenseApplications INNER JOIN 
                             Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN
                             TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                             Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID 
                             WHERE (Applications.ApplicationPersonID = @ApplicationPersonID)
                             AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                             AND (TestAppointments.TestTypeID = @TestTypeID)
                             order by Tests.TestAppointmentID Desc;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationPersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];

                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }

                    CreatedByUserID = (int)reader["CreatedByUserID"];
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

        public static DataTable GetAllTests()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT * FROM Tests";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
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

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {

            int TestID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID) 
                            VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID); 

                           Update TestAppointments 
                           set IsLocked = 1 where TestAppointmentID = @TestAppointmentID;

                        SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);

            if (Notes != "")
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    TestID = InsertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return TestID;
        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"UPDATE Tests SET TestAppointmentID = @TestAppointmentID, TestResult = @TestResult, 
                Notes = @Notes, CreatedByUserID = @CreatedByUserID WHERE TestID = @TestID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@TestID", TestID);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", TestResult);

            if (Notes != "")
                cmd.Parameters.AddWithValue("@Notes", Notes);
            else
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);

            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)

            {
                rowsAffected = 0;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteTest(int TestID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "DELETE FROM Tests WHERE TestID = @TestID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rowsAffected = 0;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte PassedTestCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"SELECT PassedTestCount = COUNT(TestTypeID) 
                                FROM Tests INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID 
                               WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestResult = 1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte ptCount))
                {
                    PassedTestCount = ptCount;
                }

            }
            catch (Exception ex)
            {
                PassedTestCount = 0;
            }
            finally
            {
                connection.Close();

            }

            return PassedTestCount; 
        }

       
    }
}
