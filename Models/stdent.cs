using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sample_mvc3.Models
{
    public class studentinformatiom
    {
        public string First_name { get; set; }
        public string Second_name { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public System.DateTime Joining_date { get; set; }
        public enum gender { Male,Female }
       
    }
    
}