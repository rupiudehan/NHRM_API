//using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using NHRMS_WebAPI.Extension;
using NHRMS_WebAPI.Models;

namespace ITInventory.Common
{
    public class DataAccessLayer
    {
        DbProviderFactory Factory = DB.GetFactory();
        DbConnection con = DB.GetConnection();

        //SqlConnection con = Common.DataService.GetConnection();
        #region Employee        
        public MessageHandle EmployeeRegiatrationForAttendance(EmployeeDetail User)
        {
            MessageHandle result= new MessageHandle();            
            List<object> parameter=new List<object>();
            parameter.Add("@EmployeeName");
            parameter.Add(User.EmployeeName);
            parameter.Add("@EmpPassword");
            parameter.Add(User.EmpPassword);
            parameter.Add("@RegDate");
            parameter.Add(Convert.ToDateTime(User.RegDate));
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

            List<object> outParameter = new List<object>();
            outParameter.Add("@Success");
            outParameter.Add(User.Success);
            outParameter.Add("@Msg");
            outParameter.Add(User.Message);
            string[] output=DB.InsertorUpdateWithOutput("EmployeeDetailCreate", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];                  
            
            return result;
        }

        public List<EmployeeDetail> GetEmployeeLoginDetail(string username,string password)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@Username");
                parameter.Add(username);
                parameter.Add("@Password");
                parameter.Add(password);

