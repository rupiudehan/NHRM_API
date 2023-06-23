using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class LeaveAutoDeductDetail:MessageHandle
    {
        public long EmployeeID { get; set; }
        public string LeaveFromDate { get; set; }
        public string LeaveFromTime { get; set; }
        public string LeaveToDate { get; set; }
        public string LeaveToTime { get; set; }
        public int LeaveCategoryID { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeaveTypeT { get; set; }
        public long ApprovingAuthorityID { get; set; }
        public int ROfficerDesignationID { get; set; }
        public int ROfficeDeptID { get; set; }
    }
}