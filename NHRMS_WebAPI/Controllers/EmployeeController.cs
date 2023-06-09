﻿using ITInventory.Common;
using NHRMS_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace NHRMS_WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        [HttpPost]
        [Route("app/EmpRegAttendancePost")]
        public output EmpRegpost(EmployeeDetail user)
        {
            output result = new output();
            try
            {                
                MessageHandle obj= DAL.EmployeeRegiatrationForAttendance(user);
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
                //result.ResponseData = 2;
            }

            return result;          
            

        }

        [HttpPost]
        [Route("app/EmployeeDeletePost/{empID}")]
        public output EmployeeDelete(long empID)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeDetailDelete(empID);
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
                //result.ResponseData = 2;
            }

            return result;


        }

        [HttpPost]
        [Route("app/EmpRegUpdatepost")]
        public output EmpRegUpdatepost(EmployeeDetail user)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeUpdationForAttendance(user);
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
                //result.ResponseData = 2;
            }

            return result;


        }

        [HttpGet]
        [Route("app/GenerateHrmsCode/{Prefix}")]
        public output GenerateHrmsCode(string Prefix)
        {
            output result = new output();
            try
            {
                List<FetchHrmsCode> obj = DAL.GenerateHrmsCode(Prefix);
                result = result.GetResponse(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("app/GetLoginEmployee")]
        public output GetLoginEmployee(string username, string password)
        {
            output result = new output();
            try
            {
                string msg = string.Empty;
                List<EmployeeDetail> obj= DAL.GetEmployeeLoginDetail(username, password,out msg);
                result = result.GetResponse(obj);
                //result.IsSucess = false;
                result.Message = msg;
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("app/GetEmployeeDetail/{hrmsCode}")]
        public output GetEmployeeDetail(string hrmsCode)
        {
            output result = new output();
            try
            {
                List<EmployeeDetail> obj = DAL.GetEmployeeDetail(hrmsCode);
                result = result.GetResponse(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("app/GetEmployeeDetailWithID/{empID}")]
        public output GetEmployeGetEmployeeDetailWithIDeDetail(long empID)
        {
            output result = new output();
            try
            {
                List<EmployeeDetail> obj = DAL.GetEmployeeDetailWithID(empID);
                result = result.GetResponse(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("app/GetEmployeeBranch/{employeeID}/{branchID}")]
        public output GetEmployeeBranch(long employeeID, int branchID)
        {
            output result = new output();            
            try
            {
                List<EmployeeBranch> obj = DAL.GetEmployeeBranchDetail(employeeID, branchID);
                result = result.GetResponse(obj);

            }
            catch (Exception)
            {

            }
            return result;
        }



        [Route("app/GetEmployeeDesignation/{employeeID}/{designationID}")]
        public output GetEmployeeDesignation(long employeeID, int designationID)
        {
            output result = new output();
            try
            {
                List<EmployeeDesignation> obj = DAL.GetEmployeeDesignationDetail(employeeID, designationID);
                result = result.GetResponse(obj);

            }
            catch (Exception)
            {

            }
            return result;
        }

        [HttpPost]
        [Route("app/EmployeeReportingAuthorityPost")]
        public output EmployeeReportingAuthorityPost(ReportingAuthorityDetail user)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeReportingAuthorityPost(user);
                result = result.GetResponsePost(obj,obj.Message);
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
                //result.ResponseData = 2;
            }

            return result;

        }

        [Route("app/GetReportingAuthorityDetai/{employeeID}/{reportingAuthorityID}")]
        public output GetReportingAuthorityDetail(long employeeID, long reportingAuthorityID)
        {
            output result = new output();            
            try
            {
                List<ReportingAuthorityDetailFetch> obj = DAL.GetReportingAuthorityDetai(employeeID, reportingAuthorityID);
                result = result.GetResponse(obj);
            }
            catch (Exception)
            {

            }
            return result;
        }

        [HttpPost]
        [Route("app/EmployeeLeaveTypeMasterPost")]
        public output EmployeeLeaveTypeMasterPost(long LeaveID, int YearID, long EmployeeID, int LeaveTypeID, decimal LeaveCount, string ProcessedBy)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeLeaveTypeMasterEditCreate(LeaveID, YearID, EmployeeID, LeaveTypeID, LeaveCount, ProcessedBy);
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

        [Route("app/GetEmployeeLeaveTypeMasterDetail/{employeeID}/{leaveID}")]
        public output GetEmployeeLeaveTypeMasterDetail(long employeeID, long leaveID)
        {
            output result = new output();
            try
            {
                List<EmployeeLeaveTypeMasterDetail> obj = DAL.GetEmployeeLeaveTypeMasterDetail(employeeID, leaveID);
                result = result.GetResponse(obj);

            }
            catch (Exception)
            {

            }
            return result;
        }
    }
}