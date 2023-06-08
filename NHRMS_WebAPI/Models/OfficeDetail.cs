using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class OfficeDetail:City
    {
        public int OfficeID { get; set; }
        public string OfficeName { get; set; }
        public string OfficeLattitute { get; set; }
        public string OfficeLongitute { get; set; }
    }
}