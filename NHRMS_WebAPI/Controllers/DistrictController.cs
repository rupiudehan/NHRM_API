using ITInventory.Common;
using NHRMS_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace NHRMS_WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        [HttpPost]
        [Route("app/CreateUpdateDistrictDetailPost")]
        //public output CreateUpdateCountryDetail(CountryDetail countryDetail)
        public output CreateUpdateDistrictDetail(int districtID, int stateID, string districtCode, string districtName, string processedBy)
        {
            District districtDetail = new District();
            districtDetail.StateID = stateID;
            districtDetail.DistrictID = districtID;
            districtDetail.DistrictCode = districtCode;
            districtDetail.ProcessedBy = processedBy;
            districtDetail.DistrictName = districtName;
            output result = new output();
            try
            {
                MessageHandle obj = DAL.CreateUpdateDistrictDetail(districtDetail);
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
        [Route("app/DeleteDistrictDetail/{districtID}")]
        public output DeleteDistrictDetail(int districtID)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.DeleteDistrictDetail(districtID);
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