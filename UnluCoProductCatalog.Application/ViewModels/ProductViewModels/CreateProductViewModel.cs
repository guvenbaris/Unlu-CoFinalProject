
namespace UnluCoProductCatalog.Application.ViewModels.ProductViewModels
{
    public class CreateProductViewModel 
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int? ColorId { get; set; }
        public int? BrandId { get; set; }
        public int UsingStatusId { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
    }
}



