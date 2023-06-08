using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class ReportingAuthorityDetail:MessageHandle
    {
        public long EmployeeID { get; set; }
        public long AuthorityID { get; set; }
        public string ProcessedBy { get; set; }
    }

    public class ReportingAuthorityDetailFetch : ManufacturingTime
    {
        public long ID { get; set; }
        public long EmployeeID { get; set; }
        public long AuthorityID { get; set; }
        public string AuthorityName { get; set; }
        public int AuthorityDesignationID { get; set; }
        public string AuthorityDesignationName { get; set; }
        public int AuthorityOfficeIDR { get; set; }
        public string AuthorityOfficeName { get; set; }
        public string EmployeeName { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public int OfficeID { get; set; }
        public string OfficeName { get; set; }
        public bool IsActive { get; set; }
    }
}