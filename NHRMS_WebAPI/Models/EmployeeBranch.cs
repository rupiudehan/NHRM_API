using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class EmployeeBranch:ManufacturingTime
    {
        public long ID { get; set; }
        public long EmployeeID { get; set; }
        public long BranchID { get; set; }
        public string BranchName { get; set; }
        public bool IsActive { get; set; }
    }
}