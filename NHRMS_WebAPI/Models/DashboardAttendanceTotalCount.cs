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

    public class DashboardTotalPending
    {
        public int TotalCount { get; set; }
    }

    public class DashboardTotalAttendance
    {
        public int EmployeeCount { get; set; }
        public string OfficeName { get; set; }
        public int OfficeID { get; set; }
        public string BranchName { get; set; }
        public int BranchID { get; set; }
    }

    public class DashboardReport
    {
        public long ID { get; set;}
        public long EmployeeID { get; set; }
        public string AttInDate { get; set; }
        public string AttInTime { get; set; }
        public string AttOutTime { get; set; }
        public string TimeDiff { get; set; }
        public string EmployeeName { get; set; }
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public int EmployeeTypeID { get; set; }
        public string EmployeeTypeName { get; set; }
        public string HrmsNo { get; set; }
        public int GenderID { get; set; }
        public string GenderName { get; set; }
        public string MobileNo { get; set; }
        public int OfficeID { get; set; }
        public string OfficeName { get; set; }
        public string OfficeLattitute { get; set; }
        public string OfficeLongitute { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public string RegDate { get; set; }
        public string SimID { get; set; }
        public bool ISActive { get; set; }
        public string Adharcard { get; set; }
        public bool InactiveForAttendance { get; set; }
        public string DateOfInActive { get; set; }
        public string DateOfInactiveForAttendance { get; set; }
        public string DateofJoining { get; set; }
        public string DateOfServiceEnd { get; set; }
    }
}