using Microsoft.AspNetCore.Mvc;
using CacheTest.Common.DTOs.Common;
using CacheTest.Services.Contracts.Common;
using NSwag.Annotations;
using CacheTest.Services.Contracts.Cache;

namespace CashTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : BaseApiController
    {
        private readonly IBookService _bookService;
        private readonly ICacheService _cacheService;

        public BookController(IBookService bookService, ICacheService cacheService)
        {
            _bookService = bookService;
            _cacheService = cacheService;
        }


        [HttpGet(Name = "GetById")]
        [OpenApiOperation("GetById", "Get Book ", "")]
        public IActionResult GetById(int id)
        {
            var cacheKey = GetCatchKey(typeof(BookDTO).Name, id);
            var book = _cacheService.GetOrSet(cacheKey, () => _bookService.GetBookFromApi(id));

            return Okk(book);
        }

    }
}
