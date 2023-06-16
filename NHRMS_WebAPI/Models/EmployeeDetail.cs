using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class EmployeeDetail:MessageHandle
    {
        public long EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int GenderID { get; set; }
        public string GenderName { get; set; }
        public string EmpPassword { get; set; }
        public string RegDate { get; set; }
        public string MobileNo { get; set; }
        public int DesignationID { get; set; }
        public int OfficeID { get; set; }
        public int BranchID { get; set; }
        public string BranchIDs { get; set; }
        public string BranchNames { get; set; }
        public string SimID { get; set; }
        public string AdharCard { get; set; }
        public string HrmsNo { get; set; }
        public int EmployeeTypeID { get; set; }
        public string DesignationName { get; set; }        
        public string DesignationNames { get; set; }
        public string DesignationIDs { get; set; }
        public string OfficeName { get; set; }
        public string OfficeLattitute { get; set; }
        public string OfficeLongitute { get; set; }
        public string EmployeeTypeName { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public string DateofInActive { get; set; }
        public string DateofJoining { get; set; }
        public string DateofTransfer { get; set; }
        public bool InactiveForAttendance { get; set; }
        public string DateOfInactiveForAttendance { get; set; }
        public string ProcessedBy { get; set; }
    }
}