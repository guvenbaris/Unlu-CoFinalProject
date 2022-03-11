using System;
using System.Collections.Generic;
using System.Linq;
using UnluCoProductCatalog.Application.ViewModels.CategoryViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.UnitTests.DataGenerator
{
    public static class DataWareHouse
    {
        public static IEnumerable<Category> GetCategoriesData()
        {
            var result = new List<Category>
            {
                new Category {Id = 1, IsDeleted = false, CategoryName = "Test1", CreatedDate = DateTime.Now},
                new Category {Id = 2, IsDeleted = false, CategoryName = "Test2", CreatedDate = DateTime.Now},
                new Category {Id = 3, IsDeleted = false, CategoryName = "Test3", CreatedDate = DateTime.Now},

            }.AsQueryable();

            return result;
        }

        public static CommandCategoryViewModel GetCommandCategoryViewModel()
        {
            return new CommandCategoryViewModel {CategoryName = "Test1"};
        }
    }
}