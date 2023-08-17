//using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using NHRMS_WebAPI.Extension;
using NHRMS_WebAPI.Models;

namespace ITInventory.Common
{
    public class DataAccessLayer: MastersDataAccessLayer
    {
        //DbProviderFactory Factory = DB.GetFactory();
        //DbConnection con = DB.GetConnection();

        //SqlConnection con = Common.DataService.GetConnection();
        #region Generate HRMS Code
        public List<FetchHrmsCode> GenerateHrmsCode(string Prefix)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@Prefix");
                parameter.Add(Prefix);

                List<FetchHrmsCode> result = (from dr in DB.ReadDS("GenerateHRMSCode", parameter.ToArray()).Tables[0].AsEnumerable()
                                              select new FetchHrmsCode()
                                              {
                                                  HrmsCode = Prefix + "-" + dr.Field<string>("HrmsCode"),
                                                  Success = 1,
                                                  Message = ""
                                              }).ToList();


                return result.Count == 0 ? null : result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Manage Password
        public List<EmployeeCredentialDetail> ForgetPassword(string hrmsno, string mobno, out string msg)
        {
            msg = string.Empty;
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@hrmsno");
                parameter.Add(hrmsno);
                parameter.Add("@mobno");
                parameter.Add(mobno);

                List<EmployeeCredentialDetail> result = (from dr in DB.ReadDS("EmployeePasswordGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                               select new EmployeeCredentialDetail()
                                               {
                                                   EmployeeID = dr.Field<long>("EmployeeID"),
                                                   EmployeeName = dr.Field<string>("EmployeeName"),
                                                   EmpPassword = dr.Field<string>("EmpPassword"),
                                                   HrmsNo = dr.Field<string>("HrmsNo")
                                               }).ToList();
                if (result.Count == 0)
                {
                    msg = "Invalid HRMS No./Mobile Number!";
                }

                return result.Count == 0 ? null : result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Employee        
        public MessageHandle EmployeeRegiatrationForAttendance(EmployeeDetail User)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@EmployeeName");
            parameter.Add(User.EmployeeName);
            parameter.Add("@GenderID");
            parameter.Add(User.GenderID);
            parameter.Add("@EmpPassword");
            parameter.Add(User.EmpPassword);
            parameter = MapDate(User.RegDate, parameter, "@RegDate");
            parameter.Add("@MobNo");
            parameter.Add(User.MobileNo);
            parameter.Add("@DesignationID");
            parameter.Add(User.DesignationID);
            parameter.Add("@OfficeID");
            parameter.Add(User.OfficeID);
            parameter.Add("@BranchID");
            parameter.Add(User.BranchID);
            parameter.Add("@SimID");
            parameter.Add(User.SimID);
            parameter.Add("@AdharCard");
            parameter.Add(User.AdharCard);
            parameter.Add("@HrmsNo");
            parameter.Add(User.HrmsNo);
            parameter.Add("@EmployeeTypeID");
            parameter.Add(User.EmployeeTypeID);
            parameter.Add("@ProcessedBy");
            parameter.Add(User.ProcessedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("EmployeeDetailCreate", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];

            return result;
        }

        public MessageHandle EmployeeSimUpdate(string simInput, string simOutput)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@SimIDIn");
            parameter.Add(simInput);
            parameter.Add("@SimIDOut");
            parameter.Add(simOutput);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("EmployeeSimIDEdit", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];

            return result;
        }

        public MessageHandle EmployeeMasterDataCreate(string empHrms, string ReportingAuthorityHrms)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@Hrms");
            parameter.Add(empHrms);
            parameter.Add("@ReportingAutority");
            parameter.Add(ReportingAuthorityHrms);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("EmployeeMasterDataCreate", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];

            return result;
        }

        public MessageHandle EmployeeUpdationForAttendance(EmployeeDetail User)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@EmployeeID");
            parameter.Add(User.EmployeeID);
            parameter.Add("@EmployeeName");
            parameter.Add(User.EmployeeName);
            parameter.Add("@GenderID");
            parameter.Add(User.GenderID);
            parameter.Add("@EmpPassword");
            parameter.Add(User.EmpPassword);
            parameter = MapDate(User.RegDate, parameter, "@RegDate");
            parameter.Add("@MobNo");
            parameter.Add(User.MobileNo);
            parameter.Add("@DesignationID");
            parameter.Add(User.DesignationID);
            parameter.Add("@OfficeID");
            parameter.Add(User.OfficeID);
            parameter.Add("@BranchID");
            parameter.Add(User.BranchID);
            parameter.Add("@SimID");
            parameter.Add(User.SimID);
            parameter.Add("@AdharCard");
            parameter.Add(User.AdharCard);
            parameter.Add("@HrmsNo");
            parameter.Add(User.HrmsNo);
            parameter.Add("@EmployeeTypeID");
            parameter.Add(User.EmployeeTypeID);
            parameter.Add("@ProcessedBy");
            parameter.Add(User.ProcessedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("EmployeeDetailEdit", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];

            return result;
        }

        public MessageHandle EmployeeSimMobUpdation(long employeeID,string mobno,string simID,string processedBy)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@EmployeeID");
            parameter.Add(employeeID);
            parameter.Add("@MobNo");
            parameter.Add(mobno);
            parameter.Add("@SimID");
            parameter.Add(simID);
            parameter.Add("@ProcessedBy");
            parameter.Add(processedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("EmployeeDetailSimMobEdit", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];

            return result;
        }

