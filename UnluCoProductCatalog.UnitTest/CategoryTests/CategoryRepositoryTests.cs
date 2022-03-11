using System;
using System.Linq;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;
using UnluCoProductCatalog.Infrastructure.Repositories;
using UnluCoProductCatalog.UnitTests.DataGenerator;
using Xunit;

namespace UnluCoProductCatalog.UnitTests.CategoryTests
{
   
    public class CategoryRepositoryTests :IClassFixture<CommanTextFixture>
    {
        private readonly ProductCatalogDbContext _context;
        public CategoryRepositoryTests(CommanTextFixture textFixture)
        {
            _context = textFixture.Context;
        }


        [Fact]
        public void GetAll_ShouldReturn_CategoryList()
        {
            var repository = new CategoryRepository(_context);
            var categories = repository.GetAll();

            Assert.NotEmpty(categories);
            Assert.Equal(3, categories.Count());
        }

        [Fact]
        public void GetById_ShouldReturn_Category()
        {
            var repository = new CategoryRepository(_context);
            var category = repository.GetById(1);

            Assert.NotNull(category);
        }

        [Fact]
        public void Get_ShouldReturn_CategoryList()
        {
            var repository = new CategoryRepository(_context);
            var categories = repository.Get(x => x.CategoryName == "Test1");
            Assert.NotEmpty(categories);
        }

        [Fact]
        public  void Create_ShouldReturn_Exception()
        {
            var repository = new CategoryRepository(_context);

            var category = new Category
            {
                IsDeleted = false,
                CategoryName = "Test4",
                CreatedDate = DateTime.Now
            };

            var exception =
                Record.Exception(() => repository.Create(category));
            Assert.Null(exception);
        }

        [Fact]
        public void Update_ShouldNotReturn_Exception()
        {
            var repository = new CategoryRepository(_context);

            var category = new Category
            {
                IsDeleted = false,
                CategoryName = "Test2",
                CreatedDate = DateTime.Now.AddDays(1)
            };


            var exception = 
                Record.Exception(() => repository.Update(category));
            Assert.Null(exception);
        }

        [Fact]
        public void Delete_ShouldNotReturn_Exception()
        {
            var repository = new CategoryRepository(_context);

            var category = new Category
            {
                IsDeleted = false,
                CategoryName = "Test2",
                CreatedDate = DateTime.Now.AddDays(1)
            };

            var exception =
                Record.Exception(() => repository.Delete(category));
            Assert.Null(exception);
        }


    }
}
