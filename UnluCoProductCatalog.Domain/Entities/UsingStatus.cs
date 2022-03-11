using System.ComponentModel.DataAnnotations;

namespace UnluCoProductCatalog.Domain.Entities
{
    public class UsingStatus : BaseEntity
    {
        [Required]
        public string UsingStatusName { get; set; }
    }
}