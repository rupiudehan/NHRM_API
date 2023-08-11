using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class LeaveUnlockDetail:MessageHandle
    {
        public string HrmsNo { get; set; }
        public long ID { get; set; }
        public int OfficeID { get; set; }
        public long BranchID { get; set; }
        public int DesignationID { get; set; }
        public long EmployeeID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string EnteryDate { get; set; }
        public int NoOfDays { get; set; }
    }
}