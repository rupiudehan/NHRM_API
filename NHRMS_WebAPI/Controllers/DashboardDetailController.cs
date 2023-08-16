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

        [Route("app/GetAttendanceTotalPendingCount/{EmployeeID}/{DesignationID}")]
        public output GetTotalPendingCount(long EmployeeID, int designationid)
        {
            output result = new output();
            try
            {
                List<DashboardTotalPending> obj = DAL.GetTotalPendingCount(EmployeeID, designationid);
                result = result.GetResponse(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("app/GetAttendanceTotalCountPerAttType/{OfficeID}/{TypeData}")]
        public output GetTotalCountPerAttendanceType(int officeID, string typeData)
        {
            output result = new output();
            try
            {
                List<DashboardTotalAttendance> obj = DAL.GetTotalCountPerAttendanceType(officeID, typeData);
                result = result.GetResponse(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("app/GetTotalCountPerBranchAttendanceType/{OfficeID}/{BranchID}/{TypeData}")]
        public output GetTotalCountPerBranchAttendanceType(int officeID, int branchID, string typeData)
        {
            output result = new output();
            try
            {
                List<DashboardTotalAttendance> obj = DAL.GetTotalCountPerBranchAttendanceType(officeID, branchID, typeData);
                result = result.GetResponse(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("app/GetEmployeeDailyAttendanceDetail/{EmployeeID}/{OfficeID}/{BranchID}/{TypeData}")]
        public output GetEmployeeDailyAttendanceDetail(long EmployeeID, int officeID, int branchID, string typeData)
        {
            output result = new output();
            try
            {
                List<DashboardReport> obj = DAL.GetEmployeeDailyAttendanceDetail(EmployeeID,officeID, branchID, typeData);
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
