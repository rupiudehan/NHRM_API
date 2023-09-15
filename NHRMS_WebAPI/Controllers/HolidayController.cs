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
    public class HolidayController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        // GET api/<controller>
        [Route("app/GetHolidayTypeDetail/{typeID}")]
        public output GetHolidayTypeDetail(int typeID)
        {
            output result = new output();            
            try
            {
                List<HolidayType> obj = DAL.GetHolidayType(typeID);
                result = result.GetResponse(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("app/GetHolidayDetail/{typeID}/{id}")]
        public output GetHolidayDetail(int typeID, long id)
        {
            output result = new output();
            
            try
            {
                List<HolidayDetail> obj = DAL.GetHolidayDetail(typeID,id);

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
        [Route("app/CreateHolidayDetail")]
        public output CreateHolidayDetail(string date, int holidayTypeID, int districtID, long processedBy)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.CreateHolidayDetail(date, holidayTypeID, districtID, processedBy);
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
        [Route("app/DeleteHolidayDetail/{id}/{districtID}")]
        public output DeleteHolidayDetail(int id, int districtID)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.DeleteHolidayDetail(id,districtID);
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
        [Route("app/CreateHolidayWeekOffDetail")]
        public output CreateHolidayWeekOffDetail(long processedBy)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.CreateHolidayWeekOffDetail(processedBy);
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
