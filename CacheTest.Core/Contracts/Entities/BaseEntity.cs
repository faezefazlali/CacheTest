using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheTest.Core.Contracts.Entities;

namespace CacheTest.Core.Contracts.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int? CreatorId { get; set; }
        public bool IsDelete { get; set; }
    }

}
