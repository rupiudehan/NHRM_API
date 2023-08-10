using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class PendingLeaveDetail
    {
        public long ID { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeMobNo { get; set; }
        public string SimID { get; set; }
        public string LeaveCategoryName { get; set; }
        public int LeaveCategoryID { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeaveTypeName { get; set; }
        public string LeaveTourCode { get; set; }
        public string LeaveTour { get; set; }
        public string ApplyDatetime { get; set; }
        public string ApplyDate { get; set; }
        public long ReportingOfficerID { get; set; }
        public string ReportingOfficerName { get; set; }
        public string LeaveStatus { get; set; }
        public string ReportingOfficerDesignation { get; set; }
        public string ReportingOfficerMobNo { get; set; }
        public string ReportingOfficerHrms { get; set; }
        public string EmployeeHrms { get; set; }
        public string LeaveFromDate { get; set; }
        public string LeaveFromTime { get; set; }
        public string LeaveToDate { get; set; }
        public string LeaveToTime { get; set; }
        public bool IsAttachedDocument { get; set; }
        public string LeaveReason { get; set; }
        public string ApprovalDateTime { get; set; }
        public string EmployeeDesignation { get; set; }
        public int EmpBranchID { get; set; }
        public string EmpBranchName { get; set; }
        public string EmpOfficeName { get; set; }
        public string AttachmentID { get; set; }
        public string AttachmentUrl { get; set; }
        public string LeaveDates { get; set; }
    }
}