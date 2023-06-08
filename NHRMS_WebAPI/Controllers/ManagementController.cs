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
    public class ManagementController : ApiController
    {
        DataAccessLayer DAL = new DataAccessLayer();
        [Route("app/GetManagementCategoriesDetail/{categoryId}/{authorityCategoryId}")]
        public output GetManagementCategoriesDetail(int categoryId, int authorityCategoryId)
        {
            output result = new output();
            try
            {
                List<ManagementCategoryDetail> obj = DAL.GetManagementCategories(categoryId, authorityCategoryId);
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
