using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class FetchHrmsCode:MessageHandle
    {
        public string HrmsCode { get; set; }
    }
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
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public int DistrictID { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public int StateID { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public int CountryID { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
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
        public bool HasApprovingAuthorization { get; set; }
        public int DesignationLevel { get; set; }
        public string OfficeInTime { get; set; }
        public string OfficeOutTime { get; set; }
        public string OfficeHalfDayTime { get; set; }
        public string OfficeShortLeaveTime { get; set; }
        public int OfficeTimingID { get; set; }
        public long ReportingAuthorityID { get; set; }
        public string ReportingAuthorityName { get; set; }
    }
}