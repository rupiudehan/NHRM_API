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
    public class YearController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        // GET api/<controller>
        [Route("app/GetYears/{yearID}")]
        public output GetYears(int yearID)
        {
            output result = new output();
            try
            {
                List<YearDetail> obj = DAL.GetYearDetail(yearID);
                result = result.GetResponse<YearDetail>(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("app/CreateYearDetail")]
        public output CreateYearDetail(long processedBy)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.CreateYearDetail(processedBy);
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
