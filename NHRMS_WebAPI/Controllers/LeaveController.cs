using ITInventory.Common;
using NHRMS_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        [Route("app/AddLeaveDetailPost")]
        public output AddLeaveDetail(LeaveDetail ld)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.AddLeaveDetail(ld);
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
        [Route("app/UpdateLeaveDetailPost")]
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

        [Route("app/GetEmployeeLeaveBalanceDetail/{EmployeeID}")]
        public output GetEmployeeLeaveBalanceDetail(long EmployeeID)
        {
            output result = new output();
            try
            {
                DataTable obj = DAL.GetEmployeeLeaveBalanceDetail(EmployeeID);
                //if (obj!=null)
                //{
                //    string jsonString = "[{";
                //    foreach (var item in obj)
                //    {
                //        jsonString += "\""+item.Key + "\":"+ item.Value + "\",";
                //    }
                //    jsonString = jsonString.Remove(jsonString.Length - 2, 1) + "}]";
                result.IsSucess = true;
                result.ResponseData = obj;
                //}

                //result = result.GetResponse(obj);
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
