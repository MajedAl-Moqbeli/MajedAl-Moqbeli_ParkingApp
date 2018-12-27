using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;


namespace Parking_WS.Myclass
{
   
    public class users
    {
       
        public int IsAvailable_stu(int stu_university_id)
        {
            int userID = 0;
            try
            {
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("IsAvailable_stu");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@stu_university_id", stu_university_id);
                    connection.Open();
                    reader = cmd.ExecuteReader();
                    if ( reader.FieldCount > 0 )
                    {
                        reader.Read();
                        userID = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch ( Exception ex )
            {

            }
            return userID; 
        }

        public int IsAvailable_vip(int vip_job_id)
        {
            int userID = 0;
            try
            {
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("IsAvailable_vip");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@vip_job_id", vip_job_id);
                    connection.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.FieldCount > 0)
                    {
                        reader.Read();
                        userID = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return userID;
        }

        public int IsAvailable_Admin(string Admin_username)
        {
            int userID = 0;
            try
            {
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("IsAvailable_Admin");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@Admin_username", Admin_username);
                    connection.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.FieldCount > 0)
                    {
                        reader.Read();
                        userID = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return userID;
        }

        public int login_Admin(string username, string password)
        {
            int userID = 0;
            try
            {
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("login_Admin");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@Admin_username", username);
                    cmd.Parameters.AddWithValue("@Admin_password", password);
                    connection.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.FieldCount > 0)
                    {
                        reader.Read();
                        userID = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return userID;
          
        }

        public int login_VIP(int vip_job_id, string password)
        {
            int userID = 0;
            try
            {
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("login_VIP");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@vip_job_id", vip_job_id);
                    cmd.Parameters.AddWithValue("@vip_password", password);
                    connection.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.FieldCount > 0)
                    {
                        reader.Read();
                        userID = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return userID;

        }

        public int login_Stu(int stu_university_id, string password)
        {
            int userID = 0;
            try
            {
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("login_Stu");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@stu_university_id", stu_university_id);
                    cmd.Parameters.AddWithValue("@stu_password", password);
                    connection.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.FieldCount > 0)
                    {
                        reader.Read();
                        userID = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return userID;

        }

    }
 }

