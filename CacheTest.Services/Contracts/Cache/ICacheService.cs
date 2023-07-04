using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheTest.Services.Contracts.Cache
{
    public interface ICacheService
    {
        T GetOrSet<T>(string key, Func<T> getData);
    }
}
