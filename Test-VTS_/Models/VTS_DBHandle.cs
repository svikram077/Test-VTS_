using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Test_VTS_.Models
{
    public class VTS_DBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["Connection_VTS"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW User *********************
        public bool AddUser(User uModel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", uModel.Name);
            cmd.Parameters.AddWithValue("@Mobile_Number", uModel.Mobile_Number);
            cmd.Parameters.AddWithValue("@Organisation", uModel.Organisation);
            cmd.Parameters.AddWithValue("@Address", uModel.Address);
            cmd.Parameters.AddWithValue("@Email", uModel.Email);
            cmd.Parameters.AddWithValue("@Location", uModel.Location);
            cmd.Parameters.AddWithValue("@Photo_Path", uModel.Photo_Path);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW User DETAILS ********************
        public List<User> GetUserDetails()
        {
            connection();
            List<User> userlist = new List<User>();

            SqlCommand cmd = new SqlCommand("GetUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                userlist.Add(
                    new User
                    {
                        UserID = Convert.ToInt32(dr["UserID"]),
                        Name = Convert.ToString(dr["Name"]),
                        Mobile_Number = Convert.ToString(dr["Mobile_Number"]),
                        Organisation= Convert.ToString(dr["Organisation"]),
                        Address = Convert.ToString(dr["Address"]),
                        Email = Convert.ToString(dr["Email"]),
                        Location = Convert.ToString(dr["Location"]),
                        Photo_Path = Convert.ToString(dr["Photo_Path"])
                    });
            }
            return userlist;
        }

        // ***************** UPDATE User DETAILS *********************
        public bool UpdateDetails(User uModel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", uModel.UserID);
            cmd.Parameters.AddWithValue("@Name", uModel.Name);
            cmd.Parameters.AddWithValue("@Mobile_Number", uModel.Mobile_Number);
            cmd.Parameters.AddWithValue("@Organisation", uModel.Organisation);
            cmd.Parameters.AddWithValue("@Address", uModel.Address);
            cmd.Parameters.AddWithValue("@Email", uModel.Email);
            cmd.Parameters.AddWithValue("@Location", uModel.Location);
            cmd.Parameters.AddWithValue("@Photo_Path", uModel.Photo_Path);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE User DETAILS *******************
        public bool DeleteUser(int UserID)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", UserID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        //***************************************************
        //           Vehivle Code
        //**************************************************

        // **************** ADD NEW STUDENT *********************
        public bool AddVehicle(Vehicle vmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddVehicle", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Vehicle_Number", vmodel.Vehicle_Number);
            cmd.Parameters.AddWithValue("@Vehicle_Type", vmodel.Vehicle_Type);
            cmd.Parameters.AddWithValue("@Chassis_Number", vmodel.Chassis_Number);

            cmd.Parameters.AddWithValue("@Engine_Number", vmodel.Engine_Number);
            cmd.Parameters.AddWithValue("@MFG_Year", vmodel.MFG_Year);
            cmd.Parameters.AddWithValue("@Load_Capacity", vmodel.Load_Capacity);
            cmd.Parameters.AddWithValue("@MakeOfVehicle", vmodel.MakeOfVehicle);
            cmd.Parameters.AddWithValue("@Model_Number", vmodel.Model_Number);
            cmd.Parameters.AddWithValue("@Body_Type", vmodel.Body_Type);
            cmd.Parameters.AddWithValue("@Organisation_Name", vmodel.Organisation_Name);
            cmd.Parameters.AddWithValue("@DeviceID", vmodel.DeviceID);
            cmd.Parameters.AddWithValue("@UsrID", vmodel.UsrID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW STUDENT DETAILS ********************
        public List<Vehicle> GetVehicleDetils()
        {
            connection();
            List<Vehicle> vehiclelist = new List<Vehicle>();

            SqlCommand cmd = new SqlCommand("GetVehicleDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                vehiclelist.Add(
                    new Vehicle
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Vehicle_Number = Convert.ToString(dr["Vehicle_Number"]),
                        Vehicle_Type = Convert.ToString(dr["Vehicle_Type"]),
                        Chassis_Number = Convert.ToString(dr["Chassis_Number"]),
                        Engine_Number = Convert.ToString(dr["Engine_Number"]),

                        MFG_Year = Convert.ToString(dr["MFG_Year"]),
                        Load_Capacity = Convert.ToString(dr["Load_Capacity"]),
                        MakeOfVehicle = Convert.ToString(dr["MakeOfVehicle"]),
                        Model_Number = Convert.ToString(dr["Model_Number"]),
                        Body_Type = Convert.ToString(dr["Body_Type"]),
                        Organisation_Name = Convert.ToString(dr["Organisation_Name"]),
                        DeviceID = Convert.ToString(dr["DeviceID"]),
                        UsrID = Convert.ToString(dr["UsrID"])

                    });
            }
            return vehiclelist;
        }

        // ***************** UPDATE Vehicle DETAILS *********************
        public bool UpdateVehicleDetails(Vehicle vModel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateVehicleDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            
            cmd.Parameters.AddWithValue("@Vehicle_Number", vModel.Vehicle_Number);
            cmd.Parameters.AddWithValue("@Vehicle_Type", vModel.Vehicle_Type);
            cmd.Parameters.AddWithValue("@Chassis_Number", vModel.Chassis_Number);

            cmd.Parameters.AddWithValue("@Engine_Number", vModel.Engine_Number);
            cmd.Parameters.AddWithValue("@MFG_Year", vModel.MFG_Year);
            cmd.Parameters.AddWithValue("@Load_Capacity", vModel.Load_Capacity);
            cmd.Parameters.AddWithValue("@MakeOfVehicle", vModel.MakeOfVehicle);
            cmd.Parameters.AddWithValue("@Model_Number", vModel.Model_Number);
            cmd.Parameters.AddWithValue("@Body_Type", vModel.Body_Type);
            cmd.Parameters.AddWithValue("@Organisation_Name", vModel.Organisation_Name);
            cmd.Parameters.AddWithValue("@DeviceID", vModel.DeviceID);
            cmd.Parameters.AddWithValue("@UsrID", vModel.UsrID);
            cmd.Parameters.AddWithValue("@ID", vModel.UsrID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE Vehicle DETAILS *******************
        public bool DeleteVehicle(int ID)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteVehicle", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", ID);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

    }
}