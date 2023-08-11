using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Models
{
    public class Country: ManufacturingTime
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
    public class State:Country
    {
        public int StateID { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string PostalCode { get; set; }
        public string ProcessedBy { get; set; }
    }
    public class District: State
    {
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public string DistrictCode { get; set;}
    }
}