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
    public class DashboardDetailController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        [Route("app/GetTotalAttendanceCount/{EmployeeID}/{Officeid}")]
        public output GetTotalAttendanceCount(long EmployeeID, int Officeid)
        {
            output result = new output();
            try
            {
                List<DashboardAttendanceTotalCount> obj = DAL.GetTotalAttendanceCount(EmployeeID, Officeid);
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
