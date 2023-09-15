using ITInventory.Common;
using NHRMS_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace NHRMS_WebAPI.Extension
{
    public class MastersDataAccessLayer
    {
        DbProviderFactory Factory = DB.GetFactory();
        DbConnection con = DB.GetConnection();

        #region Country Detail
        public MessageHandle CreateUpdateCountryDetail(CountryDetail obj)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@ID");
            parameter.Add(obj.CountryId);
            parameter.Add("@CountryCode");
            parameter.Add(obj.CountryCode);
            parameter.Add("@CountryName");
            parameter.Add(obj.CountryName);
            parameter.Add("@CommCode");
            parameter.Add(obj.CommCode);
            parameter.Add("@ProcessedBy");
            parameter.Add(obj.ProcessedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("CountryDetailCreateEdit", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            return result;
        }
        public MessageHandle DeleteCountryDetail(int countryID)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@ID");
            parameter.Add(countryID);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("CountryDetailDelete", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            return result;
        }
        public List<CountryDetail> GetCountryDetail(int countryID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@ID");
                parameter.Add(countryID);

                List<CountryDetail> result = (from dr in DB.ReadDS("CountryDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                       select new CountryDetail()
                                       {
                                           CountryId = dr.Field<int>("CountryId"),
                                           CountryName = dr.Field<string>("CountryName"),
                                           CountryCode = dr.Field<string>("CountryCode"),
                                           CommCode = dr.Field<int>("CommCode"),
                                           IsActive = dr.Field<bool>("IsActive"),
                                           CreatedBy = dr.Field<string>("CreatedBy"),
                                           CreatedOn = string.Format("{0:dd/MM/yyyy hh:mm tt}", dr.Field<DateTime?>("CreatedOn")),
                                           UpdatedBy = dr.Field<string>("UpdatedBy"),
                                           UpdatedOn = string.Format("{0:dd/MM/yyyy hh:mm tt}", dr.Field<DateTime?>("UpdatedOn")),
                                       }).ToList();


                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region Gender Detail
        public List<Gender> GetGenderDetail(int genderID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@GenderID");
                parameter.Add(genderID);

                List<Gender> result = (from dr in DB.ReadDS("GenderDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                       select new Gender()
                                       {
                                           GenderID = dr.Field<int>("GenderID"),
                                           GenderName = dr.Field<string>("GenderName"),
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

        #region States
        public MessageHandle CreateUpdateStateDetail(State obj)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@ID");
            parameter.Add(obj.StateID);
            parameter.Add("@CountryID");
            parameter.Add(obj.CountryId);
            parameter.Add("@StateCode");
            parameter.Add(obj.StateCode);
            parameter.Add("@StateName");
            parameter.Add(obj.StateName);
            parameter.Add("@PostalCode");
            parameter.Add(obj.PostalCode);
            parameter.Add("@ProcessedBy");
            parameter.Add(obj.ProcessedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("StateDetailCreateEdit", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            return result;
        }
        public MessageHandle DeleteStateDetail(int stateID)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@ID");
            parameter.Add(stateID);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("StateDetailDelete", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            return result;
        }
        public List<State> GetStateDetail(int stateID, int countryID)
        {
            try
            {
                List<object> parameter = new List<object>();
                parameter.Add("@StateID");
                parameter.Add(stateID);
                parameter.Add("@CountryID");
                parameter.Add(countryID);

                List<State> result = (from dr in DB.ReadDS("StateDetailGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                      select new State()
                                      {
                                          CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                          CreatedBy = dr.Field<string>("CreatedBy"),
                                          UpdatedOn = dr.Field<DateTime?>("UpdatedOn").ToString(),
                                          UpdatedBy = dr.Field<string>("UpdatedBy"),
                                          StateID = dr.Field<int>("StateID"),
                                          StateCode = dr.Field<string>("StateCode"),
                                          StateName = dr.Field<string>("StateName"),
                                          CountryId = dr.Field<int>("CountryId"),
                                          CountryName = dr.Field<string>("CountryName"),
                                          PostalCode = dr.Field<string>("PostalCode"),
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

        #region Districts
        public MessageHandle CreateUpdateDistrictDetail(District obj)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@ID");
            parameter.Add(obj.DistrictID);
            parameter.Add("@StateID");
            parameter.Add(obj.StateID);
            parameter.Add("@DistrictCode");
            parameter.Add(obj.DistrictCode);
            parameter.Add("@DistrictName");
            parameter.Add(obj.DistrictName);
            parameter.Add("@ProcessedBy");
            parameter.Add(obj.ProcessedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("DistrictDetailCreateEdit", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            return result;
        }
        public MessageHandle DeleteDistrictDetail(int districtID)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@ID");
            parameter.Add(districtID);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("DistrictDetailDelete", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            return result;
        }
        public List<District> GetDistrictDetail(int districtID, int stateID, int countryID)
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
                                             UpdatedOn = dr.Field<DateTime?>("UpdatedOn").ToString(),
                                             UpdatedBy = dr.Field<string>("UpdatedBy"),
                                             StateID = dr.Field<int>("StateID"),
                                             StateCode = dr.Field<string>("StateCode"),
                                             StateName = dr.Field<string>("StateName"),
                                             CountryId = dr.Field<int>("CountryId"),
                                             CountryName = dr.Field<string>("CountryName"),
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

        #region Cities
        public MessageHandle CreateUpdateCityDetail(City obj)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@ID");
            parameter.Add(obj.CityID);
            parameter.Add("@DistrictID");
            parameter.Add(obj.DistrictID);
            parameter.Add("@CityCode");
            parameter.Add(obj.CityCode);
            parameter.Add("@CityName");
            parameter.Add(obj.CityName);
            parameter.Add("@PostalCode");
            parameter.Add(obj.PostalCode);
            parameter.Add("@ProcessedBy");
            parameter.Add(obj.ProcessedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("CityDetailCreateEdit", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            return result;
        }
        public MessageHandle DeleteCityDetail(int cityID)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@ID");
            parameter.Add(cityID);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("CityDetailDelete", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            return result;
        }
        public List<City> GetCityDetail(int cityID, int districtID, int stateID, int countryID)
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
                                         UpdatedOn = dr.Field<DateTime?>("UpdatedOn").ToString(),
                                         UpdatedBy = dr.Field<string>("UpdatedBy"),
                                         StateID = dr.Field<int>("StateID"),
                                         StateCode = dr.Field<string>("StateCode"),
                                         StateName = dr.Field<string>("StateName"),
                                         CountryId = dr.Field<int>("CountryId"),
                                         CountryName = dr.Field<string>("CountryName"),
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

        #region Offices
        public List<OfficeDetail> GetOfficeDetail(int officeID, int cityID, int districtID, int stateID, int countryID)
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
                                                 OfficeLattitute = dr.Field<double>("OfficeLattitute").ToString(),
                                                 OfficeLongitute = dr.Field<double>("OfficeLongitute").ToString(),
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
                                                 CountryName = dr.Field<string>("CountryName"),
                                                 OfficeInTime = dr.Field<TimeSpan?>("InTime")==null?"":dr.Field<TimeSpan?>("InTime").ToString(),
                                                 OfficeOutTime = dr.Field<TimeSpan?>("OutTime")==null?"": dr.Field<TimeSpan?>("OutTime").ToString(),
                                                 HalfDayTime = dr.Field<TimeSpan?>("HalfDayTime")==null?"": dr.Field<TimeSpan?>("HalfDayTime").ToString(),
                                                 ShortLeaveTime = dr.Field<TimeSpan?>("ShortLeaveTime")==null?"": dr.Field<TimeSpan?>("ShortLeaveTime").ToString(),
                                                 Success = 1,
                                                 Message = ""
                                             }).ToList();


                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public MessageHandle CreateUpdateOfficeDetail(int id,int cityID,string officeName,string latitute,string longitute,string processedBy)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@ID");
            parameter.Add(id);
            parameter.Add("@CityID");
            parameter.Add(cityID);
            parameter.Add("@OfficeName");
            parameter.Add(officeName);
            parameter.Add("@OfficeLattitute");
            parameter.Add(latitute);
            parameter.Add("@OfficeLongitute");
            parameter.Add(longitute);
            parameter.Add("@ProcessedBy");
            parameter.Add(processedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("OfficeDetailCreateEdit", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            return result;
        }
        public MessageHandle DeleteOfficeDetail(int id)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@ID");
            parameter.Add(id);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("OfficeDetailDelete", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            return result;
        }

        public List<OfficeDetail> GetOfficeDetailWithoutTiming(int officeID, int cityID, int districtID, int stateID, int countryID)
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

                List<OfficeDetail> result = (from dr in DB.ReadDS("OfficeDetailWithoutTimingGet", parameter.ToArray()).Tables[0].AsEnumerable()
                                             select new OfficeDetail()
                                             {
                                                 OfficeID = dr.Field<int>("OfficeID"),
                                                 OfficeName = dr.Field<string>("OfficeName"),
                                                 OfficeLattitute = dr.Field<double>("OfficeLattitute").ToString(),
                                                 OfficeLongitute = dr.Field<double>("OfficeLongitute").ToString(),
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
                                                 CountryName = dr.Field<string>("CountryName"),
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

        public MessageHandle SetOfficeTimeDetail(int officeID, string inTime, string outTime, string halfTime, string shortTime, string processedBy)
        {
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@OfficeID");
            parameter.Add(officeID);
            parameter.Add("@InTime");
            parameter.Add(inTime);
            parameter.Add("@OutTime");
            parameter.Add(outTime);
            parameter.Add("@HalfDayTime");
            parameter.Add(halfTime);
            parameter.Add("@ShortLeaveTime");
            parameter.Add(shortTime);
            parameter.Add("@ProcessedBy");
            parameter.Add(processedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("OfficeTimingDetailEdit", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            return result;
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
                                                 CreatedBy = dr.Field<string>("CreatedBy"),
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
                                              IsAttachmentAllowed = dr.Field<bool>("IsAttachmentAllowed"),
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
                                                      CreatedBy = dr.Field<string>("CreatedBy"),
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
                                                 BranchID = dr.Field<long>("BranchID"),
                                                 BranchName = dr.Field<string>("BranchName"),
                                                 CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
                                                 CreatedBy = dr.Field<string>("CreatedBy"),
                                                 UpdatedOn = dr.Field<DateTime?>("UpdatedOn").ToString(),
                                                 UpdatedBy = dr.Field<string>("UpdatedBy"),
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
                                               Year = dr.Field<string>("Year"),
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

        #region AttendanceLeaveTypeCount
        public List<LeaveTypeCount> GetLeaveTypeCount(int id, int yearID, int leaveTypeID)
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
                                                   CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
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

        #region Leave Category
        public List<LeaveCategoryDetail> GetLeaveCategories(int categoryId, bool isVisible)
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
                                                        IsVisible = dr.Field<bool>("IsVisible"),
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
                                                     UpdatedOn = dr.Field<DateTime?>("UpdatedOn").ToString(),
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
                                                      CreatedOn = dr.Field<DateTime?>("CreatedOn").ToString(),
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
        public List<HolidayDetail> GetHolidayDetail(int typeID, long id)
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
                                                  Date = string.Format("{0:dd/MM/yyyy}", dr.Field<DateTime?>("Date")),
                                                  Day = dr.Field<string>("Day"),
                                                  Holiday = dr.Field<string>("Holiday"),
                                                  TypeID = dr.Field<int>("TypeID"),
                                                  TypeName = dr.Field<string>("TypeName"),
                                                  DistrictID = dr.Field<int>("DistrictID"),
                                                  DistrictName = dr.Field<string>("DistrictName"),
                                                  UpdatedBy = dr.Field<string>("UpdatedBy"),
                                                  UpdatedOn = dr.Field<DateTime?>("UpdatedOn").ToString(),
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
        public MessageHandle CreateHolidayDetail(string date, int holidayTypeID, int districtID, long processedBy)
        {
            DataAccessLayer da = new DataAccessLayer();
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter = da.MapDate(date, parameter, "@Date");
            parameter.Add("@HolidayTypeID");
            parameter.Add(holidayTypeID);
            parameter.Add("@DistrictID");
            parameter.Add(districtID);
            parameter.Add("@ProcessedBy");
            parameter.Add(processedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("HolidayDetailCreate", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            return result;
        }
        public MessageHandle DeleteHolidayDetail(int id, int districtID)
        {
            DataAccessLayer da = new DataAccessLayer();
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@ID");
            parameter.Add(id);
            parameter.Add("@DistrictID");
            parameter.Add(districtID);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("HolidayDetailDelete", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            return result;
        }

        public MessageHandle CreateHolidayWeekOffDetail(long processedBy)
        {
            DataAccessLayer da = new DataAccessLayer();
            MessageHandle result = new MessageHandle();
            List<object> parameter = new List<object>();
            parameter.Add("@ProcessedBy");
            parameter.Add(processedBy);

            List<object> outParameter = OutputParams();
            string[] output = DB.InsertorUpdateWithOutput("HolidayWeekEndsCreate", parameter.ToArray(), outParameter.ToArray());
            result.Success = Convert.ToInt16(output[0]);
            result.Message = output[1];
            return result;
        }
        #endregion

        #region Functions
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
        #endregion
    }
}