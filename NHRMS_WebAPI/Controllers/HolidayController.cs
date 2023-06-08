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
    }
}
