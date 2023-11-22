using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;

namespace NHRMS_WebAPI.Models
{
    public class YearDetail:MessageHandle
    {
        public int YearId { get; set; }
        public string Year { get; set; }
        public bool IsCurrentYear { get; set; }
    }
}