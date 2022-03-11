namespace UnluCoProductCatalog.Domain.Entities
{
    public class Offer : BaseEntity
    {
        public int PercentRate { get; set; } = 30;
        public bool IsApproved { get; set; }
        public bool IsSold { get; set; } = false;
        public  double OfferedPrice { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

