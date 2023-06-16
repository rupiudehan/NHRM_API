using ITInventory.Common;
using NHRMS_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NHRMS_WebAPI.Controllers
{
    public class StateController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        // GET api/<controller>
        [Route("app/GetStates/{stateID}/{countryID}")]
        public output GetStates(int stateID, int countryID)
        {
            output result = new output();
            try
            {
                List<State> obj = DAL.GetStateDetail(stateID, countryID);
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
