using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;

namespace UnluCoProductCatalog.Infrastructure.Repositories
{
    public class UsingStatusRepository : RepositoryBase<UsingStatus>,IUsingStatusRepository
    {
        public UsingStatusRepository(ProductCatalogDbContext context) : base(context)
        {
        }
    }
}