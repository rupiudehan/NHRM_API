using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class AttendanceMark:MessageHandle
    {
        public long EmployeeId { get; set; }
        public string SimId { get; set; }
        public string InLatitude { get; set; }
        public string InLongitude { get; set; }
        public string OutLatitude { get; set; }
        public string OutLongitude { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public int IsInTime { get; set; }
    }

    public class EmployeeAttendanceMarkDetail: AttendanceMark
    {
        public string EmployeeName { get; set; }
        public string TimeDiff { get; set; }
        public string DateofJoining { get; set; }
        public string HrmsNo { get; set; }
        public string MobNo { get; set; }
        public string OldTimeDiiff { get; set; }
        public string OutTimeOld { get; set; }
        public string InTimeOld { get; set; }
        public int isHoliday { get; set; }
        public string AttInDate { get; set; }
        public int result { get; set; }
    }

    public class AttendanceBalanceDetail:MessageHandle
    {
        public string hrmscode { get; set; }
        public int OfficeID { get; set; }
        public long EmployeeID { get; set; }
    }
}