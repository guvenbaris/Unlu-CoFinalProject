using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.CategoryViewModels;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> GetAll();
        void Create(CommandCategoryViewModel entity);
        void Update(CommandCategoryViewModel entity, int id);
        void Delete(int id);
    }
}


