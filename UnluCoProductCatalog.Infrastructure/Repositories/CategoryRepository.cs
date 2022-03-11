using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;

namespace UnluCoProductCatalog.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>,ICategoryRepository
    {
        public CategoryRepository(ProductCatalogDbContext context) : base(context)
        {
        }
    }
}