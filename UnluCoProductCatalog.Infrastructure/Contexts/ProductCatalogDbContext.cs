using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Infrastructure.Contexts
{
    public class ProductCatalogDbContext : IdentityDbContext<User>
    {
        public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options ): base(options)
        {
        }

        public DbSet<Color> Colors { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UsingStatus> UsingStatuses { get; set; }
        public DbSet<AccountDetail> AccountDetails { get; set; }
    }
}
