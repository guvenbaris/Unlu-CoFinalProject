using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.BrandViewModels;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IBrandService
    {
        ICollection<BrandViewModel> GetAll();
        void Update(CommandBrandViewModel entity,int id);
        void Create(CommandBrandViewModel entity);
        void Delete(int id);
    }

}