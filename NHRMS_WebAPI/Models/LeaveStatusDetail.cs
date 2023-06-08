using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class LeaveStatusDetail:ManufacturingTime
    {
        public int StatusID { get; set; }
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
    }
}