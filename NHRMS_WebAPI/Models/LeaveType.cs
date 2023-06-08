using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class LeaveType:ManufacturingTime
    {
        public int LeaveTypeID { get; set; }
        public string LeaveTypeName { get; set; }
        public string LeaveTypeCode { get; set; }
        public bool IsAttachmentAllowed { get; set; }
    }
}