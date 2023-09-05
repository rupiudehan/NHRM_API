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
    public class OfficeController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        // GET api/<controller>
        [Route("app/GetOffices/{officeID}/{cityID}/{districtID}/{stateID}/{countryID}")]
        public output GetOffices(int officeID,int cityID, int districtID, int stateID, int countryID)
        {
            output result = new output();
            try
            {
                List<OfficeDetail> obj = DAL.GetOfficeDetail(officeID, cityID, districtID, stateID, countryID);
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
        [Route("app/CreateUpdateOfficeDetailPost")]
        public output CreateUpdateOfficeDetail(int id, int cityID, string officeName, string latitute, string longitute, string processedBy)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.CreateUpdateOfficeDetail(id, cityID, officeName, latitute, longitute, processedBy);
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
        [Route("app/DeleteOfficeDetail/{id}")]
        public output DeleteOfficeDetail(int id)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.DeleteOfficeDetail(id);
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

        [Route("app/GetOfficesDetailWithoutTiming/{officeID}/{cityID}/{districtID}/{stateID}/{countryID}")]
        public output GetOfficesDetailWithoutTiming(int officeID, int cityID, int districtID, int stateID, int countryID)
        {
            output result = new output();
            try
            {
                List<OfficeDetail> obj = DAL.GetOfficeDetailWithoutTiming(officeID, cityID, districtID, stateID, countryID);
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
        [Route("app/SetOfficeTimeDetailPost")]
        public output SetOfficeTimeDetailPost(int officeID, string inTime, string outTime, string halfTime, string shortTime, string processedBy)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.SetOfficeTimeDetail(officeID, inTime, outTime, halfTime, shortTime, processedBy);
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