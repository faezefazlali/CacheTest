using CacheTest.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheTest.Services.Contracts.Cache
{
    public interface IRedisService
    {
        void SetData(string key, object data, int cacheTimeInMinutes = CommonConst.DefaultCacheTimeMin);
        bool GetData<T>(string key, out T result);

    }
}
