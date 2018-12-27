using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parking_WS.Myclass
{
    public class Parking
    {
        public int parking_stu(int sl_id)
        {
            int slotID = 0;
            try
            {
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("IsAvailable_parking_stu");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@sl_id", sl_id);
                    connection.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.FieldCount > 0)
                    {
                        reader.Read();
                        slotID = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return slotID;
        }

        public int parking_vip(int sl_id)
        {
            int slotID = 0;
            try
            {
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("IsAvailable_parking_vip");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@sl_id", sl_id);
                    connection.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.FieldCount > 0)
                    {
                        reader.Read();
                        slotID = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return slotID;
        }

        public int IsParking_stu(int stu_id)
        {
            int stuID = 0;
            try
            {
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("isParking_stu");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@stu_id", stu_id);
                    connection.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.FieldCount > 0)
                    {
                        reader.Read();
                        stuID = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return stuID;
        }

        public int IsParking_vip(int vip_id)
        {
            int vipID = 0;
            try
            {
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("isParking_vip");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@vip_id", vip_id);
                    connection.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.FieldCount > 0)
                    {
                        reader.Read();
                        vipID = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return vipID;
        }

        

    }
}