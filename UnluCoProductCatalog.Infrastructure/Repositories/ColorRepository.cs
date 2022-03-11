using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;

namespace UnluCoProductCatalog.Infrastructure.Repositories
{
    public class  ColorRepository : RepositoryBase<Color>, IColorRepository
    {
        public ColorRepository(ProductCatalogDbContext context) : base(context)
        {
        }
    }
}