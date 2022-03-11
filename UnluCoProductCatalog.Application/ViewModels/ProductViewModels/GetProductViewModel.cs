
namespace UnluCoProductCatalog.Application.ViewModels.ProductViewModels
{
    public class GetProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public bool IsOfferable { get; set; } = false;
        public string CategoryName { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public string UsingStatus { get; set; }
        public string  Image { get; set; }
        public double Price { get; set; }
    }
}

