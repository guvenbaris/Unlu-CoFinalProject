using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;

namespace UnluCoProductCatalog.Infrastructure.Repositories
{
    public class BrandRepository : RepositoryBase<Brand>,IBrandRepository
    {
        public BrandRepository(ProductCatalogDbContext context) : base(context)
        {
        }
    }
}