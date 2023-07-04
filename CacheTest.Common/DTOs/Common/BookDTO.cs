using CacheTest.Core.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheTest.Common.DTOs.Common
{
    public class BookDTO : BaseEntityDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public long Price { get; set; }
        public int NumberOfPages { get; set; }
    }
}
