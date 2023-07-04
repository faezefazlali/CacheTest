using Microsoft.AspNetCore.Mvc;
using CacheTest.Common.DTOs.Common;
using CacheTest.Common.Constants;

namespace CashTest.Controllers
{
    // [Authorize]
    public class BaseApiController : ControllerBase
    {
        [NonAction]
        public string GetCatchKey(string tableName , int id)
        {
            return string.Format(CacheKeyTemplate.ByIdCacheKey, tableName, id);
        }

        [NonAction]
        public OkObjectResult Okk()
        {
            return Ok(new BaseResponse(true));
        }

        [NonAction]
        public OkObjectResult Okk(object data)
        {
            return Ok(new BaseResponse(data));
        }

        [NonAction]
        public OkObjectResult Okk(bool succeed, string errorMessage)
        {
            return Ok(new BaseResponse(succeed, errorMessage));
        }

        [NonAction]
        public OkObjectResult Okk(bool succeed, string errorMessage, object data)
        {
            return Ok(new BaseResponse(succeed, errorMessage) { Data = data });
        }


    }
}
