using System.ComponentModel.DataAnnotations;

namespace UnluCoProductCatalog.Domain.Entities
{
    public class Brand : BaseEntity
    {
        [Required]
        public string BrandName { get; set; }
    }
}