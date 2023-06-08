using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class EmployeeType:ManufacturingTime
    {
        public int EmployeeTypeID { get; set; }
        public string EmployeeTypeName { get; set; }
    }
}