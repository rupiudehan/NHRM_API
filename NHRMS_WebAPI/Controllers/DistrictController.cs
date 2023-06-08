using ITInventory.Common;
using NHRMS_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace NHRMS_WebAPI.Controllers
{
    public class DistrictController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        // GET api/<controller>
        [Route("app/GetDistricts/{districtID}/{stateID}/{countryID}")]
        public output GetDistricts(int districtID,int stateID,int countryID)
        {
            output result = new output();
            try
            {
                List<District> obj = DAL.GetDistrictDetail(districtID, stateID, countryID);
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