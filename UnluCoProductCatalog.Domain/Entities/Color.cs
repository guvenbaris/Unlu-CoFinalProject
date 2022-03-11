using System.ComponentModel.DataAnnotations;

namespace UnluCoProductCatalog.Domain.Entities
{
    public class Color : BaseEntity
    {
        [Required]
        public string ColorName { get; set; }
    }
}