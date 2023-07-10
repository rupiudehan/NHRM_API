using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class DashboardAttendanceTotalCount
    {
        public int AbsentTotal { get; set; }
        public int PresentTotal { get; set; }
        public int TotalStrength { get; set; }
        public int LeaveTotal { get; set; }
        public int TourTotal { get; set; }
    }
}