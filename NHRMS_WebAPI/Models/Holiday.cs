using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class HolidayType:ManufacturingTime
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public bool IsActive { get; set; }
    }

    public class HolidayDetail : HolidayType
    {
        public long ID { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string Holiday { get; set; }
    }
}