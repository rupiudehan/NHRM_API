using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class EmplyeeLeaveBalanceWithLeaveType:MessageHandle
    {
        public string LeaveTypeName { get; set; }
        public decimal LeaveBalance { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string HrmsNo { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public int EmployeeTypeID { get; set; }
        public string EmployeeTypeName { get; set; }
        public int GenderID { get; set; }
        public string GenderName { get; set; }
        public int OfficeID { get; set; }
        public string OfficeName { get; set; }
        public int BranchID { get; set; }
    }
}