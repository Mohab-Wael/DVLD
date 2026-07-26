using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public static class clsLicenseClassData
    {

        public static bool GetLicenseClassInfoByID(int LicenseClassID, ref string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge,
                                                         ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand cmd = new SqlCommand(@query, connection);

            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);
                }
                else
                {
                    IsFound = false;
                }
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

        public static bool GetLicenseClassInfoByClassName(string ClassName, ref int LicenseClassID, ref string ClassDescription, ref byte MinimumAllowedAge,
                                                                ref byte DefaultValidityLength, ref float ClassFees)
        {


            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT * FROM LicenseClasses WHERE ClassName = @ClassName";

            SqlCommand cmd = new SqlCommand(@query, connection);

            cmd.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);
                }
                else
                {
                    IsFound = false;
                }
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
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dtAllLicenseClasses = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = "SELECT * FROM LicenseClasses ORDER BY ClassName";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtAllLicenseClasses.Load(reader);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dtAllLicenseClasses;
        }

        public static int AddNewLicenseClass(string ClassName, string ClassDescription,
          byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            int LicenseClassID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"Insert Into LicenseClasses 
           (
            ClassName,ClassDescription,MinimumAllowedAge, 
            DefaultValidityLength,ClassFees)
                            Values ( 
            @ClassName,@ClassDescription,@MinimumAllowedAge, 
            @DefaultValidityLength,@ClassFees);
                            SELECT SCOPE_IDENTITY();";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseClassID = insertedID;
                }
            }

            catch (Exception ex)
            {
                

            }

            finally
            {
                connection.Close();
            }


            return LicenseClassID;

        }

        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName,
            string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.connectionString);

            string query = @"Update  LicenseClasses  
                            set ClassName = @ClassName,
                                ClassDescription = @ClassDescription,
                                MinimumAllowedAge = @MinimumAllowedAge,
                                DefaultValidityLength = @DefaultValidityLength,
                                ClassFees = @ClassFees
                                where LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);


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

