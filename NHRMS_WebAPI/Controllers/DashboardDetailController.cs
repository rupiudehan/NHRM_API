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
        [Route("app/GetTotalAttendanceCount/{EmployeeID}/{Officeid}/{BranchID}")]
        public output GetTotalAttendanceCount(long EmployeeID, int Officeid,long BranchID)
        {
            output result = new output();
            try
            {
                List<DashboardAttendanceTotalCount> obj = DAL.GetTotalAttendanceCount(EmployeeID, Officeid, BranchID);
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

        [Route("app/GetAttendanceTotalCountPerAttType/{OfficeID}/{TypeData}/{EmployeeID}")]
        public output GetTotalCountPerAttendanceType(int officeID, string typeData, long employeeID)
        {
            output result = new output();
            try
            {
                List<DashboardTotalAttendance> obj = DAL.GetTotalCountPerAttendanceType(officeID, typeData, employeeID);
                result = result.GetResponse(obj);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [Route("app/GetTotalCountPerBranchAttendanceType/{OfficeID}/{BranchID}/{TypeData}/{EmployeeID}")]
        public output GetTotalCountPerBranchAttendanceType(int officeID, int branchID, string typeData, long employeeID)
        {
            output result = new output();
            try
            {
                List<DashboardTotalAttendance> obj = DAL.GetTotalCountPerBranchAttendanceType(officeID, branchID, typeData, employeeID);
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
        public output GetEmployeeDailyAttendanceDetail(long EmployeeID, int OfficeID, int BranchID, string TypeData)
        {
            output result = new output();
            try
            {
                List<DashboardReport> obj = DAL.GetEmployeeDailyAttendanceDetail(EmployeeID,OfficeID, BranchID, TypeData);
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
