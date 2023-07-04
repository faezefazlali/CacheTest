using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CacheTest.Core.Contracts.DTOs;

namespace CacheTest.Common.DTOs.Security
{
    public class UserDTO : BaseEntityDTO
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(100)]
        public string Password { get; set; }
    }


}
