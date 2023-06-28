using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class AttendanceMonthlyDetail
    {
        public string datedata { get; set; }
        public string attType { get; set; }
        public int YearName { get; set; }
        public int Monthname { get; set; }
        public string EmployeeName { get; set; }
        public string BranchName { get; set; }
        public string DesignationName { get; set; }
        public string MobNo { get; set; }
        public string Hrmsno { get; set; }
        public string attintime { get; set; }
        public string attouttime { get; set; }
        public string Officename { get; set; }
        public string type { get; set; }
        public string LeaveName { get; set; }
        public string date { get; set; }
        public string holiday { get; set; }
        public string TimeDiff { get; set; }
    }
}