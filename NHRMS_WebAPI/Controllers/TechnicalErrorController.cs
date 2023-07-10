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
    public class TechnicalErrorController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        [HttpPost]
        [Route("app/AddTechnicalErrorDetailPost")]
        public output AddTechnicalErrorDetail(TechErrorCreate ld)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.AddTechnicalErrorDetail(ld);
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
        [Route("app/UpdateTechnicalErrorDetailPost")]
        public output UpdateTechnicalErrorDetail(TechErrorEdit ld)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.UpdateTechnicalErrorDetail(ld);
                result = result.GetResponsePost(obj, obj.Message);
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

        [Route("app/GetTechErrorStatus")]
        public output GetTechErrorStatus(long EmployeeID, string hrmsNo, string startDate, string endDate)
        {
            output result = new output();
            try
            {
                List<TechnicalErrorStatus> obj = DAL.GetTechErrorStatus(EmployeeID, hrmsNo, startDate, endDate);
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
