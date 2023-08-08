using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class EmployeeCredentialDetail
    {
        public long EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmpPassword { get; set; }
        public string HrmsNo { get; set; }
    }
}