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
    public class LeaveStatusController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        [Route("app/GetLeaveStatus/{statusId}")]
        public output GetLeaveStatus(int statusId)
        {            
            output result = new output();
            try
            {
                List<LeaveStatusDetail> obj = DAL.GetLeaveStatus(statusId);
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
