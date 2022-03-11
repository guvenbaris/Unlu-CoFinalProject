using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;


namespace UnluCoProductCatalog.Application.Interfaces.Repositories
{
    
    public interface IProductRepository : IRepositoryBase<Product>
    {
        public IEnumerable<GetProductViewModel> GetProductsByCategoryId(int id);
        public IEnumerable<GetProductViewModel> GetProducts();
        public IEnumerable<ProductOfferViewModel> GetProductsForOffer();
        public IEnumerable<GetProductViewModel> GetUserProducts(string userId);

    }
}
