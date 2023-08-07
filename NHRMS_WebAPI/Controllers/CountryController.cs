using ITInventory.Common;
using NHRMS_WebAPI.Extension;
using NHRMS_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NHRMS_WebAPI.Controllers
{
    [EnableCors(origins:"*",headers: "*", methods: "*")]
    public class CountryController : ApiController
    {
        MastersDataAccessLayer DAL = new MastersDataAccessLayer();
        // GET api/<controller>
        [HttpGet]
        [Route("app/GetCountryDetail/{CountryID}")]
        public output GetCountryDetail(int countryID)
        {
            output result = new output();
            try
            {
                List<CountryDetail> obj = DAL.GetCountryDetail(countryID);
                result = result.GetResponse(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
