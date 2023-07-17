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
    public class AttendanceController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        [HttpPost]
        [Route("app/MarkAttendance")]
        public output MarkAttendance(AttendanceMark att)
        {
            output result = new output();
            try
            {
                List<EmployeeAttendanceMarkDetail> obj = DAL.MarkAttendance(att);
                //result = result.GetResponsePost(obj, obj.Message);

                result = result.GetResponse(obj);
                foreach (EmployeeAttendanceMarkDetail item in obj)
                {
                    result.Message = item.Message;
                }
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

        //[Route("app/GetAttendanceDetail/{EmployeeID}")]
        //public output GetAttendanceDetail(long EmployeeID)
        //{
        //    output result = new output();
        //    try
        //    {
        //        List<EmployeeAttendanceMarkDetail> obj = DAL.GetAttendanceDetail(EmployeeID);
        //        result = result.GetResponse(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        result.IsSucess = false;
        //        result.Message = ex.Message;
        //    }
        //    return result;
        //}

        [Route("app/GetApprovalCategory/{categoryId}")]
        public output GetApprovalCategory(int categoryId)
        {
            output result = new output();
            try
            {
                List<ApprovalCategory>  obj = DAL.GetApprovalCategories(categoryId);
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
        [Route("app/CheckDaillyAttendanceDetail/{EmployeeID}/{SimId}")]
        public output CheckDaillyAttendanceDetail(long EmployeeID,string SimId)
        {
            output result = new output();
            try
            {
                int checkSim = DAL.CheckAttendanceDetail(EmployeeID, SimId);
                if (checkSim!=0)
                {
                    if (checkSim ==2)
                    {
                        result.IsSucess = true;
                        result.ResponseData = 2;
                        result.Message = "No attendance marked!";
                    }
                    else if (checkSim == 3)
                    {
                        result.IsSucess = true;
                        result.ResponseData = 3;
                        result.Message = "In attendance marked!";
                    }
                    else if (checkSim == 4)
                    {
                        result.IsSucess = true;
                        result.ResponseData = 4;
                        result.Message = "In and out attendance marked!";
                    }
                }
                else
                {
                    result.IsSucess = false;
                    result.ResponseData = 0;
                    result.Message = "Sim does not exists!";
                }
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("app/GetMonthlyAttendanceDetail")]
        public output GetMonthlyAttendanceDetail(long EmployeeID, string startDate, string endDate)
        {
            output result = new output();
            try
            {
                List<AttendanceMonthlyDetail> obj = DAL.GetMonthlyAttendanceDetail(EmployeeID,startDate,endDate);
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
