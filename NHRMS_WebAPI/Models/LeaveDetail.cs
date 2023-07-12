using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class LeaveDetail:MessageHandle
    {
        public long EmployeeID { get; set; }
        public string LeaveFromDate { get; set; }
        public string LeaveFromTime { get; set; }
        public string LeaveToDate { get; set; }
        public string LeaveToTime { get; set; }
        public int LeaveCategoryID { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeaveTypeT { get; set; }
        public string LeaveReason { get; set; }
        public long ApprovingAuthorityID { get; set; }
        public bool IsAttachedDocumets { get; set; }
        public string AttachDocUrls { get; set; }
        public string StatusUpdatedBy { get; set; }
        public int LeaveStatusID { get; set; }
        public string HrmsNo { get; set; }
        public string bytedata { get; set; }
        public int ROfficerDesignationID { get; set; }
        public int ROfficeDeptID { get; set; }
        public string fileExtension { get; set; }
    }

    public class EditLeaveDetail : MessageHandle
    {
        public long ID { get; set; }
        public long EmployeeID { get; set; }
        public string LeaveFromDate { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeaveTypeT { get; set; }
        public string LeaveStatus { get; set; }
        public string Remarks { get; set; }
        public string ApprovalFlow { get; set; }
        public long StatusUpdatedBy { get; set; }
    }
}