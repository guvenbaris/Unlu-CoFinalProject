using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnluCoProductCatalog.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string CategoryName { get; set; }
    }
}

