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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        [HttpPost]
        [Route("app/CreateUpdateCountryDetailPost")]
        //public output CreateUpdateCountryDetail(CountryDetail countryDetail)
        public output CreateUpdateCountryDetail(int countryid,string countrycode,string countryName,int commCode,string processedBy)
        {
            CountryDetail countryDetail=new CountryDetail();
            countryDetail.CountryId = countryid;
            countryDetail.CountryName = countryName;
            countryDetail.CommCode = commCode;
            countryDetail.ProcessedBy = processedBy;
            countryDetail.CountryCode = countrycode;
            output result = new output();
            try
            {
                MessageHandle obj = DAL.CreateUpdateCountryDetail(countryDetail);
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
        [Route("app/DeleteCountryDetail/{countryID}")]
        public output DeleteCountryDetail(int countryID)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.DeleteCountryDetail(countryID);
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
