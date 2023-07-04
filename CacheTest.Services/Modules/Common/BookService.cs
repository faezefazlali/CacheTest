using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CacheTest.Common.DTOs.Common;
using CacheTest.Core.Biz;
using CacheTest.Core.DataAccess;
using CacheTest.Domain.Common;
using CacheTest.Services.Contracts.Common;


namespace CacheTest.Services.Modules.Common
{
    public sealed class BookService : BaseBiz<Book, BookDTO>, IBookService
    {
        public BookService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        private BookDTO getBookHttpResponse<R>(string path)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://get.taaghche.com")
            };

            HttpResponseMessage response = client.GetAsync(path).Result;

            var resulJson = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var bookJson = JObject.Parse(resulJson.ToString());
                var book = JsonConvert.DeserializeObject<BookDTO>(bookJson["book"].ToString());
                return book;
            }

            return null;
        }

        public BookDTO GetBookFromApi(int id)
        {
            return getBookHttpResponse<BookDTO>($"/v2/book/{id}");
        }
    }
}
