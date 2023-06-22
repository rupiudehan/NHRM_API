using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class EmployeeLeaveTypeMasterDetail:ManufacturingTime
    {
        public long LeaveID { get; set; }
        public long EmployeeID { get; set; }
        public int YearID { get; set; }
        public string Year { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeaveName { get; set; }
        public string LeaveCode { get; set; }
        public decimal LeaveCount { get; set; }
        public string EmployeeName { get; set; }
        public string HrmsNo { get; set; }
        public string MobNo { get; set; }
        public string SimID { get; set; }
        public string Adharcard { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public int EmployeeTypeID { get; set; }
        public string EmployeeTypeName { get; set; }
        public int OfficeID { get; set; }
        public string OfficeName { get; set; }
        public double OfficeLattitute { get; set; }
        public double OfficeLongitute { get; set; }
        public bool ISActive { get; set; }
    }
}