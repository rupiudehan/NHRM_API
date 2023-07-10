using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class TechErrorCreate
    {
        public string Errormessage { get; set; }
        public string HrmsNo { get; set; }
        public long EmployeeID { get; set; }
        public long AuthorityID { get; set; }
        public string Attachdocument { get; set; }
        public string ProcessedBy { get; set; }
        public string bytedata { get; set; }
    }

    public class TechErrorEdit
    {
        public string Remarks { get; set; }
        public long ID { get; set; }
        public string Status { get; set; }
        public string ApprovalFlow { get; set; }
        public long StatusUpdatedBy { get; set; }
    }
}