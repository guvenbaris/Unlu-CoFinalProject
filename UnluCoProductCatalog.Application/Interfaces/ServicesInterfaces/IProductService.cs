using System.Collections.Generic;
using System.Threading.Tasks;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IProductService
    {
        IEnumerable<GetProductViewModel> GetAll();
        void RetractTheOffer(int productId);
        IEnumerable<GetProductViewModel> GetProductsByCategoryId(int id);
        IEnumerable<GetProductViewModel> GetUserProducts(string userId);
        IEnumerable<ProductOfferViewModel> GetProductsForOffer();
        void SellProduct(ProductSellViewModel entity, string userId);
        void Create(CreateProductViewModel entity,string userId);
        void UpdateIsOfferable(int id);
    }
}