        public List<EmployeeDetail> GetEmployeeLoginDetail(string username, string password, out string msg)
        {
            msg = string.Empty;
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@Username");
                parameter.Add(username);
                parameter.Add("@Password");
                parameter.Add(password);

                List<EmployeeDetail> result = (from dr in DB.ReadDS("LogingEmployeeAttendance", parameter.ToArray()).Tables[0].AsEnumerable()
                                               select new EmployeeDetail()
                                               {
                                                   EmployeeID = dr.Field<long>("EmployeeID"),
                                                   EmployeeName = dr.Field<string>("EmployeeName"),
                                                   RegDate = Convert.ToString(dr.Field<DateTime?>("RegDate")),
                                                   MobileNo = dr.Field<string>("MobNo"),
                                                   EmpPassword = dr.Field<string>("EmpPassword"),
                                                   DesignationID = dr.Field<int>("DesignationID"),
                                                   DesignationName = dr.Field<string>("DesignationName"),
                                                   GenderID = dr.Field<int>("GenderID"),
                                                   GenderName = dr.Field<string>("GenderName"),
                                                   OfficeID = dr.Field<int>("OfficeID"),
                                                   OfficeName = dr.Field<string>("OfficeName"),
                                                   CityID = dr.Field<int>("CityID"),
                                                   CityCode = dr.Field<string>("CityCode"),
                                                   CityName = dr.Field<string>("CityName"),
                                                   DistrictID = dr.Field<int>("DistrictID"),
                                                   DistrictCode = dr.Field<string>("DistrictCode"),
                                                   DistrictName = dr.Field<string>("DistrictName"),
                                                   StateID = dr.Field<int>("StateID"),
                                                   StateCode = dr.Field<string>("StateCode"),
                                                   StateName = dr.Field<string>("StateName"),
                                                   CountryID = dr.Field<int>("CountryID"),
                                                   CountryCode = dr.Field<string>("CountryCode"),
                                                   CountryName = dr.Field<string>("CountryName"),
                                                   OfficeLattitute = dr.Field<double>("OfficeLattitute").ToString(),
                                                   OfficeLongitute = dr.Field<double>("OfficeLongitute").ToString(),
                                                   SimID = dr.Field<string>("SimID"),
                                                   AdharCard = dr.Field<string>("Adharcard")??"",
                                                   HrmsNo = dr.Field<string>("HrmsNo"),
                                                   BranchIDs = dr.Field<string>("BranchIDs"),
                                                   BranchNames = dr.Field<string>("BranchNames"),
                                                   DesignationIDs = dr.Field<string>("DesignationIDs"),
                                                   DesignationNames = dr.Field<string>("DesignationNames"),
                                                   EmployeeTypeID = dr.Field<int>("EmployeeTypeID"),
                                                   EmployeeTypeName = dr.Field<string>("EmployeeTypeName"),
                                                   DateofInActive = dr.Field<DateTime?>("DateOfInActive").ToString(),
                                                   DateofJoining = dr.Field<DateTime?>("DateofJoining").ToString(),
                                                   DateofTransfer = dr.Field<DateTime?>("DateOfTransfer").ToString(),
                                                   InactiveForAttendance = dr.Field<bool>("InactiveForAttendance"),
                                                   DateOfInactiveForAttendance = dr.Field<DateTime?>("DateOfInactiveForAttendance").ToString(),
                                                   isActive = dr.Field<bool>("IsActive"),
                                                   HasApprovingAuthorization = Convert.ToBoolean(dr.Field<int>("HasApprovingAuthorization")),
                                                   isDeleted = dr.Field<bool>("isDeleted"),
                                                   DesignationLevel = dr.Field<int>("DesignationLevel"),
                                                   Success = 1,
                                                   Message = ""
                                               }).ToList();
                if (result.Count == 0)
                {
                    msg = "Invalid HRMS No./Password!";
                }

                return result.Count == 0 ? null : result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<EmployeeDetail> GetEmployeeDetail(string HrmsCode)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@HrmsCode");
                parameter.Add(HrmsCode);

                List<EmployeeDetail> result = (from dr in DB.ReadDS("EmployeeDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                               select new EmployeeDetail()
                                               {
                                                   EmployeeID = dr.Field<long>("EmployeeID"),
                                                   EmployeeName = dr.Field<string>("EmployeeName"),
                                                   RegDate = Convert.ToString(dr.Field<DateTime?>("RegDate")),
                                                   MobileNo = dr.Field<string>("MobNo"),
                                                   EmpPassword = dr.Field<string>("EmpPassword"),
                                                   DesignationID = dr.Field<int>("DesignationID"),
                                                   DesignationName = dr.Field<string>("DesignationName"),
                                                   GenderID = dr.Field<int>("GenderID"),
                                                   GenderName = dr.Field<string>("GenderName"),
                                                   OfficeID = dr.Field<int>("OfficeID"),
                                                   OfficeName = dr.Field<string>("OfficeName"),
                                                   OfficeLattitute = dr.Field<double>("OfficeLattitute").ToString(),
                                                   OfficeLongitute = dr.Field<double>("OfficeLongitute").ToString(),
                                                   SimID = dr.Field<string>("SimID"),
                                                   AdharCard = dr.Field<string>("Adharcard"),
                                                   HrmsNo = dr.Field<string>("HrmsNo"),
                                                   BranchIDs = dr.Field<string>("BranchIDs"),
                                                   BranchNames = dr.Field<string>("BranchNames"),
                                                   EmployeeTypeID = dr.Field<int>("EmployeeTypeID"),
                                                   EmployeeTypeName = dr.Field<string>("EmployeeTypeName"),
                                                   DateofInActive = dr.Field<DateTime?>("DateOfInActive").ToString(),
                                                   DateofJoining = dr.Field<DateTime?>("DateofJoining").ToString(),
                                                   DateofTransfer = dr.Field<DateTime?>("DateOfTransfer").ToString(),
                                                   InactiveForAttendance = dr.Field<bool>("InactiveForAttendance"),
                                                   DateOfInactiveForAttendance = dr.Field<DateTime?>("DateOfInactiveForAttendance").ToString(),
                                                   DesignationLevel = dr.Field<int>("DesignationLevel"),
                                                   isActive = dr.Field<bool>("IsActive"),
                                                   isDeleted = dr.Field<bool>("isDeleted"),
                                                   Success = 1,
                                                   Message = ""
                                               }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<EmployeeDetail> GetEmployeeDetailWithID(long empID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeID");
                parameter.Add(empID);

                List<EmployeeDetail> result = (from dr in DB.ReadDS("EmployeeDetailGetWithID", parameter.ToArray()).Tables[0].AsEnumerable()
                                               select new EmployeeDetail()
                                               {
                                                   EmployeeID = dr.Field<long>("EmployeeID"),
                                                   EmployeeName = dr.Field<string>("EmployeeName"),
                                                   RegDate = Convert.ToString(dr.Field<DateTime?>("RegDate")),
                                                   MobileNo = dr.Field<string>("MobNo"),
                                                   EmpPassword = dr.Field<string>("EmpPassword"),
                                                   DesignationID = dr.Field<int>("DesignationID"),
                                                   DesignationName = dr.Field<string>("DesignationName"),
                                                   GenderID = dr.Field<int>("GenderID"),
                                                   GenderName = dr.Field<string>("GenderName"),
                                                   OfficeID = dr.Field<int>("OfficeID"),
                                                   OfficeName = dr.Field<string>("OfficeName"),
                                                   OfficeLattitute = dr.Field<double>("OfficeLattitute").ToString(),
                                                   OfficeLongitute = dr.Field<double>("OfficeLongitute").ToString(),
                                                   SimID = dr.Field<string>("SimID"),
                                                   AdharCard = dr.Field<string>("Adharcard"),
                                                   HrmsNo = dr.Field<string>("HrmsNo"),
                                                   BranchIDs = dr.Field<string>("BranchIDs"),
                                                   BranchNames = dr.Field<string>("BranchNames"),
                                                   EmployeeTypeID = dr.Field<int>("EmployeeTypeID"),
                                                   EmployeeTypeName = dr.Field<string>("EmployeeTypeName"),
                                                   DateofInActive = dr.Field<DateTime?>("DateOfInActive").ToString(),
                                                   DateofJoining = dr.Field<DateTime?>("DateofJoining").ToString(),
                                                   DateofTransfer = dr.Field<DateTime?>("DateOfTransfer").ToString(),
                                                   InactiveForAttendance = dr.Field<bool>("InactiveForAttendance"),
                                                   DateOfInactiveForAttendance = dr.Field<DateTime?>("DateOfInactiveForAttendance").ToString(),
                                                   isActive = dr.Field<bool>("IsActive"),
                                                   isDeleted = dr.Field<bool>("isDeleted"),
                                                   Success = 1,
                                                   Message = ""
                                               }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<EmployeeBranch> GetEmployeeBranchDetail(long employeeID, int branchID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeID");
                parameter.Add(employeeID);
                parameter.Add("@BranchID");
                parameter.Add(branchID);

                List<EmployeeBranch> result = (from dr in DB.ReadDS("EmployeeBranchGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                               select new EmployeeBranch()
                                               {
                                                   EmployeeID = dr.Field<long>("EmployeeID"),
                                                   BranchID = dr.Field<long>("BranchID"),
                                                   BranchName = dr.Field<string>("BranchName"),
                                                   ID = dr.Field<long>("ID"),
                                                   CreatedBy = dr.Field<string>("CreatedBy"),
                                                   CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                                   IsActive = dr.Field<bool>("IsActive"),
                                                   Success = 1,
                                                   Message = ""
                                               }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<EmployeeDesignation> GetEmployeeDesignationDetail(long employeeID, int designationID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeID");
                parameter.Add(employeeID);
                parameter.Add("@DesignationID");
                parameter.Add(designationID);

                List<EmployeeDesignation> result = (from dr in DB.ReadDS("EmployeeDesignationGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                    select new EmployeeDesignation()
                                                    {
                                                        EmployeeID = dr.Field<long>("EmployeeID"),
                                                        DesignationID = dr.Field<int>("DesignationID"),
                                                        DesignationName = dr.Field<string>("DesignationName"),
                                                        ID = dr.Field<long>("ID"),
                                                        CreatedBy = dr.Field<string>("CreatedBy"),
                                                        CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                                        IsActive = dr.Field<bool>("IsActive"),
                                                        Success = 1,
                                                        Message = ""
                                                    }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<EmployeeLeaveTypeMasterDetail> GetEmployeeLeaveTypeMasterDetail(long employeeID, long leaveID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeID");
                parameter.Add(employeeID);
                parameter.Add("@LeaveID");
                parameter.Add(leaveID);

                List<EmployeeLeaveTypeMasterDetail> result = (from dr in DB.ReadDS("EmployeeLeaveTypeMasterDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                              select new EmployeeLeaveTypeMasterDetail()
                                                              {
                                                                  EmployeeID = dr.Field<long>("EmployeeID"),
                                                                  LeaveID = dr.Field<long>("LeaveID"),
                                                                  YearID = dr.Field<int>("YearID"),
                                                                  Year = dr.Field<string>("Year"),
                                                                  CreatedBy = dr.Field<string>("CreatedBy"),
                                                                  CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                                                  LeaveTypeID = dr.Field<int>("LeaveTypeID"),
                                                                  LeaveName = dr.Field<string>("LeaveName"),
                                                                  LeaveCode = dr.Field<string>("LeaveCode"),
                                                                  LeaveCount = dr.Field<decimal>("LeaveCount"),
                                                                  UpdatedBy = dr.Field<string>("UpdatedBy"),
                                                                  UpdatedOn = dr.Field<DateTime?>("UpdatedOn").ToString(),
                                                                  EmployeeName = dr.Field<string>("EmployeeName"),
                                                                  HrmsNo = dr.Field<string>("HrmsNo"),
                                                                  MobNo = dr.Field<string>("MobNo"),
                                                                  SimID = dr.Field<string>("SimID"),
                                                                  Adharcard = dr.Field<string>("Adharcard"),
                                                                  DesignationID = dr.Field<int>("DesignationID"),
                                                                  DesignationName = dr.Field<string>("DesignationName"),
                                                                  EmployeeTypeID = dr.Field<int>("EmployeeTypeID"),
                                                                  EmployeeTypeName = dr.Field<string>("EmployeeTypeName"),
                                                                  OfficeID = dr.Field<int>("OfficeID"),
                                                                  OfficeName = dr.Field<string>("OfficeName"),
                                                                  OfficeLattitute = dr.Field<double>("OfficeLattitute"),
                                                                  OfficeLongitute = dr.Field<double>("OfficeLongitute"),
                                                                  ISActive = dr.Field<bool>("ISActive"),
                                                                  Success = 1,
                                                                  Message = ""
                                                              }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public MessageHandle EmployeeLeaveTypeMasterEditCreate(long LeaveID, int YearID, long EmployeeID, int LeaveTypeID, decimal LeaveCount, string ProcessedBy)
        {
            int success = 0; string msg = "";
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@LeaveID");
            parameter.Add(LeaveID);
            parameter.Add("@YearID");
            parameter.Add(YearID);
            parameter.Add("@EmployeeID");
            parameter.Add(EmployeeID);
            parameter.Add("@LeaveTypeID");
            parameter.Add(LeaveTypeID);
            parameter.Add("@LeaveCount");
            parameter.Add(LeaveCount);
            parameter.Add("@ProcessedBy");
            parameter.Add(ProcessedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("EmployeeLeaveTypeMasterCreateEdit", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];

            return result;
        }

        public MessageHandle EmployeeDetailDelete(long empID)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@EmployeeID");
            parameter.Add(empID);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("EmployeeDetailDelete", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];

            return result;
        }

        private int CheckSimDetail(long empID, string simID)
        {
            int result = 0;
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeId");
                parameter.Add(empID);
                parameter.Add("@SimId");
                parameter.Add(simID);

                DataSet ds = DB.ReadDS("CheckSimDetail", parameter.ToArray());
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    result = Convert.ToInt32(ds.Tables[0].Rows[0][0]) == 0 ? 0 : 1;
                }


                return result;
            }
            catch (Exception)
            {
                return result;
            }

        }

        public MessageHandle EmployeeSimAndMobNoChange(long EmployeeID,string SimID,string MobNo)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@EmployeeID");
            parameter.Add(EmployeeID);
            parameter.Add("@SimID");
            parameter.Add(SimID);
            parameter.Add("@MobNo");
            parameter.Add(MobNo);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("EmployeeSimMobNoEdit", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];

            return result;
        }
        #endregion

        #region Reporting Authority
        public MessageHandle EmployeeReportingAuthorityPost(ReportingAuthorityDetail user)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@EmployeeID");
            parameter.Add(user.EmployeeID);
            parameter.Add("@AuthorityID");
            parameter.Add(user.AuthorityID);
            parameter.Add("@ProcessedBy");
            parameter.Add(user.ProcessedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("EmployeeReportingAuthorityCreate", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];

            return result;
        }

        public List<ReportingAuthorityDetailFetch> GetReportingAuthorityDetai(long employeeID, long reportingAuthorityID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeID");
                parameter.Add(employeeID);
                parameter.Add("@ReportingAuthorityID");
                parameter.Add(reportingAuthorityID);
                List<ReportingAuthorityDetailFetch> result = (from dr in DB.ReadDS("EmployeeReportingAuthorityDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                              select new ReportingAuthorityDetailFetch()
                                                              {
                                                                  ID = dr.Field<long>("ID"),
                                                                  EmployeeID = dr.Field<long>("EmployeeID"),
                                                                  AuthorityID = dr.Field<long>("ReportingAuthorityID"),
                                                                  AuthorityName = dr.Field<string>("AuthorityName"),
                                                                  AuthorityDesignationName = dr.Field<string>("AuthorityDesignationName"),
                                                                  AuthorityDesignationID = dr.Field<int>("AuthorityDesignationID"),
                                                                  AuthorityOfficeName = dr.Field<string>("AuthorityOfficeName"),
                                                                  AuthorityOfficeIDR = dr.Field<int>("AuthorityOfficeIDR"),
                                                                  EmployeeName = dr.Field<string>("EmployeeName"),
                                                                  DesignationName = dr.Field<string>("DesignationName"),
                                                                  DesignationID = dr.Field<int>("DesignationID"),
                                                                  OfficeName = dr.Field<string>("OfficeName"),
                                                                  OfficeID = dr.Field<int>("OfficeID"),
                                                                  CreatedBy = dr.Field<string>("CreatedBy"),
                                                                  CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                                                  UpdatedBy = dr.Field<string>("UpdatedBy"),
                                                                  UpdatedOn = dr.Field<DateTime?>("UpdatedOn").ToString(),
                                                                  IsActive = dr.Field<bool>("IsActive"),
                                                                  Success = 1,
                                                                  Message = ""
                                                              }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Attendance
        public List<EmployeeAttendanceMarkDetail> MarkAttendance(AttendanceMark att)
        {
            MessageHandle result = new MessageHandle();
            List<EmployeeAttendanceMarkDetail> resultFinal = new List<EmployeeAttendanceMarkDetail>();
            List<object> parameter = new List<object>();
            parameter.Add("@EmployeeId");
            parameter.Add(att.EmployeeId);
            parameter.Add("@SimId");
            parameter.Add(att.SimId);
            if (att.IsInTime != 1)
            {
                parameter.Add("@OutTime");
                parameter.Add(att.OutTime);
                parameter.Add("@OutLatitude");
                parameter.Add(att.OutLatitude);
                parameter.Add("@OutLongitude");
                parameter.Add(att.OutLongitude);
            }
            else
            {
                parameter.Add("@InTime");
                parameter.Add(att.InTime);
                parameter.Add("@InLatitude");
                parameter.Add(att.InLatitude);
                parameter.Add("@InLongitude");
                parameter.Add(att.InLongitude);
            }
            parameter.Add("@IN");
            parameter.Add(att.IsInTime);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("AttendanceMark", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            if (result.Success == 1 || result.Success == 2)
            {
                resultFinal = GetAttendanceDetail(att.EmployeeId, result.Success, result.Message);
            }
            else
            {
                EmployeeAttendanceMarkDetail obj = new EmployeeAttendanceMarkDetail();
                obj.result = result.Success;
                obj.Message = result.Message;
                resultFinal.Add(obj);
            }

            return resultFinal;
        }

        public List<EmployeeAttendanceMarkDetail> GetAttendanceDetail(long EmployeeID, int output, string mesaage)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeID");
                parameter.Add(EmployeeID);

                List<EmployeeAttendanceMarkDetail> result = (from dr in DB.ReadDS("AttendanceDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                             select new EmployeeAttendanceMarkDetail()
                                                             {
                                                                 EmployeeId = dr.Field<long>("EmployeeID"),
                                                                 EmployeeName = dr.Field<string>("EmployeeName"),
                                                                 MobNo = dr.Field<string>("MobNo"),
                                                                 AttInDate = string.Format("{0:dd/MM/yyyy}", dr.Field<DateTime?>("AttInDate")),
                                                                 InTime = dr.Field<string>("AttInTime").ToString(),
                                                                 OutTime = dr.Field<string>("AttOutTime") ?? "",
                                                                 InLatitude = dr.Field<string>("INLatitude").ToString(),
                                                                 InLongitude = dr.Field<string>("INLongitude").ToString(),
                                                                 OutLatitude = dr.Field<string>("OutLatitude") == null ? "" : dr.Field<string>("OutLatitude").ToString(),
                                                                 OutLongitude = dr.Field<string>("OutLongitude") == null ? "" : dr.Field<string>("OutLongitude").ToString(),
                                                                 SimId = dr.Field<string>("SimID"),
                                                                 HrmsNo = dr.Field<string>("HrmsNo"),
                                                                 TimeDiff = dr.Field<string>("TimeDiff"),
                                                                 DateofJoining = dr.Field<DateTime?>("DateofJoining").ToString(),
                                                                 OldTimeDiiff = dr.Field<string>("OldTimeDiiff").ToString(),
                                                                 OutTimeOld = dr.Field<TimeSpan?>("OutTimeOld").ToString(),
                                                                 InTimeOld = dr.Field<TimeSpan?>("InTimeOld").ToString(),
                                                                 isHoliday = dr.Field<int>("isHoliday"),
                                                                 Success = output,
                                                                 Message = mesaage,
                                                                 result = output
                                                             }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public int CheckAttendanceDetail(long EmployeeID, string simID)
        {
            int result = 0;
            try
            {
                result = CheckSimDetail(EmployeeID, simID);
                if (result == 1)
                {
                    List<object> parameter = new List<object>();
                    parameter.Add("@EmployeeID");
                    parameter.Add(EmployeeID);

                    List<EmployeeAttendanceMarkDetail> obj = (from dr in DB.ReadDS("AttendanceDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                              select new EmployeeAttendanceMarkDetail()
                                                              {
                                                                  EmployeeId = dr.Field<long>("EmployeeID"),
                                                                  EmployeeName = dr.Field<string>("EmployeeName"),
                                                                  MobNo = dr.Field<string>("MobNo"),
                                                                  AttInDate = dr.Field<DateTime?>("AttInDate").ToString(),
                                                                  InTime = dr.Field<string>("AttInTime").ToString(),
                                                                  OutTime = dr.Field<string>("AttOutTime") == null ? "" : dr.Field<string>("AttOutTime"),//.ToString(),
                                                                  InLatitude = dr.Field<string>("INLatitude").ToString(),
                                                                  InLongitude = dr.Field<string>("INLatitude"),
                                                                  OutLatitude = dr.Field<string>("OutLatitude"),
                                                                  OutLongitude = dr.Field<string>("OutLongitude"),
                                                                  SimId = dr.Field<string>("SimID"),
                                                                  HrmsNo = dr.Field<string>("HrmsNo"),
                                                                  TimeDiff = dr.Field<string>("TimeDiff"),
                                                                  DateofJoining = dr.Field<DateTime?>("DateofJoining").ToString(),
                                                                  OldTimeDiiff = dr.Field<string>("OldTimeDiiff").ToString(),
                                                                  OutTimeOld = dr.Field<TimeSpan?>("OutTimeOld").ToString(),
                                                                  InTimeOld = dr.Field<TimeSpan?>("InTimeOld").ToString(),
                                                                  isHoliday = dr.Field<int>("isHoliday"),
                                                                  Success = 1,
                                                                  Message = ""
                                                              }).ToList();

                    if (obj != null && obj.Count > 0)
                    {
                        foreach (EmployeeAttendanceMarkDetail item in obj)
                        {
                            //In Marked
                            if (item.AttInDate != "" && item.OutTime == "")
                            {
                                result = 3;
                            }
                            else if (item.AttInDate != "" && item.OutTime != "") //In Marked and out marked
                            {
                                result = 4;
                            }
                        }
                    }
                    else
                    {
                        result = 2;//No attendance marked
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }

        }

        public List<AttendanceMonthlyDetail> GetMonthlyAttendanceDetail(long EmployeeID, string startDate, string endDate)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeID");
                parameter.Add(EmployeeID);
                parameter = MapDate(startDate, parameter, "@StartDate");
                parameter = MapDate(endDate, parameter, "@EndDate");


                List<AttendanceMonthlyDetail> result = (from dr in DB.ReadDS("EmployeeAttendanceMonthlyDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                        select new AttendanceMonthlyDetail()
                                                        {
                                                            datedata = dr.Field<string>("datedata"),
                                                            EmployeeName = dr.Field<string>("EmployeeName"),
                                                            MobNo = dr.Field<string>("MobNo"),
                                                            attType = dr.Field<string>("attType"),
                                                            YearName = dr.Field<int>("YearName"),
                                                            Monthname = dr.Field<int>("Monthname"),
                                                            BranchName = dr.Field<string>("BranchName").ToString(),
                                                            DesignationName = dr.Field<string>("DesignationName").ToString(),
                                                            Hrmsno = dr.Field<string>("Hrmsno"),
                                                            attintime = dr.Field<string>("attintime"),
                                                            attouttime = dr.Field<string>("attouttime"),
                                                            Officename = dr.Field<string>("Officename"),
                                                            type = dr.Field<string>("type"),
                                                            LeaveName = dr.Field<string>("LeaveName"),
                                                            date = dr.Field<DateTime?>("date").ToString(),
                                                            holiday = dr.Field<string>("holiday"),
                                                            TimeDiff = dr.Field<string>("TimeDiff")
                                                        }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        #endregion

        #region Management Category
        public List<ManagementCategoryDetail> GetManagementCategories(int categoryId, int authorityCategoryId)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@CategoryID");
                parameter.Add(categoryId);
                parameter.Add("@BossID");
                parameter.Add(authorityCategoryId);

                List<ManagementCategoryDetail> result = (from dr in DB.ReadDS("ManagementCategoryGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                         select new ManagementCategoryDetail()
                                                         {
                                                             CategoryID = dr.Field<int>("CategoryID"),
                                                             CategoryName = dr.Field<string>("CategoryName"),
                                                             BossID = dr.Field<int>("BossID"),
                                                             AuthorityName = dr.Field<string>("AuthorityName"),
                                                             IsActive = dr.Field<bool>("IsActive"),
                                                             Success = 1,
                                                             Message = ""
                                                         }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Leave
        public List<LeaveTourMaster> GetLeaveTourMasterDetail()
        {
            try
            {

                List<LeaveTourMaster> result = (from dr in DB.ReadDS("LeaveTourMasterDetailGet", null).Tables[0].AsEnumerable()
                                                select new LeaveTourMaster()
                                                {
                                                    MasterCode = dr.Field<string>("MasterCode"),
                                                    MasterName = dr.Field<string>("MasterName")
                                                }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<AttendanceBalanceDetail> GetLeaveBalanceDetail(long EmployeeID, int leaveTypeID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeID");
                parameter.Add(EmployeeID);
                parameter.Add("@LeaveTypeID");
                parameter.Add(leaveTypeID);

                List<AttendanceBalanceDetail> result = (from dr in DB.ReadDS("AttendanceLeaveBalanceGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                        select new AttendanceBalanceDetail()
                                                        {
                                                            EmployeeID = dr.Field<long>("EmployeeID"),
                                                            hrmscode = dr.Field<string>("hrmscode"),
                                                            OfficeID = dr.Field<int>("OfficeID"),
                                                            Success = 1,
                                                            Message = ""
                                                        }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public MessageHandle AddLeaveDetail(LeaveDetail ld,string domainname)
        {
            MessageHandle result = new MessageHandle();



            List<object> parameter = new List<object>();
            parameter.Add("@EmployeeID");
            parameter.Add(ld.EmployeeID);
            parameter = MapDate(ld.LeaveFromDate, parameter, "@LeaveFromDate");
            parameter = MapDate(ld.LeaveToDate, parameter, "@LeaveToDate");

            if (ld.LeaveFromTime != "" && ld.LeaveFromTime != null)
            {
                parameter.Add("@LeaveFromTime");
                parameter.Add(ld.LeaveFromTime);
            }
            if (ld.LeaveToTime != "" && ld.LeaveToTime != null)
            {

                parameter.Add("@LeaveToTime");
                parameter.Add(ld.LeaveToTime);
            }
            parameter.Add("@LeaveCategoryID");
            parameter.Add(ld.LeaveCategoryID);
            parameter.Add("@LeaveTypeID");
            parameter.Add(ld.LeaveTypeID);
            parameter.Add("@LeaveTypeT");
            parameter.Add(ld.LeaveTypeT);
            parameter.Add("@LeaveReason");
            parameter.Add(ld.LeaveReason);
            parameter.Add("@ApprovingAuthorityID");
            parameter.Add(ld.ApprovingAuthorityID);
            parameter.Add("@IsAttachedDocumets");
            parameter.Add(ld.IsAttachedDocumets);
            if (ld.IsAttachedDocumets)
            {
                string extension = ld.fileExtension.ToLower();
                if (ld.fileExtension != "" && (extension == "jpeg" || extension == "jpg" || extension == "pdf"))
                {
                    string folder = System.Web.HttpContext.Current.Server.MapPath("/UploadattendanceDoc");

                    string filename = ld.HrmsNo + "LeaveAttachment" + DateTime.Now.ToString("dd-MM-yyyy");
                    //string filePath = folder + "/" + filename + "/" + filename + ".jpeg";
                    string filePath = folder + "/" + filename + "/" + filename + "." + (extension == "jpg" ? "jpeg" : extension);  //Allowed extensions .pdf and .jpeg/jpg

                    string im = image(ld.HrmsNo, ld.bytedata);
                    parameter.Add("@AttachDocUrls");

                    parameter.Add(domainname+"/UploadattendanceDoc/" + filename + "/" + filename + "." + (extension == "jpg" ? "jpeg" : extension));
                    
                    //parameter.Add("http://49.50.66.74:88/UploadattendanceDoc/" + filename + "/" + filename + "." + (extension == "jpg" ? "jpeg" : extension));
                    //parameter.Add("http://pswc.in/UploadattendanceDoc/" + filename + "/" + filename + ".jpeg");
                }
                else
                {
                    result.Success = 6;
                    result.Message = "Invalid file uploaded";
                    return result;
                }
            }
            else
            {
                parameter.Add("@AttachDocUrls");
                parameter.Add("");
            }

            parameter.Add("@StatusUpdatedBy");
            parameter.Add(ld.StatusUpdatedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("LeaveTourCreate", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            if (result.Success == 2)
            {
                if (ld.IsAttachedDocumets) { string im = image(ld.HrmsNo, ld.bytedata); }
            }
            return result;
        }

        public MessageHandle UpdateLeaveDetail(EditLeaveDetail ld)
        {
            if (ld.ApprovalFlow == null || ld.ApprovalFlow == "")
                ld.ApprovalFlow = "N";// F=Forward   SB=Send Back    N=Normal
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@ID");
            parameter.Add(ld.ID);
            parameter.Add("@EmployeeID");
            parameter.Add(ld.EmployeeID);
            parameter.Add("@LeaveTypeID");
            parameter.Add(ld.LeaveTypeID);
            parameter.Add("@LeaveTypeT");
            parameter.Add(ld.LeaveTypeT);
            parameter = MapDate(ld.LeaveFromDate, parameter, "@LeaveFromDate");
            parameter.Add("@LeaveStatus");
            parameter.Add(ld.LeaveStatus);
            parameter.Add("@Remarks");
            parameter.Add(ld.Remarks);
            parameter.Add("@ApprovalCategory");
            parameter.Add(ld.ApprovalFlow);
            parameter.Add("@StatusUpdatedBy");
            parameter.Add(ld.StatusUpdatedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("LeaveTourEdit", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];

            return result;
        }

        public MessageHandle CancelLeaveDetail(EditLeaveDetail ld)
        {
            if (ld.ApprovalFlow == null || ld.ApprovalFlow == "")
                ld.ApprovalFlow = "N";// F=Forward   SB=Send Back    N=Normal
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@ID");
            parameter.Add(ld.ID);
            parameter.Add("@EmployeeID");
            parameter.Add(ld.EmployeeID);
            //parameter.Add("@ApprovalCategory");
            //parameter.Add(ld.ApprovalFlow);
            parameter.Add("@StatusUpdatedBy");
            parameter.Add(ld.StatusUpdatedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("LeaveTourCancel", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];

            return result;
        }

        public MessageHandle LeaveAutoDeduct(LeaveAutoDeductDetail ld)
        {
            MessageHandle result = new MessageHandle();

            List<object> parameter = new List<object>();
            parameter.Add("@EmployeeID");
            parameter.Add(ld.EmployeeID);
            parameter.Add("@LeaveCategoryID");
            parameter.Add(ld.LeaveCategoryID);
            parameter.Add("@LeaveTypeID");
            parameter.Add(ld.LeaveTypeID);
            parameter.Add("@LeaveTourCode");
            parameter.Add(ld.LeaveTypeT);
            parameter = MapDate(ld.LeaveFromDate, parameter, "@LeaveFromDate");
            if (ld.LeaveFromTime != "" && ld.LeaveFromTime != null)
            {
                parameter.Add("@LeaveFromTime");
                parameter.Add(ld.LeaveFromTime);
            }
            parameter = MapDate(ld.LeaveToDate, parameter, "@LeaveToDate");

            if (ld.LeaveToTime != "" && ld.LeaveToTime != null)
            {

                parameter.Add("@LeaveToTime");
                parameter.Add(ld.LeaveToTime);
            }
            parameter.Add("@ApprovingAuthorityID");
            parameter.Add(ld.ApprovingAuthorityID);
            parameter.Add("@ROfficerDesignationID");
            parameter.Add(ld.ROfficerDesignationID);
            parameter.Add("@ROfficeDeptID");
            parameter.Add(ld.ROfficeDeptID);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("LeaveAutoDeductCreate", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];

            return result;
        }

        public DataTable GetEmployeeLeaveBalanceDetail(long EmployeeID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeID");
                parameter.Add(EmployeeID);
                DataSet ds = DB.ReadDS("EmployeeLeaveBalanceDetail", parameter.ToArray());
                DataTable dt = new DataTable();

                //ExpandoObject dynamicDto = new ExpandoObject();
                //ArrayList columnName = new ArrayList();
                //foreach (DataRow row in ds.Tables[0].Rows)
                //{
                foreach (DataColumn column in ds.Tables[0].Columns)
                {
                    //columnName.Add(column.ColumnName+",");
                    //((IDictionary<String, Object>)dynamicDto).Add(column.ColumnName, row[column.ColumnName]);
                    string columnValue = column.ColumnName.Contains(" ") ? string.Concat(column.ColumnName.Where(c => !char.IsWhiteSpace(c))) : column.ColumnName;
                    dt.Columns.Add(columnValue);
                }
                //}
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DataRow dr = dt.NewRow();
                    foreach (DataColumn column in ds.Tables[0].Columns)
                    {
                        //columnName.Add(column.ColumnName+",");
                        //((IDictionary<String, Object>)dynamicDto).Add(column.ColumnName, row[column.ColumnName]);
                        string columnValue = column.ColumnName.Contains(" ") ? string.Concat(column.ColumnName.Where(c => !char.IsWhiteSpace(c))) : column.ColumnName;
                        dr[columnValue] = row[column.ColumnName] == null || row[column.ColumnName].ToString() == "" ? "0.00" : row[column.ColumnName];
                    }
                    dt.Rows.Add(dr);
                }
                //int count = 0;
                //var result = (from dr in DB.ReadDS("EmployeeLeaveBalanceDetail", parameter.ToArray()).Tables[0].AsEnumerable()
                //              select new
                //              {
                //                  columnName[count++] = dr.Field<long>(columnName[count++].ToString())

                //              }).ToList();
                //object d = result;

                //return dynamicDto;
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public List<EmplyeeLeaveBalanceWithLeaveType> GetEmployeeLeaveBalanceDetailWithLeaveType(long EmployeeID, string YearName, int LeaveTypeID, string hrmsNo)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeID");
                parameter.Add(EmployeeID);
                if (EmployeeID == 0)
                {
                    parameter.Add("@HrmsCode");
                    parameter.Add(hrmsNo);
                }
                parameter.Add("@year");
                parameter.Add(YearName);
                parameter.Add("@LeaveTypeID");
                parameter.Add(LeaveTypeID);
                List<EmplyeeLeaveBalanceWithLeaveType> result = (from dr in DB.ReadDS("EmployeeLeaveBalanceDetailForLeaveType", parameter.ToArray()).Tables[0].AsEnumerable()
                                                                 select new EmplyeeLeaveBalanceWithLeaveType()
                                                                 {
                                                                     EmployeeID = dr.Field<long>("EmployeeID"),
                                                                     HrmsNo = dr.Field<string>("HrmsNo"),
                                                                     EmployeeName = dr.Field<string>("EmployeeName"),
                                                                     OfficeID = dr.Field<int>("OfficeID"),
                                                                     LeaveTypeName = dr.Field<string>("LeaveTypeName"),
                                                                     LeaveBalance = dr.Field<decimal>("LeaveBalance"),
                                                                     DesignationID = dr.Field<int>("DesignationID"),
                                                                     DesignationName = dr.Field<string>("DesignationName"),
                                                                     EmployeeTypeID = dr.Field<int>("EmployeeTypeID"),
                                                                     EmployeeTypeName = dr.Field<string>("EmployeeTypeName"),
                                                                     GenderID = dr.Field<int>("GenderID"),
                                                                     GenderName = dr.Field<string>("GenderName"),
                                                                     BranchID = dr.Field<long>("BranchID"),
                                                                     OfficeName = dr.Field<string>("OfficeName"),
                                                                     Success = 1,
                                                                     Message = ""
                                                                 }).ToList();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public List<LeaveUnlockDetail> GetLeaveDateUnlockDetail(long EmployeeID, string hrmsNo)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeID");
                parameter.Add(EmployeeID);
                if (EmployeeID == 0)
                {
                    parameter.Add("@HrmsCode");
                    parameter.Add(hrmsNo);
                }
                List<LeaveUnlockDetail> result = (from dr in DB.ReadDS("LeaveDateUnlockGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                  select new LeaveUnlockDetail()
                                                  {
                                                      EmployeeID = dr.Field<long>("EmployeeID"),
                                                      HrmsNo = dr.Field<string>("HrmsNo"),
                                                      OfficeID = dr.Field<int>("OfficeID"),
                                                      DesignationID = dr.Field<int>("DesignationID"),
                                                      BranchID = dr.Field<long>("BranchID"),
                                                      FromDate = dr.Field<DateTime>("FromDate").ToString(),
                                                      ToDate = dr.Field<DateTime>("ToDate").ToString(),
                                                      EnteryDate = dr.Field<DateTime?>("EnteryDate").ToString(),
                                                      NoOfDays = dr.Field<int>("NoOfDays"),
                                                      Success = 1,
                                                      Message = ""
                                                  }).ToList();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public List<PendingLeaveDetail> GetPendingLeaveDetail(long reportingOfficerID, string leaveTour, int designationid = 0)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@ReportingOfficerID");
                parameter.Add(reportingOfficerID);
                parameter.Add("@DesignationID");
                parameter.Add(designationid);
                parameter.Add("@LeaveTourCode");
                parameter.Add(leaveTour);

                List<PendingLeaveDetail> result = (from dr in DB.ReadDS("LeavePendingDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                   select new PendingLeaveDetail()
                                                   {
                                                       EmployeeID = dr.Field<long>("EmployeeID"),
                                                       ID = dr.Field<long>("ID"),
                                                       EmployeeName = dr.Field<string>("EmployeeName"),
                                                       EmployeeMobNo = dr.Field<string>("EmployeeMobNo"),
                                                       SimID = dr.Field<string>("SimID"),
                                                       LeaveCategoryName = dr.Field<string>("LeaveCategoryName"),
                                                       LeaveCategoryID = dr.Field<int>("LeaveCategoryID"),
                                                       LeaveTypeName = dr.Field<string>("LeaveTypeName"),
                                                       LeaveTypeID = dr.Field<int>("LeaveTypeID"),
                                                       LeaveTourCode = dr.Field<string>("LeaveTourCode"),
                                                       LeaveTour = dr.Field<string>("LeaveTour"),
                                                       LeaveFromDate = string.Format("{0:dd/MM/yyyy}", dr.Field<DateTime?>("LeaveFromDate")),
                                                       LeaveFromTime = dr.Field<TimeSpan?>("LeaveFromTime").ToString(),
                                                       LeaveToDate = string.Format("{0:dd/MM/yyyy}", dr.Field<DateTime?>("LeaveToDate")),
                                                       LeaveToTime = dr.Field<TimeSpan?>("LeaveToTime").ToString(),
                                                       IsAttachedDocument = dr.Field<bool>("IsAttachedDocument"),
                                                       LeaveReason = dr.Field<string>("LeaveReason"),
                                                       ApplyDatetime = dr.Field<DateTime?>("ApplyDatetime") == null ? "" : string.Format("{0:dd/MM/yyyy HH:mm:ss tt}", dr.Field<DateTime?>("ApplyDatetime")),
                                                       ReportingOfficerID = dr.Field<long>("ReportingOfficerID"),
                                                       ReportingOfficerName = dr.Field<string>("ReportingOfficerName"),
                                                       LeaveStatus = dr.Field<string>("LeaveStatus"),
                                                       ReportingOfficerDesignation = dr.Field<string>("ReportingOfficerDesignation"),
                                                       ReportingOfficerMobNo = dr.Field<string>("ReportingOfficerMobNo"),
                                                       ReportingOfficerHrms = dr.Field<string>("ReportingOfficerHrms"),
                                                       EmployeeHrms = dr.Field<string>("EmployeeHrms"),
                                                       EmployeeDesignation = dr.Field<string>("EmployeeDesignation"),
                                                       EmpBranchID = dr.Field<long>("EmpBranchID"),
                                                       EmpOfficeName = dr.Field<string>("EmpOfficeName"),
                                                       EmpBranchName = dr.Field<string>("EmpBranchName"),
                                                       AttachmentID = dr.Field<long?>("AttachmentID") == null ? "0" : dr.Field<long>("AttachmentID").ToString(),
                                                       AttachmentUrl = dr.Field<string>("AttachmentUrl")
                                                   }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<PendingLeaveDetail> GetLeaveStatusDetailLevel1(long EmployeeID, string hrmsNo, string startdate, string enddate, string leaveTour, long reportingOfficerID, int designationid)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeID");
                parameter.Add(EmployeeID);
                if (EmployeeID == 0)
                {
                    parameter.Add("@hrms");
                    parameter.Add(hrmsNo);
                }
                parameter = MapDate(startdate, parameter, "@startdate");
                parameter = MapDate(enddate, parameter, "@enddate");
                parameter.Add("@LeaveTourCode");
                parameter.Add(leaveTour);

                parameter.Add("@ReportingOfficerID");
                parameter.Add(reportingOfficerID);
                parameter.Add("@DesignationID");
                parameter.Add(designationid);

                List<PendingLeaveDetail> result = (from dr in DB.ReadDS("LeaveTourStatusLevel1Get", parameter.ToArray()).Tables[0].AsEnumerable()
                                                   select new PendingLeaveDetail()
                                                   {
                                                       EmployeeID = dr.Field<long>("EmployeeID"),
                                                       ID = dr.Field<long>("ID"),
                                                       EmployeeName = dr.Field<string>("EmployeeName"),
                                                       EmployeeMobNo = dr.Field<string>("EmployeeMobNo"),
                                                       SimID = dr.Field<string>("SimID"),
                                                       LeaveCategoryName = dr.Field<string>("LeaveCategoryName"),
                                                       LeaveCategoryID = dr.Field<int>("LeaveCategoryID"),
                                                       LeaveTypeName = dr.Field<string>("LeaveTypeName"),
                                                       LeaveTypeID = dr.Field<int>("LeaveTypeID"),
                                                       LeaveTourCode = dr.Field<string>("LeaveTourCode"),
                                                       LeaveTour = dr.Field<string>("LeaveTour"),
                                                       LeaveFromDate = string.Format("{0:dd/MM/yyyy}", dr.Field<DateTime?>("LeaveFromDate")),
                                                       LeaveFromTime = dr.Field<TimeSpan?>("LeaveFromTime").ToString(),
                                                       LeaveToDate = string.Format("{0:dd/MM/yyyy}", dr.Field<DateTime?>("LeaveToDate")),
                                                       ApprovalDateTime = string.Format("{0:dd/MM/yyyy HH:mm tt}", dr.Field<DateTime?>("ApprovalDateTime")),
                                                       LeaveToTime = dr.Field<TimeSpan?>("LeaveToTime").ToString(),
                                                       IsAttachedDocument = dr.Field<bool>("IsAttachedDocument"),
                                                       LeaveReason = dr.Field<string>("LeaveReason") ?? "",
                                                       ApplyDatetime = string.Format("{0:dd/MM/yyyy HH:mm:ss tt}", dr.Field<DateTime?>("ApplyDatetime")),
                                                       ApplyDate = string.Format("{0:dd}", dr.Field<DateTime?>("ApplyDatetime")),
                                                       ReportingOfficerID = dr.Field<long>("ReportingOfficerID"),
                                                       ReportingOfficerName = dr.Field<string>("ReportingOfficerName"),
                                                       LeaveStatus = dr.Field<string>("LeaveStatus"),
                                                       ReportingOfficerDesignation = dr.Field<string>("ReportingOfficerDesignation"),
                                                       ReportingOfficerMobNo = dr.Field<string>("ReportingOfficerMobNo"),
                                                       ReportingOfficerHrms = dr.Field<string>("ReportingOfficerHrms"),
                                                       EmployeeHrms = dr.Field<string>("EmployeeHrms"),
                                                       EmployeeDesignation = dr.Field<string>("EmployeeDesignation"),
                                                       EmpBranchID = dr.Field<long>("EmpBranchID"),
                                                       EmpOfficeName = dr.Field<string>("EmpOfficeName"),
                                                       EmpBranchName = dr.Field<string>("EmpBranchName"),
                                                       AttachmentID = dr.Field<long?>("AttachmentID") == null ? "0" : dr.Field<long>("AttachmentID").ToString(),
                                                       AttachmentUrl = dr.Field<string>("AttachmentUrl"),
                                                       LeaveDates = dr.Field<string>("DateStrings"),
                                                       totalLeavedays = dr.Field<int>("totalLeavedays")
                                                   }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Technical Error
        public MessageHandle AddTechnicalErrorDetail(TechErrorCreate ld,string urlDomain)
        {
            MessageHandle result = new MessageHandle();
            string extension = ld.fileExtension.ToLower();
            if (ld.fileExtension != "" && (extension == "jpeg" || extension == "jpg"))
            {
                string folder = System.Web.HttpContext.Current.Server.MapPath("/UploadattendanceDoc");

                string filename = ld.HrmsNo + "TechnicalErrorAttachment" + DateTime.Now.ToString("dd-MM-yyyy");
                string filePath = folder + "/" + filename + "/" + filename + ".jpeg";

                List<object> parameter = new List<object>();
                parameter.Add("@Errormessage");
                parameter.Add(ld.Errormessage);
                parameter = MapDate(ld.ErrorDate, parameter, "@ErrorDate");
                parameter.Add("@EmployeeID");
                parameter.Add(ld.EmployeeID);
                parameter.Add("@AuthorityID");
                parameter.Add(ld.AuthorityID);
                parameter.Add("@ProcessedBy");
                parameter.Add(ld.ProcessedBy);
                parameter.Add("@Attachdocument");
                parameter.Add(urlDomain +"/UploadattendanceDoc/" + filename + "/" + filename + ".jpeg");
                //parameter.Add("http://49.50.66.74:88/UploadattendanceDoc/" + filename + "/" + filename + ".jpeg");
                //parameter.Add("http://pswc.in/UploadattendanceDoc/" + filename + "/" + filename + ".jpeg");

                List<object> outParameter = OutputParams();
                string[] output = DB.InsertorUpdateWithOutput("TechnicalErrorCreate", parameter.ToArray(), outParameter.ToArray());
                result.Success = Convert.ToInt16(output[0]);
                result.Message = output[1];
                if (result.Success == 1)
                {
                    string im = imageTech(ld.HrmsNo, ld.bytedata);
                }
            }
            else
            {
                result.Success = 2;
                result.Message = "Invalid file uploaded";
            }
            return result;
        }

        public MessageHandle UpdateTechnicalErrorDetail(TechErrorEdit ld)
        {
            if (ld.ApprovalFlow == null || ld.ApprovalFlow == "")
                ld.ApprovalFlow = "N";// F=Forward   SB=Send Back    N=Normal
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@ID");
            parameter.Add(ld.ID);
            parameter.Add("@Status");
            parameter.Add(ld.Status);
            parameter.Add("@Remarks");
            parameter.Add(ld.Remarks);
            parameter.Add("@ApprovalCategory");
            parameter.Add(ld.ApprovalFlow);
            parameter.Add("@StatusUpdatedBy");
            parameter.Add(ld.StatusUpdatedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("TechnicalErrorEdit", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];

            return result;
        }

        public List<TechnicalErrorStatus> GetTechErrorStatus(long EmployeeID, string hrmsNo, string startdate, string enddate)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeID");
                parameter.Add(EmployeeID);
                if (EmployeeID == 0)
                {
                    parameter.Add("@hrms");
                    parameter.Add(hrmsNo);
                }
                parameter = MapDate(startdate, parameter, "@startdate");
                parameter = MapDate(enddate, parameter, "@enddate");
                if (EmployeeID == 0)
                {
                    parameter.Add("@HrmsCode");
                    parameter.Add(hrmsNo);
                }
                List<TechnicalErrorStatus> result = (from dr in DB.ReadDS("TechErrorStatusGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                     select new TechnicalErrorStatus()
                                                     {
                                                         ErrorMessageDetail = dr.Field<string>("ErrorMessageDetail"),
                                                         EmployeeName = dr.Field<string>("EmployeeName"),
                                                         MobNo = dr.Field<string>("MobNo"),
                                                         ErrorDate = dr.Field<DateTime>("ErrorDate").ToString(),
                                                         ApprovalStatus = dr.Field<string>("ApprovalStatus"),
                                                         StatusUpdationDate = dr.Field<DateTime>("StatusUpdationDate").ToString(),
                                                         Remarks = dr.Field<string>("Remarks").ToString()
                                                     }).ToList();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public List<TechnicalErrorStatus> GetTechErrorStatusLevel1(long EmployeeID, string hrmsNo, string startdate, string enddate)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeID");
                parameter.Add(EmployeeID);
                if (EmployeeID == 0)
                {
                    parameter.Add("@hrms");
                    parameter.Add(hrmsNo);
                }
                parameter = MapDate(startdate, parameter, "@startdate");
                parameter = MapDate(enddate, parameter, "@enddate");
                
                List<TechnicalErrorStatus> result = (from dr in DB.ReadDS("TechErrorStatusLevel1Get", parameter.ToArray()).Tables[0].AsEnumerable()
                                                     select new TechnicalErrorStatus()
                                                     {
                                                         ErrorMessageDetail = dr.Field<string>("ErrorMessageDetail"),
                                                         EmployeeName = dr.Field<string>("EmployeeName"),
                                                         MobNo = dr.Field<string>("MobNo"),
                                                         ErrorDate = string.Format("{0:dd/MM/yyyy}", dr.Field<DateTime>("ErrorDate")).ToString(),
                                                         ApplyDay = string.Format("{0:dd}", dr.Field<DateTime>("ErrorDate")),
                                                         ApprovalDateTime = string.Format("{0:dd/MM/yyyy HH:mm tt}", dr.Field<DateTime?>("ApprovalDateTime")),
                                                         ApprovalStatus = dr.Field<string>("ApprovalStatus"),
                                                         StatusUpdationDate = string.Format("{0:dd/MM/yyyy}", dr.Field<DateTime>("StatusUpdationDate")).ToString(),
                                                         Remarks = dr.Field<string>("Remarks").ToString(),
                                                         EmployeeDesignation = dr.Field<string>("EmployeeDesignation"),
                                                         EmpBranchID = dr.Field<long>("EmpBranchID"),
                                                         EmpOfficeName = dr.Field<string>("EmpOfficeName"),
                                                         EmpBranchName = dr.Field<string>("EmpBranchName"),
                                                         AttachmentDocument = dr.Field<string>("AttachmentDocument")
                                                     }).ToList();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public List<PendingTechnicalError> GetPendingTechnicalErrorDetail(long reportingOfficerID, int designationid = 0)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@ReportingOfficerID");
                parameter.Add(reportingOfficerID);
                parameter.Add("@DesignationID");
                parameter.Add(designationid);

                List<PendingTechnicalError> result = (from dr in DB.ReadDS("TechnicalErrorPendingDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                      select new PendingTechnicalError()
                                                      {
                                                          EmployeeID = dr.Field<long>("EmployeeID"),
                                                          ID = dr.Field<long>("ID"),
                                                          EmployeeName = dr.Field<string>("EmployeeName"),
                                                          EmployeeMobNo = dr.Field<string>("EmployeeMobNo"),
                                                          SimID = dr.Field<string>("SimID"),
                                                          ErrorMessageDetail = dr.Field<string>("ErrorMessageDetail"),
                                                          ErrorDate = string.Format("{0:dd/MM/yyyy}", dr.Field<DateTime?>("ErrorDate")),
                                                          ReportingOfficerID = dr.Field<long>("ReportingOfficerID"),
                                                          ReportingOfficerName = dr.Field<string>("ReportingOfficerName"),
                                                          TechErrorStatus = dr.Field<string>("TechErrorStatus"),
                                                          ReportingOfficerDesignation = dr.Field<string>("ReportingOfficerDesignation"),
                                                          AttachmentDocument = dr.Field<string>("AttachmentDocument"),
                                                          ReportingOfficerMobNo = dr.Field<string>("ReportingOfficerMobNo"),
                                                          ReportingOfficerHrms = dr.Field<string>("ReportingOfficerHrms"),
                                                          EmployeeHrms = dr.Field<string>("EmployeeHrms"),
                                                          EmployeeDesignation = dr.Field<string>("EmployeeDesignation"),
                                                          EmpBranchID = dr.Field<long>("EmpBranchID"),
                                                          EmpBranchName = dr.Field<string>("EmpBranchName"),
                                                          EmpOfficeName = dr.Field<string>("EmpOfficeName")
                                                      }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Dashboard
        public List<DashboardAttendanceTotalCount> GetTotalAttendanceCount(long EmployeeID, int Officeid,long branchID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@OfficeID");
                parameter.Add(Officeid);
                parameter.Add("@BranchID");
                parameter.Add(branchID);
                parameter.Add("@AuthorityID");
                parameter.Add(EmployeeID);
                List<DashboardAttendanceTotalCount> result = (from dr in DB.ReadDS("AttendanceTotalCountGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                              select new DashboardAttendanceTotalCount()
                                                              {
                                                                  AbsentTotal = dr.Field<int>("AbsentTotal"),
                                                                  PresentTotal = dr.Field<int>("PresentTotal"),
                                                                  TotalStrength = dr.Field<int>("TotalStrength"),
                                                                  LeaveTotal = dr.Field<int>("LeaveTotal"),
                                                                  TourTotal = dr.Field<int>("TourTotal")
                                                              }).ToList();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DashboardTotalPending> GetTotalPendingCount(long EmployeeID, int designationid)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@ReportingOfficerID");
                parameter.Add(EmployeeID);
                parameter.Add("@DesignationID");
                parameter.Add(designationid);
                List<DashboardTotalPending> result = (from dr in DB.ReadDS("PendingTotalCountGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                              select new DashboardTotalPending()
                                                              {
                                                                  TotalCount = dr.Field<int>("TotalCount")
                                                              }).ToList();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DashboardTotalAttendance> GetTotalCountPerAttendanceType(int officeID, string typeData)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@OfficeID");
                parameter.Add(officeID);
                parameter.Add("@TypeData");
                parameter.Add(typeData);
                List<DashboardTotalAttendance> result = (from dr in DB.ReadDS("EmployeeTotalCountPerAttendanceTypeGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                      select new DashboardTotalAttendance()
                                                      {
                                                          EmployeeCount = dr.Field<int>("EmployeeCount"),
                                                          OfficeID = dr.Field<int>("OfficeID"),
                                                          OfficeName = dr.Field<string>("OfficeName")
                                                      }).ToList();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DashboardTotalAttendance> GetTotalCountPerBranchAttendanceType( int officeID, int branchID, string typeData)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@OfficeID");
                parameter.Add(officeID);
                parameter.Add("@BranchID");
                parameter.Add(branchID);
                parameter.Add("@TypeData");
                parameter.Add(typeData);
                List<DashboardTotalAttendance> result = (from dr in DB.ReadDS("EmployeeTotalCountPerBranchAttendanceTypeGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                         select new DashboardTotalAttendance()
                                                         {
                                                             EmployeeCount = dr.Field<int>("EmployeeCount"),
                                                             OfficeID = dr.Field<int>("OfficeID"),
                                                             OfficeName = dr.Field<string>("OfficeName"),
                                                             BranchID = dr.Field<long>("BranchID"),
                                                             BranchName = dr.Field<string>("BranchName")
                                                         }).ToList();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DashboardReport> GetEmployeeDailyAttendanceDetail(long EmployeeID, int officeID, int branchID, string typeData)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@AuthorityID");
                parameter.Add(EmployeeID);
                parameter.Add("@BranchID");
                parameter.Add(branchID);
                parameter.Add("@OfficeID");
                parameter.Add(officeID);
                parameter.Add("@TypeData");
                parameter.Add(typeData);

                List<DashboardReport> result = (from dr in DB.ReadDS("EmployeeDailyAttendanceDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                               select new DashboardReport()
                                               {
                                                   EmployeeID = dr.Field<long>("EmployeeID"),
                                                   EmployeeName = dr.Field<string>("EmployeeName"),
                                                   RegDate = Convert.ToString(dr.Field<DateTime?>("RegDate")),
                                                   MobileNo = dr.Field<string>("MobNo"),
                                                   ID = typeData.ToLower() == "a" ? dr.Field<int>("ID") : dr.Field<long>("ID"),
                                                   DesignationID = dr.Field<int>("DesignationID"),
                                                   DesignationName = dr.Field<string>("DesignationName"),
                                                   GenderID = dr.Field<int>("GenderID"),
                                                   GenderName = dr.Field<string>("GenderName"),
                                                   OfficeID = dr.Field<int>("OfficeID"),
                                                   OfficeName = dr.Field<string>("OfficeName"),
                                                   OfficeLattitute = dr.Field<double>("OfficeLattitute").ToString(),
                                                   OfficeLongitute = dr.Field<double>("OfficeLongitute").ToString(),
                                                   SimID = dr.Field<string>("SimID"),
                                                   Adharcard = dr.Field<string>("Adharcard"),
                                                   HrmsNo = dr.Field<string>("HrmsNo"),
                                                   BranchID = dr.Field<long>("BranchID"),
                                                   BranchName = dr.Field<string>("BranchName"),
                                                   EmployeeTypeID = dr.Field<int>("EmployeeTypeID"),
                                                   EmployeeTypeName = dr.Field<string>("EmployeeTypeName"),
                                                   DateOfInActive = dr.Field<DateTime?>("DateOfInActive").ToString(),
                                                   DateofJoining = dr.Field<DateTime?>("DateofJoining").ToString(),
                                                   DateOfServiceEnd = dr.Field<DateTime?>("DateOfServiceEnd").ToString(),
                                                   InactiveForAttendance = dr.Field<bool?>("InactiveForAttendance") == null ? false : dr.Field<bool>("InactiveForAttendance"),
                                                   DateOfInactiveForAttendance = dr.Field<DateTime?>("DateOfInactiveForAttendance").ToString(),
                                                   ISActive = dr.Field<bool>("IsActive"),
                                                   AttInDate= dr.Field<string>("AttInDate").Replace("-","/"),
                                                   AttInTime = typeData.ToLower()=="p"? string.Format("{0:HH:MM:ss}", Convert.ToDateTime(dr.Field<string>("AttInTime"))) : dr.Field<string>("AttInTime"),
                                                   AttOutTime = typeData.ToLower() == "p" ? dr.Field<string>("AttOutTime")!="0"?string.Format("{0:HH:MM:ss}", Convert.ToDateTime(dr.Field<string>("AttOutTime"))):"0" : dr.Field<string>("AttOutTime"),
                                                   TimeDiff= dr.Field<string>("TimeDiff")
                                               }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Function
        public string imageTech(string hrmsno, string bytedata)
        {
            try
            {
                string folder = System.Web.HttpContext.Current.Server.MapPath("/UploadattendanceDoc");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string filename = hrmsno + "TechnicalErrorAttachment" + DateTime.Now.ToString("dd-MM-yyyy");
                //string filename = hrmsno + DateTime.Now.ToString("dd-MM-yyyy");
                string filePath = folder + "/" + filename;


                //  bytedata = "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";


                //Check if directory exist
                if (!System.IO.Directory.Exists(filePath))
                {
                    System.IO.Directory.CreateDirectory(filePath); //Create directory if it doesn't exist




                }
                string imageName = filename + ".jpeg";

                //set the image path
                string imgPath = Path.Combine(filePath, imageName);

                int mod4 = bytedata.Length % 4;

                if (mod4 > 0)
                {
                    bytedata += new string('=', 4 - mod4);
                }


                byte[] imageBytes = Convert.FromBase64String(bytedata);

                File.WriteAllBytes(imgPath, imageBytes);
                return imgPath;

            }
            catch
            {
                return "1";
            }


        }
        public string image(string hrmsno, string bytedata)
        {
            try
            {
                string folder = System.Web.HttpContext.Current.Server.MapPath("/UploadattendanceDoc");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                //string filename = hrmsno + DateTime.Now.ToString("dd-MM-yyyy");
                string filename = hrmsno + "LeaveAttachment" + DateTime.Now.ToString("dd-MM-yyyy");
                string filePath = folder + "/" + filename;


                //  bytedata = "iVBORw0KGgoAAAANSUhEUgAAAMEAAAEFCAMAAABtknO4AAABg1BMVEX////oTD3m5uZMS01PTU8AAADy8vIgICA4OzYPM0egoI7/zMnoSzza29o2Nzb6+vpGRUdBQEIwMDGFhYbIycmxsbLp6enoRzfi4uLv7+/nQzLnRTT0//+bmYnV1dXxTj6oqJgXFxfAwMDJQTT98vHnPiyzs7O3Oy//0s+9uq773tzmIwvW8/QvLS8kIyTY4+LZRzndzMn1sKoREREAL0f/UDvmNCKWlZZZWFp4d3gvMy32urX84+HraF1kZGTugngAFjQAITs2PkrpXVCko6TNzcPviYHvk4vsd2zwopzpVUjrhHvlYlbfrqrrMh5/f3+sPTMAACTRurspNjbwnJTltK/pHwDV/P3in5ndr6vxm5TgoZytPTpQZmi71NWUfHxsSE1QFRYqVWN/lJ0nGCgVFSl2O0NpcnsxSFpMYG1lhJBNN0TRTD0AAB8cKTs7QEyWQD8AEDO7lZbFqqmvpaVfZHBnNT5XOUR4OTTEYlnRf3kAITBGNzgMMzY6SVQVGxF+fXPkmaOGAAAgAElEQVR4nNVdiX/bxpXmAZJ2BBAAD4AAFTCiCZqlRFGiJB7mIcvEihQlU7Yju47jTbObbuy2Tupe2e5um/ZP3zkwuEmCEGSpz/kpJAHMvG/eMW/eHIhEwqJ+dHYWWmG3QTWapuV/aQhncjRKixu3zUZwYo/FKIAgD26bkcCEEUSLp7fNSGBiJ0WIgI7+6+pRS45iIbC3zUlQ2qBpJASxftucrE9spVKJROpjhCAqT26bn7WpNpleTFuVyBSZcpQu3jZDq2hwdjpp1SrG91ZUFmlRHg762BCi6h235dpcLhZlVZ32B8hkKzPc9PI0ImI1Es+BYtUsGO8Y6boSFeXxZANwyU6LetOfnWEh0ON6pK/K09Zts7qACAKo8PTsahCp60KIymcXui23IhcigHhHTbqvRg0CoZx6OqiNdRO+ONbV6LhSpGGE0b9tZj2Jnap01AKiODvbGCII9Ox8pncJA9Q3iNO72blVJlExasdw/AFxLk7Pi7oaDdEP6l215o2hTQygzYlS9THn9HSK/t++qwgilTO1KNpAYCpOTrE+7WF1ku8sAoChNRVlNwaR6Be+RJ+f9euDyt20hkhl42zoloITkawWx9NJa+NOjnvYymTmoUlOommxWIzOLiat+p2SxWBjEm0XfQAwYcjti7M7E2rUJkMvK1itU9Hp1R3Qp0F/XPT0RH5kIRbFYf92BVE7m6l0MPYJCHXYur1h3OB4FkB7nCTKs8ntYKhP1YDa4yS62J58eoOotMbFUNjHJI9bn9i71i9EcTVfa5AoTmufkP/BaVgKZBIttiefzC3Vh3LI7GMqDj+RGFrRcBXIJFH+JKPpMzVsBTKJlq9u3KArkxC6gCUQisc3bAyVobqajWuRfHGj3Vvl+GZs2ErF4Q32buxpmL3YIpJvMKlxddMqpEM4vylbeNn+JACiUfWGJq9q0Zv0Qja6mfxeZXhTHZmb6NlNOKQ3ViOg5fl8G9FcDQjMWoTLQRSn4QPYMGM5UW3Tw8nrl61+v986O5+p64OgZVUcXsEC+i+/vjq+UFVHR6mGr0cT0k7iXD3/imluGjSoHctr2rg8v2jVk0YJUmz/aja3OTp6HLY/qhMRqO3z/Z3mJps0iWUH59trdHX0XN5IbloKSG5KzebXs7lVDMWwgzx9qkNULwD/kpV/xMFmfzz366nk9oTddBTAJgs7O1eyRQziONyuuY7VRN5+2mwWkjoA2HUSLJvSdNsfBFWssaxklkBASM2d/eHccl+4K2PwMglZ3d9hYjrTkaSk5AAaHQSbnPgyBjFa1wUAHowpSgwooV4A09wZmmXQapgA8Py22N7fURjUXmykoMW3EonEbleLkWb0E7fS27VNCTd/rpcGBSQyvRyWCSsozZ1js4xQ3VEfOaJXr3cYRpd+Np042NpKpbYOErwWQRxsDl6t9qrzcyyBSGx0AEpIbYECDkYMboSC0myqhkuA87hhUQUpUfv8l4yCjJhVGomt1EEilThI7aa2El2sWZv99ipTUIdYZSJaIpEClNjaQiV18M+MsrPfNmYdxuF1zAOYly7Omk2FQQAEDlSfGFVz5S7mI469k3SxKvpuv0Q6FOkktnYB+EQnl+vsgo8JDRegMDuviSnQxfDUaAMq5/zrJsMIqAG7CVBnFzoSiToACHYTPaQGm60VxqyOsRIWEPBUogxLL4MvBwnUNkmGaTJGABniOj04PS9Hm01sBZEqrD8hoEsKYmXrQEHCqayYRJifIStge1h0HVz8KJHaPeAjCJrCNF8Tl1qchDbUgWYwvwJmXEAN1QXtfpDBl2LxLcRMFgthhTsCjgiZUQqLII/L0BJYHlCNgBAUYgniNLTIYo+GnrTJKFCJ2BxUnK0Ebh+lgYWQLiAEy/uEoox8P7CClFUGSCKJS12NmB3SDHQ0LAQVEDeqM6BDjITdCKq+By+xlwm9PZEabbbmyxCoM6xEUIgQdiMHyyigb1uUQBAYttwOK7CArkgd7ugIWNyCu4mswjI9YNPEKJE/XY7gAncGHEYAVLEqSXnuAJaxxSMpFgCCr4hTDm1tUg0iOCYIiA7sJhIHCQLAJ4IxRsDrCIAuHoAODX/ECEAlzX2ZrI8Jy51uAC+PEUBBR/K64oBaUwZhZ+QPATs6MJ7bImVsdSUDgWqs8AkJQZ8gAGEYtGQL4wYjuAU3X/pBQKRoo8RlxC2D0BEwBashWmgXuBWE4PVSBLK4yVq8qR1BDl4SlJuTwRQisPRodsJKBLzpUgRFNWbt0WwA4rhHgzJ4QbLjoSIAXTJEgEK4iIsBvUNjd5b3aPR8HyOQEg4xbh0USHdg8aahTSdAS6Zhj8aQ4Hpkh5AY4eh4k1mRmp+/3sGhaXVra9d8fhe6MmDIbEyx9mhhelNcOaPbsgSDU9OcDxI9PMxim18tVSKoi02EQAKaaGmERKKqR9dQiRgjeaOGNStVh/GaPGsiIeABQqSTScAhDhifJNJ5PNBkheZ0VcZC3W/qAwShe0BKOOjiEQ6M64AInhrNoIbZJwMhPEW2TEaZjHbZ5TN8N5sXUPUSGKq/WDlBpR438WgIlFDujOKZDDfqlNkI6gsQAIaZkWagZ2HFRSzSbhlFRgweKEMxsJIQEyRjpC8xO7OVA2Vxvr8jGKmOpBCLCUmS70BGoJh2HBWHYcamgNrHv7RCcJCk7JxtrwIAhKA2mwVnuslUIWZn30zaiOHNI+CV+PT2V1iPQHDh4AHmTXYYX9P8YJwB28BVAIMANJtjU44hjnBIwk7exxCUgmSrXpIYxVb3EqLboB3QQMNaQAw3DbNjHWDIb8ICECHTZ3L7hS4FhSkIOgpJKChggK6oPqeoxFdXO03wBHk+CdhXsA03m9akXXgdWiTyhngHuf10p8kQEEyhUMAfQEwv+p5jE+fnMOsBySwACUAZ2pKvIc7knJlZqO0pY2Ag1GzuXM2L9J4/AHs03RYVVyFMc+dp256Ap8PbfKFvbIruRUul9uwpYLlpqbjZfDqbl6J7ez6T13t7UbU9UZpWEKDE/fO5XIJ1GAhm4S0U0dfo09EHD6IlVRWPnzI7hJovTmftI/rhA7/r7Wh678FeqS0PvwYgSCH7r8dquwSvmKWEmbPbIMmD0t7DhwBEe7s9nk5efw3nj+Tttrj34OFeyR//kEqlB6AUeT6PokJen46L8zlg/6G9GULs0CJ1Qz9RPQ9BS8lqG5G6B9gHNa8BALfEM1AKKAQUA/4U9x48QG1jlWOYGxYGZsBGg9ofPHv2EOKAtT58+OyZo2bfGPRScCGwFeylhJm7HtiWVJeA1aJqET3YW59/VAptKQRK1VWKfBUegsqFPV6gAQHtAQRcYyD+YSElaNOoEADHo5QwJ/YrU2fEAzGUANHXW/GLylhUSJh78fAMyKem0MY3EWO38U0RLXp6snaYy4zOvEaPotxW5WuuO6VF6FFnDzwg0NEQARhhhZVKb1+0zi/U9rwtB5MQLbfnc3V83KoV/v3IfVkchongpQePpYffRNjKYOPseKzO53PQMxVFerVl03AHCOjHwBOgS94YwM3Mm7/yQhBidwDCCo/FUaUH78jlSr3fenM+HY6jogqUApEMSNSpCL+A31AvLkYvhsenV62aaajffOuBINzTLmoeu4To0n80rfewlcpgUK9tPL06hWBmoK0R0xCNGJ2Nh8Ppm7OXG7U6aHa7jUr/6WUH4a7PIXvWbXT09p3Hrd9BMDpVICjwJ8lW4NfIN02PByLM+1976Z4a6jKvwYVHFfTRf33nulNLfLOwFPb+D1rBxX/n5PH3nq4oVATea+xKb59rjhvzJ4+9BINJe374+Ek2Z/mFLb978vjw8K0XgpBX57jCCgzhp+fv8xJRalbKv39+eP+5WzD48nfP7wN6/Pzk/W9++x2g3/7m/ckPjw/vH/7uyANBiFOxiLzDitKHw5PnT77Ll3O5XFl79/4PJ5DHHzpenWnsHQIA6PDk5DGik5ND9P2ZhycKM92FyHu5Mn30PWjCk8cnP/4IuML8wGb+S9n5PPPd7x/f96bDJ0defUgx5F3xnmEF9Ki/P/Rg6uSHw3edag7lYxhGyb97//y5130IwOFDz6io+DpcBF5hBdKj6O88WTuEigJE8+Q+ks7JAvbhnR89Bxi0GPJyzf6ifFap9GRx6xJazP/9w588dSj8U3dqCydnSrRbCsBWIR3ef6ITQKP/5Lj38HtvAIBCXrdcobcXDXJKUd7CF9CeP5y87/ayf/zTixcv9nUCH//0x19djn4+fPwH0+IBru9L3kkOcR72nnhBakXbC4Lo0tH3Px7qbf/kL++0Fxt1ECDV6zVAG5jgxzqIiOq1l3++/Mvvdbs4/PF7r54Aht2z85B3YCcLwqZwJi5YRkcf7f0ExXDyc2e/BlnfWEg1eH3/zz3Qkd0//O8PXipEq+1hq7K5GQsVghSD00WV6bb38iEwYP8IBPAuVq8t4d5EUav8CqjSx5KHF6Lbr+h+hRVAhckQAbBMDJKwWZ+22972cHT08df79dXs65Ts/pV2CwCojzipRdhYAVbHhIhAiOmUZDemqscCa7oErKE4WapAFqoP+h/cFiDO1dlZHaqsXpsUGgCWAABtk2QH56pLDijlVlLHV7VBvbZUk6Ah1Frurc20PG9P6sD/JGMFo7rQ9MgQAcIARgtvom1bH01H91D6Tp6rw0kfclkzaMP8iNxT/+w42nZsjQfao07Rhn1WKFgqC0sISWuhuGUGb+Rt26YWmECEKVQZ7gcZH0/O+v0NnWviV/uts8nxcFYEg06YebXMdLRfiWd15P7ZmL2ukNyRZAcQK8CVppX+sN22rAOB+dM9nAcuiXh4DFRtrBM6LwTm6sHgHyWO9/awFES53aZPa5hTuwBQVaEA0B2RUwwg0mhd2D0TSWoDGIC/UknGSQucuECuE6nbA3wdeX55aOYski4AIVmC4AYAHCs+d6w2ffXKoU1QneBswAOoJ/qRM+gvTHbDeQ/wFfJPq9vbs9OBGTt48E/quR4lvQBAp4QvV/pTsW3bC0VjUTx7aKdngKDLKhHdmbasA2GnsREKwZidVmBgMMbH9dYUuELrshZ9asCGAKkO0KQiTDXOrjZsoafbAoxqri2ERW1jEQMQRKU/GarztuX4Ezi/ABSHUBROE4hFcI84vWoNHHGnFFtYy/WN2dMKXGKANKidTWcw5ygbOlUiJENPJNOgs/A4L2exABBd05jZpYUXHMVXBrX+ZDxTt+fbczzV2T5qb29vt+HBS/163TPk9zY0k4TrIVgmArcYMGi2UtsAvdfp8fHx6Zv/+d8N0O7sQm1eIYBrC2FV+0AxLDM1JZv4v6qytIKVAGKxawBgV5cOxbCQ/xHc75VI9RZZow8BXBPCahFgDF5iYJVRwqBLT0lJ/vi/TnjktwYvMWgJK+26sngRdlFP46t4f+RLiXAdzmZik4INAZV0xgeLOxqP4gMKgV3liOztZKkF2GeBZVIWBJJUKMQst/iyYJMCCsGnFRASzCw85K6QtOiRpvcrxDH6tgBCwYRg1lLwCLDdpKsrbG1EEcOUu2ZjQDk4xzELCzRvCyQEiwh8AYBDH9bkH9Sa3NIRlC0j7ULStwCSFjUO0q3ZePMJIWZ18IVkFQPoRRY/sowEa2nrA7A+7bPjcRF2qZnkOi7BSlZnuLYQrI6osLbhkVoV7EkDApAigrCZJE+viwA8J8QkSYBACnYWBPSfLwTYHUkBZSAABJPj2s4m+ra2O2KFZn1/vx4D1SdtXZtyGWOySkfrrBYMm0UIcv67RjsCNvLm1Xx7vJ+UAnkj9lgtyvLsShBYqwyE3KWijBQtVi6valohif1pJziCr9tRWp2fbjaDDPkrqkjTorg92UnaEJSzuSqSwWoOCjxCMAroi4D11mDCn24PA40R9Mk/8LRdBuWypuUVrbBaiwQFBxbplQOlhQgG+AjzYEvu9Gn8+etNGwOCxnTKAEVhtRYly7g/2Ir5DkNtBDr5zQlqx0CTy/oaUzpaYX1H2Q6KZEmfHNCfAuvto/SHGOR0sj5ObKK3qdgRCAs+u4glgZEW0JQl+DoClJ8sBlgGr++aUF+Cz/a4KFcQYKgkMEpMySnLEKTJEC04ggheVRNgO0iFnD9fdyAQgCErgqYJ5XxZ0ZYjICOEUcC4AiLADkW8WBtBHZ/bQF9ABbSWCjjP56ROVanmJSUvLGFNMoZp3YC9MkSgr7tff8u+vgwBrfKx6QCQQSeXq5bLsXyH6Wi5xbyxZYIgXQiOoIIZWX/Vnb7KF7sxO4Ky1MnnNQ1EPeXqMhmwHWOMlgvmThECrM7i8boI9N0k+CwqOwLQ8NWCANgH/Vp+iQwiPQNBNZgpQwT6imlxuGZYMcBT37QMDdlRPRmFFWJLhz4CyxkIAo5xUMoUv5Zm7W1FekhByxE3Ap8kFRoGAj5YESic09e6rnuQzrn+OpLZNRDktgwEibUyNyZBBPpK0TWXAJPVmfj9ZsEQJPOWfJESKK5AmS59+4a43uGzZJUy7gqDIbC4okQiH6gMnKvT38UxW6tHIMvq8MrhgDKwZH4DxhUYgb5Kca1N++QsWTo6CI5ASFsQdAMZAkawgRGstTWqoi8U13flBUIgFA4sCNKBhggMQjDQw4N1dlToz0TF0+AIzJgC0m6gXhkjiOgTve01EBAz0D1YIATG8EY35SDOSM+66/HBOsv5yTpx0osEQtC1IQiUr9AR6OysM0Yg6yFmG9eQgQ0AGCIER0CiTP/nF9cJAn2DcBAEkmRHwAf3RUSp11jP3xdtrsj/fJqF2JwdQaIQwJR1BDXV1qA+aKIbskiOC/Y5f2BDoDkQBAqwMYKBPl70/SJd9pwYMsnSBEFw6UCQDeAPdBkMbDGODzJ2whpPrK9FQpJyIOADIND7AyPO9HuGiLF1y4hE1q9bEHoOBL0AWkQQkDNL/JpyjazENF4qF8CPSLbALhgAokVGmCb6REB2rJgH7QYap7PWTnkUKPlLZsLPbKHyaiKGTI/JL4GGJ4JlgMBLwZIVOgIjyvE30mSJGZjBYMDEreGPGkqwmTiyOIp0UD7fGlohK/TNFE3QqbwIjk8PlOVLxRYSmXkiW3NFf3FFjSwgNYcUQRHEImhGuRx0DocgIINe0d+J/MbGLbMDCTwhDKSQSmgBk0WCROaeiH/HqZOVdO4+TY6FpyUFzJfkswH8KDpiKpYji5IqF2TxsK/RPtkGa3kPRK+XrSrJYNqUXPchAVaklLO9Lk9VCQI9fRX1M9qvmK5IB8xe8hzfyHQvtRxoG0kKOsG9kkDRqOm1HpVupLl4nKN0DvRW9bdR0NjQbvThhVGcilMUn87w3VGnqoD+lvW/xMwXCbDIpMDk8tluppFO8xQFqozzVYde+NqsaRwqYGyvFUYcLI6Kx+M8z6ca3KiTz+GVGtcHIuF3EMSUqpYdxfl0ejeThuyjCinSIRAEvjIuLbJvzkxUZjECCksCiCLTaPDUKJvVgEAEfCRiEq7B8KVewMcgwsew5apa5xKoPCgS6g1FpaEEUHNRnLHR2XjZt5/U4xVxpqLhTDscLBEjAAA48IniOIAlneaobi/byZdz+Hg4csQAMhcLwTPrzEuxgpIrQ85HXQpIFbDMozJRO3GgVFRTnOKNPfTEP/qJTo1XP1lOMtM4LFbYLBlQPsaDFYsDUCAWnuuORgBMR8tX4ZZxRSmgw97gBuWCosBN5NW8pnWyl6NRN87hRzgOGKveNnHMNRICh7WIzxMOyLkxfuaVjeGNxXPliQxI8ZZ/pHZAkK1MppHJZCB7gDhMPGpncAloSgY1OLzbfJ6yFhiHeprWZUAM2QyXfbzpZ0CcqSVXXDUQABFn9MbS6yNGF9dbEDGEiIvrCOKEKJPitma3ISCtBFyRscyWxAm06AMBcUVmbA0QWCSsmxmpnYAweDIuGXcQx0I00fjB2gwmHCgEHv3CGQiMDd703nCy4pW/xrFpliiqzOmVQgQWxnTBOFTKyiFl5RNft6oe5f4Cv2ewoONdY9V839jAR4vF9nRpzoIcXWfNkLG8zgOwY15XGLP97A1qAKDsPxPbt/5Hno/bbosTSXM9gwP7UQ1idFnSwkBL02fGng2Nj1vcBGWqBeXQARfXpj7ZlMeJmrIVGEcOlesamQnWcWTJUnMwj3Wg5ejpBsYAIiNYAYe9hJ1FZ/t7/SOgLSgWCQn9RUIwdSjScuxDdcZHknUR3sSCli5Gxy2EIdnjLU7CUqu3Fi0BY1UhqzBtN0C3bAFQdx2to780imWFXLVz2aWornmAjP14E5pWL7AYsqS3NKtdrUWESce1xYIiN4DIxQRQoV2buosTBrDeozJbqd0G7H8yuxw50WbqkJesn9jMarxuYO76FjSl7Sc3rGV3ZzjzhJ3KufuEg9KHLyHrMK5J3wP/YIdJHrEdVARc19To15RRJu3ZfHFrD2Uy4rPhPZ7kKM2ythEGas4jB0t7aZ17kzJpvN3HelgUHR1a38ucBC7JrHoBd4ta1eb3PUVjfOBHpgaB4PXi6KhU+uBQjejfDM5R+AJDmkYWPWI9KJZ2xlHKyIrBk+uFimGKJm756L6P4zvIsySZspbtjbrc3z6+/fj9jx+Mbf10qXR0dPTTlzrruj1CX99jXQjcg7ryKM4taefFvtVbiVwXOeqSEQDr3UxqdxcHiV/+/e9///LLD/r+yKNSdO/h24/fcrpUTaLiPQTdJiyPcFwqQ8dqjW6WN/l6APjLXDWbSek2atH0L/fkvQ9v3378+NdvYaj488825nXqMi4EnisBkuUux63gcjH3lOFg3Re5bpXVUGxOHIyp6d9+G/8Z/FtKeEQUdQjBjQBQtccHF4B3DwjqH1XZiLZlbXmk6HHKoS6LiWJdCOiiJ4JIMtfjeXcA5xOCx7U4363GQLkpg3VzxOGLeURp1mnJdFReFMiysc6I4pc4fS82if93ODSgPr0y8iOdXQQgvhbfFgSCDQE9vFLp4pLD49lcZ8RxfiFYDQH/0W/h+F6eHNEyQgPUYOwDQqGI2SfT0Xp/tr10+pAVqqM0b4zQ7BG0A4LVDDDB/4OOqJczIsskQhAYAB6WkriIxgmj1ckNSet1LYV4SyFuRNjWW4EAe3nb3giIgAsMADujqRhFoeCe6PuAUVZJL4JAQn6rJyLEcT0t55he7WU8RZB2/eJNHHzh2pkqjod0VHxzKsu+3wCcsRbj6qPtVmvUdumxxSyrD2NtRPFZ94/eCGBkVDke9usisGB2Mva9wtOCAGZXHBCMEZodQdajIA34IheA9CX43R8CNLKugGhuKsOXtvo/C8xEQGnV7IjXeyL9J+MPzH1ZEHgUX96F41gHWylg6dldX1IYkYIqw/WOvbcgyIGhX1LJd0BU2aUs6ZVut9vr5Jm8AcETQS7lQkA1YOaOvWz4gTAKupvchoCQVMjBbCkk8H8GJ9KryxHEUmnezhOVxvexWT8QukFPGPFE4EkrZJDccsqA4/RmTfZc+uWBYNnJEp8EQWTL4U2plJG/jnUd4nESxa2s/hMgwGlNk9Ij81ohs9ypprtU3H0kw6dGADplGwLeqhYKz8UX026P6ZozDreGAHRplqiCchxzwcQXQuDS1UiM4ju3jqDTsCCgrDqEKHewAAKfBsISurznEcOfFAHolE0eOd61Mdy7c6bScRifSyPes9BPigB0yoa5UhkPrdYaHggaPQQ12eN7AY8KCg+BYiKg+JGnlLbcAPQUH5vlg3bK4SFg7hldGrfrfXqUlnGMMhqGuXfS3YAnBYWHoBAnCKiG80R2ndieFQKVNmfbIlqaDxhWhIdAgB0CIn60SKWTvBlfULuUpcfIZ/iAYUV4CJI9HQHHLW5NECLptcUztg6g2uADdsrhIWAvM9idpqoeVwlJXTwhye1qtkJyDW6B6q2i8BBEOhgBTy117BIaKvENB0yAIGCnHCICDYcV6RXlKOCutCuWVjKeY1cfFCKCPBzrU42VTZnbTbl9f4GP97xuXk0hIqjCnB3fXV1nOev2VRLHOSMpnxQigjJEkAk4UGEpzgd2LwoXQZrKBB2ogGFcsAdDRKDwAMGi7ngljdJcsAdDRFDgoAyCDlQuM7ePQIKBUSagT4xkG7ePgKXAWD8d0CfeCQSRLgiM+MAI7oAWwQQ876c/8CTqDvgiGBjxXEA+tLsQVcDkL89x6w/Yk4VcJx2//fEBMOU4MIS03+OJ2aQkwAUYo3i6AdMct5+zA5TjQJe2simTBQUu2c72uhyfzmTQAmK+FzRtGi6CSDlDZZZ0ynDRS6cH18lneExo9fMoqynBT2UOF0FEASGmkxkWrjcvw3lToC67DR6uKAbMd+Fab62sXPd4+JARsJecRQispJSrnewIrfPD680B7xkKNHo1p3gcuH0HEERycS7TUWJKOa9lYatDPUfqQnVxo1cZuBsgDNZvCEEkn443MulMAxC2UZ4aXXa0fE655hnqiyh0BJFqXNcWPg1ttKwwQjLc1yzZKXwEkaTW6/UA60yYbyZaTDeAANBNtrmTbgbBp6R1EJBdIEFjsJshC4IV4UDZlMHldd4KECqxzOWjewYtn8hiR5ZlxlxPuQuKJFVHKQuAdGrp8CprufXevUePqPKtY8iNHtmYunfvH0tea1bo2u8FGHphvgVtfUpq9xz8A6aWZEpyzpvB7feWpdlvmtheyoOlJQgYyn3/vUdB01vXJzbrEgCgxLLIpef1xKNw3sAVgLR/eLCz20sWmH9D9AsroV8KZQ+h3XsUMN98bfIUQSb+2Weff/6ZN33+2Rf/3E27H+rekkNiO24EmfTnXyxgH9MX/2w0XDIImt+6NikuVvjRF8sBAAifdzN2B5xJ317nrFhYSTdSjdFnKwEACF98PkrDfUyY/dRB4HVZYZDU6XKgV3oEh97d3goFsoLojPC+dvBU+dMMABZSUqlqiL4AbbvQhB0E7gO35/PV3JKfmYwAAAAjSURBVPXf3xYasfCkgRh0o7/4AtPnDsK/IrfKwMMGbmrQ+P8fqKtA+4EH0QAAAABJRU5ErkJggg==";


                //Check if directory exist
                if (!System.IO.Directory.Exists(filePath))
                {
                    System.IO.Directory.CreateDirectory(filePath); //Create directory if it doesn't exist




                }
                string imageName = filename + ".jpeg";

                //set the image path
                string imgPath = Path.Combine(filePath, imageName);



                byte[] imageBytes = Convert.FromBase64String(bytedata);

                File.WriteAllBytes(imgPath, imageBytes);
                return imgPath;

            }
            catch
            {
                return "1";
            }


        }

        private List<object> OutputParams()
        {
            List<object> outParameter = new List<object>();
            outParameter.Add("@Success");
            outParameter.Add("int");
            outParameter.Add(50);
            outParameter.Add("@Msg");
            outParameter.Add("string");
            outParameter.Add(2000);
            return outParameter;
        }

        private List<object> MapDate(string date, List<object> parameter, string paramName)
        {
            if (date != "")
            {
                string[] dateParts = date.Split(new char[] { '/' });
                date = dateParts[2] + "-" + dateParts[1] + "-" + dateParts[0];
                parameter.Add(paramName);
                parameter.Add(date);
            }

            return parameter;
        }
        #endregion
    }
}