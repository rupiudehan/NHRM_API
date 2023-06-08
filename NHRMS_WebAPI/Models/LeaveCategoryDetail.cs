using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class LeaveCategoryDetail:MessageHandle
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool IsVisible { get; set; }
    }
}