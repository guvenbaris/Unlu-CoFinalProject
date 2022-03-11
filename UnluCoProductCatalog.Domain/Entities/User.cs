using System;
using Microsoft.AspNetCore.Identity;

namespace UnluCoProductCatalog.Domain.Entities
{
    public class User : IdentityUser
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        
    }
}