                List<EmployeeDetail> result = (from dr in DB.ReadDS("LoingEmployeeAttendance", parameter.ToArray()).Tables[0].AsEnumerable()
                                         select new EmployeeDetail()
                                         {
                                             EmployeeID = dr.Field<long>("EmployeeID"),
                                             EmployeeName = dr.Field<string>("EmployeeName"),
                                             RegDate = Convert.ToString(dr.Field<DateTime?>("RegDate")),
                                             MobileNo = dr.Field<string>("MobNo"),
                                             EmpPassword = dr.Field<string>("EmpPassword"),
                                             DesignationID = dr.Field<int>("DesignationID"),
                                             DesignationName = dr.Field<string>("DesignationName"),
                                             OfficeID = dr.Field<int>("OfficeID"),
                                             OfficeName = dr.Field<string>("OfficeName"),
                                             OfficeLattitute = dr.Field<float>("OfficeLattitute").ToString(),
                                             OfficeLongitute = dr.Field<float>("OfficeLongitute").ToString(),
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
                                             isDeleted = dr.Field<bool>("isDeleted")
                                         }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<EmployeeBranch> GetEmployeeBranchDetail(long employeeID,int branchID)
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
                                                   BranchID = dr.Field<int>("BranchID"),
                                                   BranchName = dr.Field<string>("BranchName"),
                                                   ID = dr.Field<long>("ID"),
                                                   CreatedBy = dr.Field<string>("CreatedBy"),
                                                   CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                                   IsActive = dr.Field<bool>("IsActive")
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
                                                                  OfficeLattitute = dr.Field<float>("OfficeLattitute"),
                                                                  OfficeLongitute = dr.Field<float>("OfficeLongitute"),
                                                                  ISActive = dr.Field<bool>("ISActive")
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

            List<object> outParameter = new List<object>();
            outParameter.Add("@Success");
            outParameter.Add(success);
            outParameter.Add("@Msg");
            outParameter.Add(msg);
            string[] output = DB.InsertorUpdateWithOutput("EmployeeLeaveTypeMasterCreateEdit", parameter.ToArray(), outParameter.ToArray());
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

            List<object> outParameter = new List<object>();
            outParameter.Add("@Success");
            outParameter.Add(user.Success);
            outParameter.Add("@Msg");
            outParameter.Add(user.Message);
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

                List<ReportingAuthorityDetailFetch> result = (from dr in DB.ReadDS("EmployeeReportingAuthorityDetail", parameter.ToArray()).Tables[0].AsEnumerable()
                                               select new ReportingAuthorityDetailFetch()
                                               {
                                                   ID = dr.Field<long>("ID"),
                                                   EmployeeID = dr.Field<long>("EmployeeID"),
                                                   AuthorityID = dr.Field<long>("AuthorityID"),
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
                                                   IsActive = dr.Field<bool>("IsActive")
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
        public MessageHandle MarkAttendance(AttendanceMark att)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@EmployeeId");
            parameter.Add(att.EmployeeId);
            parameter.Add("@SimId");
            parameter.Add(att.SimId);
            if (att.IsInTime!=1)
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

            List<object> outParameter = new List<object>();
            outParameter.Add("@Success");
            outParameter.Add(att.Success);
            outParameter.Add("@Msg");
            outParameter.Add(att.Message);
            string[] output = DB.InsertorUpdateWithOutput("AttendanceMark", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];

            return result;
        }

        public List<EmployeeAttendanceMarkDetail> GetAttendanceDetail(long EmployeeID)
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
                                                   AttInDate = dr.Field<string>("AttInDate"),
                                                   AttOutDate = dr.Field<string>("AttOutDate"),
                                                   InTime = dr.Field<DateTime?>("AttInTime").ToString(),
                                                   OutTime = dr.Field<DateTime?>("AttOutTime").ToString(),
                                                   InLatitude = dr.Field<string>("INLatitude"),
                                                   InLongitude = dr.Field<float>("INLongitude").ToString(),
                                                   OutLatitude = dr.Field<float>("OutLatitude").ToString(),
                                                   OutLongitude = dr.Field<string>("OutLongitude"),
                                                   SimId = dr.Field<string>("SimID"),
                                                   HrmsNo = dr.Field<string>("HrmsNo"),
                                                   TimeDiff = dr.Field<string>("TimeDiff"),
                                                   DateofJoining = dr.Field<string>("DateofJoining"),
                                                   OldTimeDiiff = dr.Field<string>("OldTimeDiiff"),
                                                   OutTimeOld = dr.Field<DateTime?>("OutTimeOld").ToString(),
                                                   InTimeOld = dr.Field<DateTime?>("InTimeOld").ToString(),
                                                   isHoliday = dr.Field<int>("isHoliday")
                                               }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Districts
        public List<District> GetDistrictDetail(int districtID,int stateID,int countryID)
        {
            try
            {                    
                List<object> parameter = new List<object>();
                parameter.Add("@DistrictID");
                parameter.Add(districtID);
                parameter.Add("@StateID");
                parameter.Add(stateID);
                parameter.Add("@CountryID");
                parameter.Add(countryID);

                List<District> result = (from dr in DB.ReadDS("DistrictDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                          select new District()
                                          {
                                              DistrictID = dr.Field<int>("DistrictID"),
                                              DistrictName = dr.Field<string>("DistrictName"),
                                              DistrictCode = dr.Field<string>("DistrictCode"),
                                              CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                              CreatedBy = dr.Field<string>("CreatedBy"),
                                              StateID = dr.Field<int>("StateID"),
                                              StateCode = dr.Field<string>("StateCode"),
                                              StateName = dr.Field<string>("StateName"),
                                              CountryId = dr.Field<int>("CountryId"),
                                              CountryName = dr.Field<string>("CountryName")
                                          }).ToList();
                

                return result;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        #endregion

        #region Cities
        public List<City> GetCityDetail(int cityID,int districtID, int stateID, int countryID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@CityID");
                parameter.Add(cityID);
                parameter.Add("@DistrictID");
                parameter.Add(districtID);
                parameter.Add("@StateID");
                parameter.Add(stateID);
                parameter.Add("@CountryID");
                parameter.Add(countryID);

                List<City> result = (from dr in DB.ReadDS("CityDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                         select new City()
                                         {
                                             CityID = dr.Field<int>("CityID"),
                                             CityName = dr.Field<string>("CityName"),
                                             CityCode = dr.Field<string>("CityCode"),
                                             CityPostalCode = dr.Field<string>("CityPostalCode"),
                                             DistrictID = dr.Field<int>("DistrictID"),
                                             DistrictName = dr.Field<string>("DistrictName"),
                                             DistrictCode = dr.Field<string>("DistrictCode"),
                                             CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                             CreatedBy = dr.Field<string>("CreatedBy"),
                                             StateID = dr.Field<int>("StateID"),
                                             StateCode = dr.Field<string>("StateCode"),
                                             StateName = dr.Field<string>("StateName"),
                                             CountryId = dr.Field<int>("CountryId"),
                                             CountryName = dr.Field<string>("CountryName")
                                         }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Offices
        public List<OfficeDetail> GetOfficeDetail(int officeID,int cityID, int districtID, int stateID, int countryID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@OfficeID");
                parameter.Add(officeID);
                parameter.Add("@CityID");
                parameter.Add(cityID);
                parameter.Add("@DistrictID");
                parameter.Add(districtID);
                parameter.Add("@StateID");
                parameter.Add(stateID);
                parameter.Add("@CountryID");
                parameter.Add(countryID);

                List<OfficeDetail> result = (from dr in DB.ReadDS("OfficeDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                     select new OfficeDetail()
                                     {
                                         OfficeID = dr.Field<int>("OfficeID"),
                                         OfficeName = dr.Field<string>("OfficeName"),
                                         OfficeLattitute = dr.Field<float>("OfficeLattitute").ToString(),
                                         OfficeLongitute = dr.Field<float>("OfficeLongitute").ToString(),
                                         CityID = dr.Field<int>("CityID"),
                                         CityName = dr.Field<string>("CityName"),
                                         CityCode = dr.Field<string>("CityCode"),
                                         CityPostalCode = dr.Field<string>("CityPostalCode"),
                                         DistrictID = dr.Field<int>("DistrictID"),
                                         DistrictName = dr.Field<string>("DistrictName"),
                                         DistrictCode = dr.Field<string>("DistrictCode"),
                                         CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                         CreatedBy = dr.Field<string>("CreatedBy"),
                                         StateID = dr.Field<int>("StateID"),
                                         StateCode = dr.Field<string>("StateCode"),
                                         StateName = dr.Field<string>("StateName"),
                                         CountryId = dr.Field<int>("CountryId"),
                                         CountryName = dr.Field<string>("CountryName")
                                     }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Employee Types
        public List<EmployeeType> GetEmployeetypeDetail(int employeeTypeID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@EmployeeTypeID");
                parameter.Add(employeeTypeID);

                List<EmployeeType> result = (from dr in DB.ReadDS("EmployeeTypeDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                         select new EmployeeType()
                                         {
                                             EmployeeTypeID = dr.Field<int>("EmployeeTypeID"),
                                             EmployeeTypeName = dr.Field<string>("EmployeeTypeName"),
                                             CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                             CreatedBy = dr.Field<string>("CreatedBy")
                                         }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Leave Types
        public List<LeaveType> GetLeavetypeDetail(int leaveTypeID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@LeaveTypeID");
                parameter.Add(leaveTypeID);

                List<LeaveType> result = (from dr in DB.ReadDS("AttendanceLeaveTypeGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                             select new LeaveType()
                                             {
                                                 LeaveTypeID = dr.Field<int>("LeaveTypeID"),
                                                 LeaveTypeName = dr.Field<string>("LeaveTypeName"),
                                                 LeaveTypeCode = dr.Field<string>("LeaveTypeCode"),
                                                 CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                                 CreatedBy = dr.Field<string>("CreatedBy"),
                                                 IsAttachmentAllowed = dr.Field<bool>("IsAttachmentAllowed")
                                             }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Designation
        public List<DesignationDetail> GetDesignationDetail(int designationID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@DesignationID");
                parameter.Add(designationID);

                List<DesignationDetail> result = (from dr in DB.ReadDS("DesignationDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                          select new DesignationDetail()
                                          {
                                              DesignationID = dr.Field<int>("DesignationID"),
                                              DesignationName = dr.Field<string>("DesignationName"),
                                              CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                              CreatedBy = dr.Field<string>("CreatedBy")
                                          }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Branch
        public List<BranchDetail> GetBranchDetail(int branchID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@BranchID");
                parameter.Add(branchID);

                List<BranchDetail> result = (from dr in DB.ReadDS("BranchDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                  select new BranchDetail()
                                                  {
                                                      BranchID = dr.Field<int>("BranchID"),
                                                      BranchName = dr.Field<string>("BranchName"),
                                                      CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                                      CreatedBy = dr.Field<string>("CreatedBy"),
                                                      UpdatedOn = dr.Field<DateTime?>("UpdatedOn").ToString(),
                                                      UpdatedBy = dr.Field<string>("UpdatedBy")
                                                  }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Year
        public List<YearDetail> GetYearDetail(int yearID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@YearID");
                parameter.Add(yearID);

                List<YearDetail> result = (from dr in DB.ReadDS("YearDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                             select new YearDetail()
                                             {
                                                 YearId = dr.Field<int>("YearId"),
                                                 Year = dr.Field<string>("Year")
                                             }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region AttendanceLeaveTypeCount
        public List<LeaveTypeCount> GetLeaveTypeCount(int id,int yearID,int leaveTypeID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@ID");
                parameter.Add(id);
                parameter.Add("@YearID");
                parameter.Add(yearID);
                parameter.Add("@LeaveTypeID");
                parameter.Add(leaveTypeID);

                List<LeaveTypeCount> result = (from dr in DB.ReadDS("AttendanceLeaveCountGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                           select new LeaveTypeCount()
                                           {
                                               ID = dr.Field<int>("ID"),
                                               LeaveTypeID = dr.Field<int>("LeaveTypeID"),
                                               LeaveTypeCode = dr.Field<string>("LeaveTypeCode"),
                                               LeaveTypeName = dr.Field<string>("LeaveTypeName"),
                                               CountForMale = dr.Field<float>("CountForMale"),
                                               CountForFemale = dr.Field<float>("CountForFemale"),
                                               YearId = dr.Field<int>("YearId"),
                                               Year = dr.Field<string>("Year"),
                                               CreatedBy = dr.Field<string>("CreatedBy"),
                                               CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString()
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
                                                   IsActive = dr.Field<bool>("IsActive")
                                               }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Leave Category
        public List<LeaveCategoryDetail> GetLeaveCategories(int categoryId,bool isVisible)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@CategoryID");
                parameter.Add(categoryId);
                parameter.Add("@IsVisible");
                parameter.Add(isVisible);

                List<LeaveCategoryDetail> result = (from dr in DB.ReadDS("LeaveCategoryGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                         select new LeaveCategoryDetail()
                                                         {
                                                             CategoryID = dr.Field<int>("CategoryID"),
                                                             CategoryName = dr.Field<string>("CategoryName"),
                                                             IsVisible = dr.Field<bool>("IsVisible")
                                                         }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<ApprovalCategory> GetApprovalCategories(int categoryId)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@CategoryID");
                parameter.Add(categoryId);

                List<ApprovalCategory> result = (from dr in DB.ReadDS("ApprovalCategoryDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                    select new ApprovalCategory()
                                                    {
                                                        CategoryID = dr.Field<int>("CategoryID"),
                                                        CategoryName = dr.Field<string>("CategoryName"),
                                                        IsActive = dr.Field<bool>("IsActive"),
                                                        CreatedBy = dr.Field<string>("CreatedBy"),
                                                        CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                                        UpdatedBy = dr.Field<string>("UpdatedBy"),
                                                        UpdatedOn = dr.Field<DateTime?>("UpdatedOn").ToString()
                                                    }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Leave Status
        public List<LeaveStatusDetail> GetLeaveStatus(int statusId)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@StatusID");
                parameter.Add(statusId);

                List<LeaveStatusDetail> result = (from dr in DB.ReadDS("LeaveStatusGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                    select new LeaveStatusDetail()
                                                    {
                                                        StatusID = dr.Field<int>("StatusID"),
                                                        StatusName = dr.Field<string>("StatusName"),
                                                        StatusCode = dr.Field<string>("StatusCode"),
                                                        CreatedBy = dr.Field<string>("CreatedBy"),
                                                        CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString()
                                                    }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Holiday
        public List<HolidayType> GetHolidayType(int typeID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@TypeID");
                parameter.Add(typeID);

                List<HolidayType> result = (from dr in DB.ReadDS("HolidayTypeDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                                  select new HolidayType()
                                                  {
                                                      TypeID = dr.Field<int>("TypeID"),
                                                      TypeName = dr.Field<string>("TypeName"),
                                                      UpdatedBy = dr.Field<string>("UpdatedBy"),
                                                      UpdatedOn = dr.Field<DateTime?>("UpdatedOn").ToString(),
                                                      CreatedBy = dr.Field<string>("CreatedBy"),
                                                      CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                                      IsActive = dr.Field<bool>("IsActive")
                                                  }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<HolidayDetail> GetHolidayDetail(int typeID,long id)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@TypeID");
                parameter.Add(typeID);
                parameter.Add("@ID");
                parameter.Add(id);

                List<HolidayDetail> result = (from dr in DB.ReadDS("HolidayDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                            select new HolidayDetail()
                                            {
                                                ID = dr.Field<long>("ID"),
                                                Date = dr.Field<DateTime?>("Date").ToString(),
                                                Day = dr.Field<string>("Day"),
                                                Holiday = dr.Field<string>("Holiday"),
                                                TypeID = dr.Field<int>("TypeID"),
                                                TypeName = dr.Field<string>("TypeName"),
                                                UpdatedBy = dr.Field<string>("UpdatedBy"),
                                                UpdatedOn = dr.Field<DateTime?>("UpdatedOn").ToString(),
                                                CreatedBy = dr.Field<string>("CreatedBy"),
                                                CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                                IsActive = dr.Field<bool>("IsActive")
                                            }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion
    }
}