﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class BranchDetail:ManufacturingTime
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
    }
}