using ITInventory.Common;
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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CityController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        // GET api/<controller>
        [Route("app/GetCities/{cityID}/{districtID}/{stateID}/{countryID}")]
        public output GetCities(int cityID,int districtID, int stateID, int countryID)
        {
            output result = new output();
            try
            {
                List<City> obj = DAL.GetCityDetail(cityID, districtID, stateID, countryID);
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