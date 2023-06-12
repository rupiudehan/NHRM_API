using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class Gender:MessageHandle
    {
        public int GenderID { get; set; }
        public string GenderName { get; set; }
    }
}