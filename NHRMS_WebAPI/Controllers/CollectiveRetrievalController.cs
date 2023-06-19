using ITInventory.Common;
using NHRMS_WebAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NHRMS_WebAPI.Controllers
{
    public class CollectiveRetrievalController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        
        [Route("app/GetDataForRegistration/{genderID}/{designationID}/{branchID}/{employeeTypeID}/{districtID}/{stateID}/{countryID}")]
        public output GetDataForRegistration(int genderID,int designationID,int branchID,int employeeTypeID, int districtID, int stateID, int countryID)
        {
            output result = new output();
            data gender = new data();
            data designation = new data();
            data branch = new data();
            data employeeType = new data();
            data district = new data();
            data state = new data();
            ArrayList arrayList = new ArrayList();
            
            try
            {
                CollectiveRetrievalController dd=new CollectiveRetrievalController();

                gender.ResponseDataC = dd.GetGender(genderID);
                designation.ResponseDataC = dd.GetDesignations(designationID);
                branch.ResponseDataC = dd.GetBranches(branchID);
                employeeType.ResponseDataC = dd.GetEmployeetypes(employeeTypeID);
                district.ResponseDataC = dd.GetDistricts(districtID, stateID, countryID);
                state.ResponseDataC = dd.GetStates(stateID, countryID);

                arrayList.Add(gender.ResponseDataC);
                arrayList.Add(designation.ResponseDataC);
                arrayList.Add(branch.ResponseDataC);
                arrayList.Add(employeeType.ResponseDataC);
                arrayList.Add(state.ResponseDataC);
                arrayList.Add(district.ResponseDataC);
                result.ResponseData = arrayList;
                result.IsSucess = true;
                result.Message = "";

            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        private data GetGender(int genderID)
        {
            data result = new data();
            try
            {
                List<Gender> obj = DAL.GetGenderDetail(genderID);
                result = result.GetResponseData<Gender>(obj);
            }
            catch (Exception ex)
            {
                
            }
            return result;
        }

        private data GetDesignations(int designationID)
        {
            data result = new data();
            try
            {
                List<DesignationDetail> obj = DAL.GetDesignationDetail(designationID);

                result = result.GetResponseData<DesignationDetail>(obj);
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        private data GetBranches(int branchID)
        {
            data result = new data();
            try
            {
                List<BranchDetail> obj = DAL.GetBranchDetail(branchID);

                result = result.GetResponseData<BranchDetail>(obj);
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        private data GetEmployeetypes(int employeeTypeID)
        {
            data result = new data();
            try
            {
                List<EmployeeType> obj = DAL.GetEmployeetypeDetail(employeeTypeID);

                result = result.GetResponseData<EmployeeType>(obj);
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        private data GetDistricts(int districtID, int stateID, int countryID)
        {
            data result = new data();
            try
            {
                List<District> obj = DAL.GetDistrictDetail(districtID, stateID, countryID);

                result = result.GetResponseData<District>(obj);
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        private data GetStates(int stateID, int countryID)
        {
            data result = new data();
            try
            {
                List<State> obj = DAL.GetStateDetail( stateID, countryID);

                result = result.GetResponseData<State>(obj);
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
