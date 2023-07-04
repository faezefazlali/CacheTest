using CacheTest.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheTest.Domain.Common
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public long Price { get; set; }
        public int NumberOfPages { get; set; }
    }
}
