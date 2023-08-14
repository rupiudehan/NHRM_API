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

        [HttpPost]
        [Route("app/CreateUpdateCityDetailPost")]
        //public output CreateUpdateCountryDetail(CountryDetail countryDetail)
        public output CreateUpdateCityDetail(int ID, int districtID,  string cityCode, string cityName,string postalCode, string processedBy)
        {
            City cityDetail = new City();
            cityDetail.CityID = ID;
            cityDetail.DistrictID = districtID;
            cityDetail.CityCode = cityCode;
            cityDetail.CityName = cityName;
            cityDetail.PostalCode = postalCode;
            cityDetail.ProcessedBy = processedBy;
            output result = new output();
            try
            {
                MessageHandle obj = DAL.CreateUpdateCityDetail(cityDetail);
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
        [Route("app/DeleteCityDetail/{cityID}")]
        public output DeleteCityDetail(int cityID)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.DeleteCityDetail(cityID);
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