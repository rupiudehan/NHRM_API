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
    public class LeaveController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        // GET api/<controller>
        [Route("app/GetLeaveTourMaster")]
        public output GetLeaveTourMaster()
        {
            output result = new output();
            try
            {
                List<LeaveTourMaster> obj = DAL.GetLeaveTourMasterDetail();
                result = result.GetResponse(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("app/GetLeaveBalanceDetail/{EmployeeID}/{leaveTypeID}")]
        public output GetLeaveBalanceDetail(long EmployeeID, int leaveTypeID)
        {
            output result = new output();
            try
            {
                List<AttendanceBalanceDetail> obj = DAL.GetLeaveBalanceDetail(EmployeeID,leaveTypeID);
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
        [Route("app/AddLeaveDetail")]
        public output AddLeaveDetail(LeaveDetail ld)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.AddLeaveDetail(ld);
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
        [HttpPost]
        [Route("app/UpdateLeaveDetail")]
        public output UpdateLeaveDetail(EditLeaveDetail ld)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.UpdateLeaveDetail(ld);
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
    }
}
