using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.ColorViewModels;


namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IColorService
    {
        ICollection<ColorViewModel> GetAll();
        void Update(CommandColorViewModel entity,int id);
        void Create(CommandColorViewModel entity);
        void Delete(int id);
    }
}

