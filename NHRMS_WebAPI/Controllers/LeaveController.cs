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
        [HttpGet]
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
        [HttpGet]
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

        [HttpPost]
        [Route("app/LeaveAutoDeductPost")]
        public output LeaveAutoDeductPost(LeaveAutoDeductDetail ld)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.LeaveAutoDeduct(ld);
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
        [HttpGet]
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
        [HttpGet]
        [Route("app/GetEmployeeLeaveBalanceDetailWithLeaveType")]
        public output GetEmployeeLeaveBalanceDetailWithLeaveType(long EmployeeID, string YearName, int LeaveTypeID, string hrmsNo=null)
        {
            output result = new output();
            try
            {
                List<EmplyeeLeaveBalanceWithLeaveType> obj = DAL.GetEmployeeLeaveBalanceDetailWithLeaveType(EmployeeID, YearName, LeaveTypeID, hrmsNo);
                result = result.GetResponse(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("app/GetLeaveDateUnlockDetail")]
        public output GetLeaveDateUnlockDetail(long EmployeeID, string hrmsNo = null)
        {
            output result = new output();
            try
            {
                List<LeaveUnlockDetail> obj = DAL.GetLeaveDateUnlockDetail(EmployeeID, hrmsNo);
                result = result.GetResponse(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("app/GetPendingLeaveDetail/{reportingOfficerID}/{leaveTour}/{designationid}")]
        public output GetPendingLeaveDetail(long reportingOfficerID, string leaveTour, int designationid=0)
        {
            output result = new output();
            try
            {
                List<PendingLeaveDetail> obj = DAL.GetPendingLeaveDetail(reportingOfficerID, leaveTour, designationid);
                result = result.GetResponse(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("app/GetLeaveStatusDetailLevel1")]
        public output GetLeaveStatusDetailLevel1(long EmployeeID, string hrmsNo, string startDate, string endDate, string leaveTour, long reportingOfficerID=0, int designationid = 0)
        {
            output result = new output();
            try
            {
                List<PendingLeaveDetail> obj = DAL.GetLeaveStatusDetailLevel1(EmployeeID, hrmsNo, startDate, endDate, leaveTour,reportingOfficerID, designationid);
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
