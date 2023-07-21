using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class TechnicalErrorStatus
    {
        public string ErrorMessageDetail { get; set; }
        public string EmployeeName { get; set; }
        public string MobNo { get; set; }
        public string ErrorDate { get; set; }
        public string ApprovalStatus { get; set; }
        public string StatusUpdationDate { get; set; }
        public string Remarks { get; set; }
        public string ApprovalDateTime { get; set; }
    }
}