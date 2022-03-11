using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnluCoProductCatalog.Domain.Entities
{
    public class Product : BaseEntity 
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsOfferable { get; set; } = false;
        public bool IsSold { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public  Color Color { get; set; }
        public  Brand Brand { get; set; }
        public ICollection<Offer> Offers { get; set; }

        [Required]
        public string UserId { get; set; }
        public  ICollection<User> Users { get; set; }

        [Required]
        public int UsingStatusId { get; set; }
        public UsingStatus UsingStatus { get; set; }

        [Required]
        public string Image { get; set; }
        public double Price { get; set; }

    }
}