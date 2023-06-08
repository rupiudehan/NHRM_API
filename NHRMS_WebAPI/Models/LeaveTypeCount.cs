using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class LeaveTypeCount:YearDetail
    {
        public int ID { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeaveTypeCode { get; set; }
        public string LeaveTypeName { get; set; }
        public float CountForMale { get; set; }
        public float CountForFemale { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
}