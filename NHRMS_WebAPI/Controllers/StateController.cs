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

        [HttpPost]
        [Route("app/CreateUpdateStateDetailPost")]
        //public output CreateUpdateCountryDetail(CountryDetail countryDetail)
        public output CreateUpdateStateDetail(int stateID, int countryID, string stateCode, string stateName, string postalCode, string processedBy)
        {
            State stateDetail = new State();
            stateDetail.CountryId = countryID;
            stateDetail.StateName = stateName;
            stateDetail.StateCode = stateCode;
            stateDetail.ProcessedBy = processedBy;
            stateDetail.PostalCode = postalCode;
            stateDetail.StateID = stateID;
            output result = new output();
            try
            {
                MessageHandle obj = DAL.CreateUpdateStateDetail(stateDetail);
                result = result.GetResponsePost(obj, obj.Message);
                result.IsSucess = Convert.ToBoolean(obj.Success);
                result.Message = obj.Message;
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            finally
            {

            }

            return result;

        }

        [HttpPost]
        [Route("app/DeleteStateDetail/{stateID}")]
        public output DeleteStateDetail(int stateID)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.DeleteStateDetail(stateID);
                result = result.GetResponsePost(obj, obj.Message);
                result.IsSucess = Convert.ToBoolean(obj.Success);
                result.Message = obj.Message;
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            finally
            {

            }

            return result;

        }
    }
}
