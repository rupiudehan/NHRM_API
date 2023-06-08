using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class DesignationDetail:ManufacturingTime
    {
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
    }
}