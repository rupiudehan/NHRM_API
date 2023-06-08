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
    public class LeaveCategoryController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        [Route("app/GetLeaveCategoriesDetail/{categoryId}")]
        public output GetLeaveCategoriesDetail(int categoryId)
        {
            output result = new output();
            try
            {
                List<LeaveCategoryDetail> obj = DAL.GetLeaveCategories(categoryId, true);
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
