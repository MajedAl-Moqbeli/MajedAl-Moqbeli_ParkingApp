using Parking_WS.Myclass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace Parking_WS
{
    /// <summary>
    /// Summary description for ParkingWEDService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ParkingWEDService : System.Web.Services.WebService
    {

        // this method for Admin Login 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void login_Admin(string username, string password)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            users login = new users();
            string Message = "";
            int UserID = login.login_Admin(username, password);

            if (UserID == 0)
            {
                Message = "User Name Or Password Is Incorrect";
            }
            else
            {
                Message = "Successfully Login";
            }

            var JSonData = new
            {
                UserID = UserID,
                Message = Message
            };
            HttpContext.Current.Response.Write(ser.Serialize(JSonData));
        }

        // this method for VIP Login 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void login_VIP(int vip_job_id, string password)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            users login = new users();
            string Message = "";
            int UserID = login.login_VIP(vip_job_id, password);

            if (UserID == 0)
            {
                Message = "Job ID Or Password Is Incorrect";
            }
            else
            {
                Message = "Successfully Login";
            }

            var JSonData = new
            {
                UserID = UserID,
                Message = Message
            };
            HttpContext.Current.Response.Write(ser.Serialize(JSonData));
        }

        // this method for Students Login 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void login_Stu(int stu_university_id, string password)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            users login = new users();
            string Message = "";
            int UserID = login.login_Stu(stu_university_id, password);

            if (UserID == 0)
            {
                Message = "University ID Or Password Is Incorrect";
            }
            else
            {
                Message = "Successfully Login";
            }

            var JSonData = new
            {
                UserID = UserID,
                Message = Message
            };
            HttpContext.Current.Response.Write(ser.Serialize(JSonData));
        }



        // this method for add new student  
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void addNewStudents(int stu_university_id, string stu_full_name, string stu_password, string stu_gender, string stu_phone, string stu_college, string stu_specialty, string stu_level)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            int IsAdded = 1;
            string Message = "";
            users myusers = new users();
            if (myusers.IsAvailable_stu(stu_university_id) == 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("addNewStudent");
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("@stu_university_id", stu_university_id);
                        cmd.Parameters.AddWithValue("@stu_full_name", stu_full_name);
                        cmd.Parameters.AddWithValue("@stu_password", stu_password);
                        cmd.Parameters.AddWithValue("@stu_gender", stu_gender);
                        cmd.Parameters.AddWithValue("@stu_phone", stu_phone);
                        cmd.Parameters.AddWithValue("@stu_college", stu_college);
                        cmd.Parameters.AddWithValue("@stu_specialty", stu_specialty);
                        cmd.Parameters.AddWithValue("@stu_level", stu_level);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    Message = "Your Account Is Created Successfully .";
                }
                catch (Exception ex)
                {
                    IsAdded = 0;
                    Message = ex.Message;
                }
            }
            else
            {
                IsAdded = 0;
                Message = "University ID Is Reserved !!";
            }
            var jsonData = new
            {
                IsAdded = IsAdded,
                Message = Message
            };

            HttpContext.Current.Response.Write(ser.Serialize(jsonData));
        }


        // this method for add new  VIP
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void addNewVIP(int vip_job_id, string vip_full_name, string vip_password, string vip_gender, string vip_phone, string vip_job_name, string vip_college)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            int IsAdded = 1;
            string Message = "";
            users myusers = new users();
            if (myusers.IsAvailable_vip(vip_job_id) == 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("addNewVIP");
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("@vip_job_id", vip_job_id);
                        cmd.Parameters.AddWithValue("@vip_full_name", vip_full_name);
                        cmd.Parameters.AddWithValue("@vip_password", vip_password);
                        cmd.Parameters.AddWithValue("@vip_gender", vip_gender);
                        cmd.Parameters.AddWithValue("@vip_phone", vip_phone);
                        cmd.Parameters.AddWithValue("@vip_job_name", vip_job_name);
                        cmd.Parameters.AddWithValue("@vip_college", vip_college);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    Message = "Your Account Is Created Successfully .";
                }
                catch (Exception ex)
                {
                    IsAdded = 0;
                    Message = ex.Message;
                }
            }
            else
            {
                IsAdded = 0;
                Message = "VIP ID Is Reserved !!";
            }
            var jsonData = new
            {
                IsAdded = IsAdded,
                Message = Message
            };

            HttpContext.Current.Response.Write(ser.Serialize(jsonData));
        }


        // this method for add new  Admin
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void addNewAdmin(string session_Admin_username, string session_Admin_password, string Admin_username, string Admin_password)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            users myusers = new users();
            if (myusers.login_Admin(session_Admin_username, session_Admin_password) != 0)
            {
                int IsAdded = 1;
                string Message = "";
                if (myusers.IsAvailable_Admin(Admin_username) == 0)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                        {
                            SqlCommand cmd = new SqlCommand("addNewAdmin");
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("@Admin_username", Admin_username);
                            cmd.Parameters.AddWithValue("@Admin_password", Admin_password);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                        Message = "Your Account Is Created Successfully .";
                    }
                    catch (Exception ex)
                    {
                        IsAdded = 0;
                        Message = ex.Message;
                    }
                }
                else
                {
                    IsAdded = 0;
                    Message = "User Name Is Reserved !!";
                }
                var jsonData = new
                {
                    IsAdded = IsAdded,
                    Message = Message
                };

                HttpContext.Current.Response.Write(ser.Serialize(jsonData));
            }
            else
            {
                var JSonData = new
                {
                    Erorr = "Your username or password is incorrect !!"
                };
                HttpContext.Current.Response.Write(ser.Serialize(JSonData));
            }

        }

        // this method for add new Slots
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void AddSlots(string session_Admin_username, string session_Admin_password, string sl_name, string sl_location, int kind_id)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            int IsAdded = 0;
            string Message = "";
            users myusers = new users();
            if (myusers.login_Admin(session_Admin_username, session_Admin_password) != 0)
            {
                IsAdded = 1;


                try
                {
                    using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("AddSlots");
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("@sl_name", sl_name);
                        cmd.Parameters.AddWithValue("@sl_location", sl_location);
                        cmd.Parameters.AddWithValue("@kind_id", kind_id);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }

                    Message = "Slot Added Successfully .";
                }
                catch (Exception ex)
                {
                    IsAdded = 0;
                    Message = ex.Message;
                }

                var jsonData = new
                {
                    IsAdded = IsAdded,
                    Message = Message
                };

                HttpContext.Current.Response.Write(ser.Serialize(jsonData));
            }

            else
            {
                IsAdded = 0;
                Message = "Your username or password is incorrect !!";
                var JSonData = new
                {
                    IsAdded = IsAdded,
                    Message = Message
                };
                HttpContext.Current.Response.Write(ser.Serialize(JSonData));
            }

        }

        // this method to return all Available Slots For VIP 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getAvailableSlots_VIP()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();

            AvailableSlots[] getSlots_VIP = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("getAvailableSlots_VIP", connection);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable datatable = new DataTable();
                    sda.Fill(datatable);
                    getSlots_VIP = new AvailableSlots[datatable.Rows.Count];
                    int Count = 0;
                    for (int i = 0; i < datatable.Rows.Count; i++)
                    {
                        getSlots_VIP[Count] = new AvailableSlots();
                        getSlots_VIP[Count].sl_id = Convert.ToString(datatable.Rows[i]["sl_id"]);
                        getSlots_VIP[Count].sl_name = Convert.ToString(datatable.Rows[i]["sl_name"]);
                        getSlots_VIP[Count].kind_name = Convert.ToString(datatable.Rows[i]["kind_name"]);
                        getSlots_VIP[Count].sl_location = Convert.ToString(datatable.Rows[i]["sl_location"]);
                        getSlots_VIP[Count].sl_active = Convert.ToString(datatable.Rows[i]["sl_active"]);

                        Count++;
                    }
                    datatable.Clear();
                    connection.Close();

                }
            }
            catch (Exception ex)
            {

            }

            var JSonData = new
            {
                getSlots_VIP = getSlots_VIP
            };
            HttpContext.Current.Response.Write(ser.Serialize(JSonData));
        }


        // this method to return all Available Slots For Students 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getAvailableSlots_Stu()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();

            AvailableSlots[] getSlots_Stu = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("getAvailableSlots_Stu", connection);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable datatable = new DataTable();
                    sda.Fill(datatable);
                    getSlots_Stu = new AvailableSlots[datatable.Rows.Count];
                    int Count = 0;
                    for (int i = 0; i < datatable.Rows.Count; i++)
                    {
                        getSlots_Stu[Count] = new AvailableSlots();
                        getSlots_Stu[Count].sl_id = Convert.ToString(datatable.Rows[i]["sl_id"]);
                        getSlots_Stu[Count].sl_name = Convert.ToString(datatable.Rows[i]["sl_name"]);
                        getSlots_Stu[Count].kind_name = Convert.ToString(datatable.Rows[i]["kind_name"]);
                        getSlots_Stu[Count].sl_location = Convert.ToString(datatable.Rows[i]["sl_location"]);
                        getSlots_Stu[Count].sl_active = Convert.ToString(datatable.Rows[i]["sl_active"]);
                        Count++;
                    }
                    datatable.Clear();
                    connection.Close();

                }
            }
            catch (Exception ex)
            {

            }

            var JSonData = new
            {
                getSlots_Stu = getSlots_Stu
            };
            HttpContext.Current.Response.Write(ser.Serialize(JSonData));
        }

        // this method to return all Slots For Students  And VIP ( active or not active )
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getAllSlots()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();

            AvailableSlots[] getAllSlots = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("getAllSlots", connection);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable datatable = new DataTable();
                    sda.Fill(datatable);
                    getAllSlots = new AvailableSlots[datatable.Rows.Count];
                    int Count = 0;
                    for (int i = 0; i < datatable.Rows.Count; i++)
                    {
                        getAllSlots[Count] = new AvailableSlots();
                        getAllSlots[Count].sl_id = Convert.ToString(datatable.Rows[i]["sl_id"]);
                        getAllSlots[Count].sl_name = Convert.ToString(datatable.Rows[i]["sl_name"]);
                        getAllSlots[Count].kind_name = Convert.ToString(datatable.Rows[i]["kind_name"]);
                        getAllSlots[Count].sl_location = Convert.ToString(datatable.Rows[i]["sl_location"]);
                        getAllSlots[Count].sl_active = Convert.ToString(datatable.Rows[i]["sl_active"]);
                        Count++;
                    }
                    datatable.Clear();
                    connection.Close();

                }
            }
            catch (Exception ex)
            {

            }

            var JSonData = new
            {
                getAllSlots = getAllSlots
            };
            HttpContext.Current.Response.Write(ser.Serialize(JSonData));
        }


        // this method for send Feedback 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void sendFeedback(string feed_name, string feed_phone, string feed_mail, string feed_info)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            int IsAdded = 1;
            string Message = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sendFeedback");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@feed_name", feed_name);
                    cmd.Parameters.AddWithValue("@feed_phone", feed_phone);
                    cmd.Parameters.AddWithValue("@feed_mail", feed_mail);
                    cmd.Parameters.AddWithValue("@feed_info", feed_info);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                Message = "Your Feedback Is Sended Successfully .";
            }
            catch (Exception ex)
            {
                IsAdded = 0;
                Message = ex.Message;
            }
            var jsonData = new
            {
                IsAdded = IsAdded,
                Message = Message
            };

            HttpContext.Current.Response.Write(ser.Serialize(jsonData));
        }

        // this method for get all Feedback
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getAllFeedback()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            All_Feedback[] getFeedback = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("getAllFeedback", connection);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable datatable = new DataTable();
                    sda.Fill(datatable);
                    getFeedback = new All_Feedback[datatable.Rows.Count];
                    int Count = 0;
                    for (int i = 0; i < datatable.Rows.Count; i++)
                    {
                        getFeedback[Count] = new All_Feedback();
                        getFeedback[Count].feed_id = Convert.ToString(datatable.Rows[i]["feed_id"]);
                        getFeedback[Count].feed_name = Convert.ToString(datatable.Rows[i]["feed_name"]);
                        getFeedback[Count].feed_phone = Convert.ToString(datatable.Rows[i]["feed_phone"]);
                        getFeedback[Count].feed_mail = Convert.ToString(datatable.Rows[i]["feed_mail"]);
                        getFeedback[Count].feed_info = Convert.ToString(datatable.Rows[i]["feed_info"]);
                        Count++;
                    }
                    datatable.Clear();
                    connection.Close();

                }
            }
            catch (Exception ex)
            {

            }

            var JSonData = new
            {
                getFeedback = getFeedback
            };
            HttpContext.Current.Response.Write(ser.Serialize(JSonData));
        }



        // this method For Parking Students 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void Parking_Stu(int stu_id, int sl_id, string par_stu_time_come)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            int IsAdded = 1;
            string Message = "";
            Parking IsAvailable = new Parking();

            if (IsAvailable.parking_stu(sl_id) != 0)
            {
                Parking IsAvailable2 = new Parking();
                if (IsAvailable2.IsParking_stu(stu_id) == 0)
                {

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                        {
                            SqlCommand cmd = new SqlCommand("Parking_Stu");
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = connection;
                            cmd.Parameters.AddWithValue("@stu_id", stu_id);
                            cmd.Parameters.AddWithValue("@sl_id", sl_id);
                            cmd.Parameters.AddWithValue("@par_stu_time_come", par_stu_time_come);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                        Message = "Your Car Is Parking Successfully .";
                        using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                        {
                            connection.Open();
                            SqlCommand cmd = new SqlCommand("chanage_active", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@sl_id", sl_id);
                            cmd.Parameters.AddWithValue("@sl_active", 0);
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        IsAdded = 0;
                        Message = ex.Message;
                    }


                }
                else
                {
                    IsAdded = 0;
                    Message = "You are actually parking !!";
                }

           }
            else
            {
                IsAdded = 0;
                Message = "This Slot Not Available !!";
            }
            var jsonData = new
            {
                IsAdded = IsAdded,
                Message = Message
            };
            HttpContext.Current.Response.Write(ser.Serialize(jsonData));
        }


        // this method For Parking VIP 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void Parking_VIP(int vip_id, int sl_id, string par_vip_time_come)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            int IsAdded = 1;
            string Message = "";
            Parking IsAvailable = new Parking();
            if (IsAvailable.parking_vip(sl_id) != 0)
            {

                Parking IsAvailable2 = new Parking();
                if (IsAvailable2.IsParking_vip(vip_id) == 0)
                {
                    try
                {
                    using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("Parking_For_VIP");
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("@vip_id", vip_id);
                        cmd.Parameters.AddWithValue("@sl_id", sl_id);
                        cmd.Parameters.AddWithValue("@par_vip_time_come", par_vip_time_come);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    Message = "Your Car Is Parking Successfully .";
                    using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("chanage_active", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@sl_id", sl_id);
                        cmd.Parameters.AddWithValue("@sl_active", 0);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    IsAdded = 0;
                    Message = ex.Message;
                }

                }
                else
                {
                    IsAdded = 0;
                    Message = "You are actually parking !!";
                }

            }
            else
            {
                IsAdded = 0;
                Message = "This Slot Not Available !!";
            }
            var jsonData = new
            {
                IsAdded = IsAdded,
                Message = Message
            };

            HttpContext.Current.Response.Write(ser.Serialize(jsonData));
        }

        // this method to show where is my car for student 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void whereISMyCar_stu(int stu_id)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            whereIsMyCar_stu mycar = new whereIsMyCar_stu();
            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("whereISMyCar_stu", connection);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@stu_id", stu_id);
                    DataTable datatable = new DataTable();
                    sda.Fill(datatable);
                    int i = datatable.Rows.Count;
                    mycar.sl_id = Convert.ToString(datatable.Rows[i - 1]["sl_id"]);
                    mycar.stu_full_name = Convert.ToString(datatable.Rows[i - 1]["stu_full_name"]);
                    mycar.sl_name = Convert.ToString(datatable.Rows[i - 1]["sl_name"]);
                    mycar.sl_location = Convert.ToString(datatable.Rows[i - 1]["sl_location"]);
                    mycar.kind_name = Convert.ToString(datatable.Rows[i - 1]["kind_name"]);
                    mycar.par_stu_time_come = Convert.ToString(datatable.Rows[i - 1]["par_stu_time_come"]);
                    datatable.Clear();
                    connection.Close();

                }
            }
            catch (Exception ex)
            {

            }

            var JSonData = new
            {
                mycar = mycar
            };
            HttpContext.Current.Response.Write(ser.Serialize(JSonData));



        }


        // this method to show where is my car for VIP 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void whereISMyCar_vip(int vip_id)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            whereIsMyCar_vip mycar = new whereIsMyCar_vip();
            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("whereISMyCar_vip", connection);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@vip_id", vip_id);
                    DataTable datatable = new DataTable();
                    sda.Fill(datatable);
                    int i = datatable.Rows.Count;
                    mycar.sl_id = Convert.ToString(datatable.Rows[i - 1]["sl_id"]);
                    mycar.vip_full_name = Convert.ToString(datatable.Rows[i - 1]["vip_full_name"]);
                    mycar.sl_name = Convert.ToString(datatable.Rows[i - 1]["sl_name"]);
                    mycar.sl_location = Convert.ToString(datatable.Rows[i - 1]["sl_location"]);
                    mycar.kind_name = Convert.ToString(datatable.Rows[i - 1]["kind_name"]);
                    mycar.par_vip_time_come = Convert.ToString(datatable.Rows[i - 1]["par_vip_time_come"]);
                    datatable.Clear();
                    connection.Close();

                }
            }
            catch (Exception ex)
            {

            }

            var JSonData = new
            {
                mycar = mycar
            };
            HttpContext.Current.Response.Write(ser.Serialize(JSonData));

        }


        // this method to chanage active for any Slots 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void chanage_active(int sl_id, int sl_active)
        {
            int IsAdded = 1;
            string Message = "";
            JavaScriptSerializer ser = new JavaScriptSerializer();

            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("chanage_active", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sl_id", sl_id);
                    cmd.Parameters.AddWithValue("@sl_active", sl_active);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
                Message = "Active Was Chanage Successfully .";
            }
            catch (Exception ex)
            {
                IsAdded = 0;
                Message = "Can Not Chanage Active";
            }

            var JSonData = new
            {
                IsAdded = IsAdded,
                Message = Message
            };
            HttpContext.Current.Response.Write(ser.Serialize(JSonData));

        }


        // this method to leave Parking for stu 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void leaveParking_stu(int stu_id)
        {
            int IsAdded = 1;
            string Message = "";
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Parking IsAvailable2 = new Parking();
            if (IsAvailable2.IsParking_stu(stu_id) != 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("deleteparking_stu", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@stu_id", stu_id);
                        cmd.ExecuteNonQuery();
                        connection.Close();

                    }
                    Message = "You Are Left The Park Successfully .";
                }
                catch (Exception ex)
                {
                    IsAdded = 0;
                    Message = "Can Not Leave Park";
                }
            }
            else
            {
                IsAdded = 0;
                Message = "You are Not parking !!";
            }

            var JSonData = new
            {
                IsAdded = IsAdded,
                Message = Message
            };
            HttpContext.Current.Response.Write(ser.Serialize(JSonData));

        }

        // this method to leave Parking for vip 
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void leaveParking_vip(int vip_id)
        {
            int IsAdded = 1;
            string Message = "";
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Parking IsAvailable2 = new Parking();

            if (IsAvailable2.IsParking_vip(vip_id) != 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("deleteparking_vip", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@vip_id", vip_id);
                        cmd.ExecuteNonQuery();
                        connection.Close();

                    }
                    Message = "You Are Left The Park Successfully .";
                }
                catch (Exception ex)
                {
                    IsAdded = 0;
                    Message = "Can Not Leave Park";
                }

            }
            else
            {
                IsAdded = 0;
                Message = "You are Not parking !!";
            }
            var JSonData = new
            {
                IsAdded = IsAdded,
                Message = Message
            };
            HttpContext.Current.Response.Write(ser.Serialize(JSonData));

        }

    }

}

