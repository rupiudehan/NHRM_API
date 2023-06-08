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
    public class LeaveTypeController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        
        [Route("app/GetLeavetypes/{employeeTypeID}")]
        public output GetLeavetypes(int employeeTypeID)
        {
            output result = new output();
            try
            {
                List<LeaveType> obj = DAL.GetLeavetypeDetail(employeeTypeID);
                result = result.GetResponse(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("app/GetLeavetypeCountDetail/{id}/{yearID}/{leaveTypeID}")]
        public output GetLeavetypeCountDetail(int id, int yearID, int leaveTypeID)
        {
            output result = new output();
            try
            {
                List<LeaveTypeCount> obj = DAL.GetLeaveTypeCount(id, yearID, leaveTypeID);
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
