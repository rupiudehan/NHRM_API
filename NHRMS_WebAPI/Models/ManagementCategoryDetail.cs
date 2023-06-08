using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class ManagementCategoryDetail:MessageHandle
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int BossID { get; set; }
        public bool IsActive { get; set; }
        public string AuthorityName { get; set; }
    }
}