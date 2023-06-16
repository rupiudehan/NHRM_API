﻿using ITInventory.Common;
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
                MessageHandle obj = DAL.MarkAttendance(att);
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

        [Route("app/GetAttendanceDetail/{EmployeeID}")]
        public output GetAttendanceDetail(long EmployeeID)
        {
            output result = new output();
            try
            {
                List<EmployeeAttendanceMarkDetail> obj = DAL.GetAttendanceDetail(EmployeeID);
                result = result.GetResponse(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

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
    }
}
