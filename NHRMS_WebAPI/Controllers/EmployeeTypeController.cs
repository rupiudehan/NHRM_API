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
    public class EmployeeTypeController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        // GET api/<controller>
        [Route("app/GetEmployeetypes/{employeeTypeID}")]
        public output GetEmployeetypes(int employeeTypeID)
        {
            output result = new output();
            try
            {
                List<EmployeeType> obj = DAL.GetEmployeetypeDetail(employeeTypeID);
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