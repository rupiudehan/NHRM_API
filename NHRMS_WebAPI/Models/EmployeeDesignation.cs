using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class EmployeeDesignation:ManufacturingTime
    {
        public long ID { get; set; }
        public long EmployeeID { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public bool IsActive { get; set; }
    }
}