using Microsoft.EntityFrameworkCore;
using UnluCoProductCatalog.Infrastructure.Contexts;

namespace UnluCoProductCatalog.UnitTests.DataGenerator
{
    public class CommanTextFixture
    {
        public  ProductCatalogDbContext Context { get; set; }

        public CommanTextFixture()
        {
            var options = new DbContextOptionsBuilder<ProductCatalogDbContext>()
                .UseInMemoryDatabase(databaseName: "ProductCatalogTestDb").Options;
            Context = new ProductCatalogDbContext(options);


            Context.Database.EnsureCreated();
            Context.Categories.AddRange(DataWareHouse.GetCategoriesData());
            Context.SaveChanges();
        }

        
    }
}
