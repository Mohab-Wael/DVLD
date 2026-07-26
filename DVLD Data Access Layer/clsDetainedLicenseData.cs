using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public  class clsDetainedLicenseData
    {
        public static bool GetDetainedLicenseInfoByID(int DetainID, ref int LicenseID, ref DateTime DetainDate, 
            ref float FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID,
            ref int ReleaseApplicationID)
        {

            bool IsFound;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"SELECT * FROM DetainedLicenses where DetainID = @DetainID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];

                    if (reader["ReleaseDate"] == DBNull.Value)
                        ReleaseDate = DateTime.MaxValue;
                    else
                        ReleaseDate = (DateTime)reader["ReleaseDate"];

                    if (reader["ReleasedByUserID"] == DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];

                    if (reader["ReleaseApplicationID"] == DBNull.Value)
                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
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
                throw;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID, ref int DetainID, ref DateTime DetainDate,
         ref float FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID,
         ref int ReleaseApplicationID)
        {

            bool IsFound;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"SELECT * FROM DetainedLicenses where LicenseID = @LicenseID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];

                    if (reader["ReleaseDate"] == DBNull.Value)
                        ReleaseDate = DateTime.MaxValue;
                    else
                        ReleaseDate = (DateTime)reader["ReleaseDate"];

                    if (reader["ReleasedByUserID"] == DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];

                    if (reader["ReleaseApplicationID"] == DBNull.Value)
                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
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
                throw;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        public static DataTable GetAllDetainedLicenses()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT * FROM DetainedLicenses_View order by IsReleased, DetainID;";

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
                throw;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static int AddNewDetainLicense(int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID,
            bool IsReleased)
        {

            int DetainID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"INSERT INTO DetainedLicenses 
                      (
					   LicenseID,
					   DetainDate,
					   FineFees,
					   CreatedByUserID,
					   IsReleased
					  )
				VALUES
				      (
                       @LicenseID,
                       @DetainDate,
                       @FineFees,
                       @CreatedByUserID,
                       @IsReleased
				      );

                  SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
            cmd.Parameters.AddWithValue("@FineFees", FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased", IsReleased);

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    DetainID = InsertedID;
                }
            }
            catch(Exception ex)
            {
                DetainID = -1;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return DetainID;
        }

        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, float FineFees, 
            int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {

            int rowsAffected = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"UPDATE DetainedLicenses
                                     set LicenseID = @LicenseID,
                                         DetainDate = @DetainDate,
                                         FineFees = @FineFees,
                                         CreatedByUserID = @CreatedByUserID,
                                         IsReleased = @IsReleased,
                                    WHERE DetainID = @DetainID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@DetainID", DetainID);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
            cmd.Parameters.AddWithValue("@FineFees", FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased", IsReleased);


            try
            {
                connection.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rowsAffected = 0;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);

        }

        public static bool DeleteDetainedLicense(int DetainID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "DELETE FROM DetainedLicenses where DetainID = @DetainID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@DetainID", DetainID);

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

            return rowsAffected > 0;

        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsLicenseDetained = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT IsDetained = 1 FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsLicenseDetained = Convert.ToBoolean(result);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return IsLicenseDetained;
        }

        public static bool ReleaseDetainedLicense(int DetainID, int ReleasedByUserID, int ReleasedApplicationID)
        {
            
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"UPDATE DetainedLicenses 
                                      set IsReleased = 1,
                                          ReleaseDate = @ReleaseDate,
                                          ReleasedByUserID = @ReleasedByUserID,
                                          ReleaseApplicationID = @ReleaseApplicationID
                                      WHERE DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query,connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleasedApplicationID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                rowsAffected = 0;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
    }
}
