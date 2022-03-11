using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnluCoProductCatalog.Domain.Entities
{
    public class AccountDetail : BaseEntity
    {
        public Product Product { get; set; }
        public Offer Offer { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
