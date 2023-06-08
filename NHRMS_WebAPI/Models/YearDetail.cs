using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class YearDetail:MessageHandle
    {
        public int YearId { get; set; }
        public string Year { get; set; }
    }
}