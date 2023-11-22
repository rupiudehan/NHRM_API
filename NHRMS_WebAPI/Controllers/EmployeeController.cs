using ITInventory.Common;
using NHRMS_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace NHRMS_WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
        [Route("app/EmployeeSimUpdate/{simInput}/{simOutput}")]
        public output EmployeeSimUpdate(string simInput, string simOutput)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeSimUpdate(simInput, simOutput);
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
        [Route("app/EmployeeMasterDataPost/{empHrms}/{ReportingAuthorityHrms}")]
        public output EmployeeMasterDataPost(string empHrms, string ReportingAuthorityHrms)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeMasterDataCreate(empHrms, ReportingAuthorityHrms);
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

        [HttpPost]
        [Route("app/EmployeeSimMobUpdationpost")]
        public output EmployeeSimMobUpdationpost(long employeeID, string mobno, string simID, string processedBy)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeSimMobUpdation(employeeID, mobno, simID, processedBy);
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
        [Route("app/EmployeeSimDetailUpdationP")]
        public output EmployeeSimDetailUpdation( string simID)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeSimDetailUpdation(simID);
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
        public output EmployeeReportingAuthorityPost(long id,long employeeID, long authorityID, string processedBy)
        {
            output result = new output();
            try
            {
                ReportingAuthorityDetail user=new ReportingAuthorityDetail();
                user.ID = id;
                user.EmployeeID = employeeID;
                user.AuthorityID = authorityID;
                user.ProcessedBy = processedBy;

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
        public output EmployeeLeaveTypeMasterPost(long LeaveID, long EmployeeID, int LeaveTypeID, decimal LeaveCount, string ProcessedBy)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeLeaveTypeMasterEditCreate(LeaveID, EmployeeID, LeaveTypeID, LeaveCount, ProcessedBy);
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

        [HttpPost]
        [Route("app/EmployeeSimAndMobNoChangePost")]
        public output EmployeeSimAndMobNoChange(long EmployeeID, string SimID, string MobNo)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeSimAndMobNoChange(EmployeeID,SimID,MobNo);
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


        [Route("app/GetEmployeeCredentails/{hrmsno}/{mobno}")]
        public output GetEmployeeCredentails(string hrmsno, string mobno)
        {
            output result = new output();
            try
            {
                string msg = string.Empty;
                List<EmployeeCredentialDetail> obj = DAL.ForgetPassword(hrmsno, mobno,out msg);
                result = result.GetResponse(obj);
                result.Message = msg;

            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("app/GetEmployeeDetailSearch/{Search}")]
        public output GetEmployeeDetailAutoComplete(string Search)
        {
            output result = new output();
            try
            {
                List<EmployeeDetail> obj = DAL.GetEmployeeDetailAutoComplete(Search);
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
        [Route("app/DeleteEmployeeReportingAuthority/{id}")]
        public output DeleteEmployeeReportingAuthority(int id)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.DeleteEmployeeReportingAuthority(id);
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
        [Route("app/EmployeeBranchCreateEditPost")]
        public output EmployeeBranchCreateEditPost(long Id, long EmployeeID, long Branchid, bool IsAdditional, string ProcessedBy)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeBranchCreateEdit(Id, EmployeeID, Branchid, IsAdditional, ProcessedBy);
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
        [Route("app/DeleteEmployeeBranch/{id}")]
        public output DeleteEmployeeBranch(long id)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.DeleteEmployeeBranch(id);
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
        [Route("app/EmployeeActivateDeactivatePost")]
        public output EmployeeActivateDeactivatePost(long EmployeeID)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeActivateDeactivateEdit(EmployeeID);
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
        [Route("app/EmployeeServiceEndPost")]
        public output EmployeeServiceEndPost(long EmployeeID, string DateOfServiceEnd)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeServiceEndEdit(EmployeeID, DateOfServiceEnd);
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
        [Route("app/EmployeeSimDetailDeletePost")]
        public output EmployeeSimDetailDeletePost(long employeeID, string processedBy)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeSimDetailDelete(employeeID,processedBy);
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
        [Route("app/EmployeeSimDetailReRegisterPost")]
        public output EmployeeSimDetailReRegisterPost(string mobileNo, string simId, string processedBy)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeSimDetailReRegister(mobileNo, simId, processedBy);
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

        [Route("app/GetEmployeeDetailForSimMismatch/{IsSimMismatch}")]
        public output GetEmployeeDetailForSimMismatch(bool IsSimMismatch)
        {
            output result = new output();
            try
            {
                string msg = string.Empty;
                List<EmployeeDetail> obj = DAL.GetEmployeeDetailForSimMismatch(IsSimMismatch, out msg);
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

        [HttpPost]
        [Route("app/EmployeeMobUpdation")]
        public output EmployeeMobUpdationPost(long employeeID, string mobno)
        {
            output result = new output();
            try
            {
                MessageHandle obj = DAL.EmployeeMobUpdation(employeeID, mobno);
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
    }
}