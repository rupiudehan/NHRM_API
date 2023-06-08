using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class City:District
    {
        public long CityID { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string CityPostalCode { get; set; }
    }
}