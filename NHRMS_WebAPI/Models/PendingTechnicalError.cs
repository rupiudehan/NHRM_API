using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class PendingTechnicalError
    {
        public long ID { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeMobNo { get; set; }
        public string SimID { get; set; }
        public string ErrorDate { get; set; }
        public long ReportingOfficerID { get; set; }
        public string ReportingOfficerName { get; set; }
        public string TechErrorStatus { get; set; }
        public string ReportingOfficerDesignation { get; set; }
        public string ReportingOfficerMobNo { get; set; }
        public string ReportingOfficerHrms { get; set; }
        public string EmployeeHrms { get; set; }
        public string AttachmentDocument { get; set; }
        public string ErrorMessageDetail { get; set; }
        public string EmployeeDesignation { get; set; }
        public string EmpBranchName { get; set; }
        public long EmpBranchID { get; set; }
        public string EmpOfficeName { get; set; }
    }
}