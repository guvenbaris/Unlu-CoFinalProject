using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;

namespace UnluCoProductCatalog.Infrastructure.Repositories
{
    public class  AccountDetailRepository : RepositoryBase<AccountDetail>, IAccountDetailRepository
    {
        public AccountDetailRepository(ProductCatalogDbContext context) : base(context)
        {
        }
    }
}