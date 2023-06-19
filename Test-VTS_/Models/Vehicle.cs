using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Test_VTS_.Models
{
    public class Vehicle
    {
        
        public string Vehicle_Number { get; set;}
        public string Vehicle_Type { get; set;}
        public string Chassis_Number { get; set; }
        public string Engine_Number { get; set; }
        public string MFG_Year { get; set; }
        public string Load_Capacity { get; set; }
        public string MakeOfVehicle { get; set; }
        public string Model_Number { get; set; }
        public string Body_Type { get; set; }
        public string Organisation_Name { get; set; }
        public string DeviceID { get; set; }
        public string UsrID { get; set; }
        public int ID { get; set; }

    }

    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Mobile_Number { get; set; }
        public string Organisation { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Photo_Path { get; set; }
    }
}