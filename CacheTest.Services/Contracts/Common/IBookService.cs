using CacheTest.Common.DTOs.Common;
using CacheTest.Core.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheTest.Services.Contracts.Common
{
    public interface IBookService : IBiz<BookDTO>
    {
        BookDTO GetBookFromApi(int id);
    }
}
