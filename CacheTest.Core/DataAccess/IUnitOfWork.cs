﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CacheTest.Core.Contracts.Entities;
using CacheTest.Core.Module;

namespace CacheTest.Core.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {

        IRepository<T> Repository<T>() where T : BaseEntity;

        string GetConnStr();
        CurrentUser GetCurrentUser();
        DbContext GetContext();
        int Commit();
    }
}
